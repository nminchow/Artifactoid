using System;
using System.Threading.Tasks;
using System.Reflection;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Artifact.Models;
using System.Linq;

namespace Artifact
{
    class Program
    {
        private CommandService _commands;
        private DiscordSocketClient _client;
        private IServiceProvider _services;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {

            IConfiguration configuration = LoadConfig.Instance.config;
            var db = new DataBase(configuration.GetConnectionString("sql"));

            Card_Set[] cardSets = LoadCards.Instance.sets;

            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.JoinedGuild += Controllers.JoinedGuild.Joined(db);
            // disable joined message for now
            //_client.UserJoined += Controllers.Helpers.UserJoined.SendJoinedMessage;


            _commands = new CommandService();

            string token = configuration["discordAppToken"];

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton(db)
                .BuildServiceProvider();

            await InstallCommandsAsync();

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();


            await Task.Delay(-1);
        }

        public async Task InstallCommandsAsync()
        {
            // Hook the MessageReceived Event into our Command Handler
            _client.MessageReceived += HandleCommandAsync;
            _client.MessageReceived += ScanForMentions;
            _client.ReactionAdded += HandleReaction;
            // Discover all of the commands in this assembly and load them.
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleReaction(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var candidate = Views.Card.Labels.FirstOrDefault(x => x.Name == reaction.Emote.Name);
            if (candidate == null)
            {
                return;
            }

            try
            {
                var message = await cache.GetOrDownloadAsync();
                if(message.Author.Id == _client.CurrentUser.Id)
                {

                    if(message.Reactions[reaction.Emote].ReactionCount != 2)
                    {
                        return;
                    }

                    await Controllers.Card.SendReactionCard.PerformAsync(channel, message, candidate);
                }
                
            } catch (Exception e)
            {
                await channel.SendMessageAsync("Error looking up card. Does the bot have needed permission?");
            }
            return;
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a System Message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            var context = new SocketCommandContext(_client, message);

            if (context.User.IsBot) return;

            // Create a number to track where the prefix ends and the command begins
            var prefix = $"!";
            int argPos = prefix.Length - 1;

            // Determine if the message is a command, based on if it starts with '!' or a mention prefix
            if (!(message.HasStringPrefix(prefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;
            // quick logging
            Console.WriteLine("processed message!");
            // Execute the command. (result does not indicate a return value, 
            // rather an object stating if the command executed successfully)
            await SendCommandAsync(context, argPos);
        }

        // todo extract common logic between these handlers
        private async Task ScanForMentions(SocketMessage messageParam)
        {
            // Don't process the command if it was a System Message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            var context = new SocketCommandContext(_client, message);
            if (context.User.IsBot) return;
            var prefix = $"!";
            int argPos = prefix.Length - 1;

            // this was a command
            if (message.HasStringPrefix(prefix, ref argPos)) return;
            await Controllers.Card.TextScan.PerformAsync(context, _services.GetRequiredService<DataBase>());
        }

        private async Task SendCommandAsync(SocketCommandContext context, int argPos)
        {
            var result = await _commands.ExecuteAsync(context, argPos, _services);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.FromResult(0);
        }
    }
}
