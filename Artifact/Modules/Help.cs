using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        private DataBase _database;

        public Help(DataBase database)
        {
            _database = database;
        }

        [Command("a config", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task AdminHelp()
        {
            var guild = Controllers.Guild.FindOrCreate.Perform(Context.Guild, _database);
            var view = Views.Info.Admin.Response(guild);
            await Context.Channel.SendMessageAsync(view.Item1, embed: view.Item2);
        }

        [Command("a help", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task GeneralHelp()
        {
            var guild = Controllers.Guild.FindOrCreate.Perform(Context.Guild, _database);
            var view = Views.Info.Help.Response(guild.LookupSetting);
            await Context.Channel.SendMessageAsync(view.Item1, embed: view.Item2);
        }
    }
}
