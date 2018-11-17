using Artifact.Models;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Controllers.Card
{
    class SendReactionCard
    {
        public static async Task PerformAsync(ISocketMessageChannel channel, Discord.IUserMessage message, Discord.Emoji candidate, DataBase db)
        {
            if (!(channel is SocketGuildChannel guildChannel)) return;

            var guild = Guild.FindOrCreate.Perform(guildChannel.Guild, db);

            var author = message.Embeds.First().Author.Value;

            var card = ByName.CardsByName(author.Name, guild.Language).First();

            var cards = Views.Card.GetAssociatedCards(card);

            var childCard = cards[Views.Card.Labels.IndexOf(candidate)];

            var view = Views.Card.Response(childCard, guild.DisplaySetting, guild.Language);

            await channel .SendMessageAsync("", embed: view.Item1);
        }
    }
}
