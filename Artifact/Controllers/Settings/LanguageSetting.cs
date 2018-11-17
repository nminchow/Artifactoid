using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Controllers.Settings
{
    class LanguageSetting
    {
        public static async Task PerformAsync(SocketCommandContext context, string settingString, DataBase db)
        {
            if(!Enum.TryParse(settingString, out Models.Languages setting))
            {
                await context.Channel.SendMessageAsync("invalid setting");
                return;
            }
            
            var guild = Guild.FindOrCreate.Perform(context.Guild, db);
            guild.Language = setting;
            db.SaveChanges();
            await context.Channel.SendMessageAsync(text: $"'Language' set to {setting}");
        }
    }
}
