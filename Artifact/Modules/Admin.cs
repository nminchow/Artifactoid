using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Modules
{
    public class Admin : ModuleBase<SocketCommandContext>
    {
        private DataBase _database;

        public Admin(DataBase database)
        {
            _database = database;
        }

        [Command("a config match", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task LookupSetting([Remainder] string message)
        {
            await Controllers.Settings.LookupSetting.PerformAsync(Context, message, _database);
        }

        [Command("a config display", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SetDisplay([Remainder] string message)
        {
            await Controllers.Settings.DisplaySetting.PerformAsync(Context, message, _database);
        }
    }
}
