using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Controllers.Settings
{
    class LookupSetting
    {
        public static async Task PerformAsync(SocketCommandContext context, string settingString, DataBase db)
        {
            if(!Enum.TryParse(settingString, out Models.LookupSetting setting))
            {
                await context.Channel.SendMessageAsync("invalid setting");
                return;
            }
            
            var guild = Guild.FindOrCreate.Perform(context.Guild, db);
            guild.LookupSetting = setting;
            db.SaveChanges();
            await context.Channel.SendMessageAsync(text: $"'Card Lookup Matching' set to {setting}");
        }
    }
}
