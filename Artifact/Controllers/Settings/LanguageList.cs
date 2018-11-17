using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Controllers.Settings
{
    class LanguageList
    {
        public static async Task PerformAsync(SocketCommandContext context)
        {
            var message = Enum.GetNames(typeof(Models.Languages)).Select(x => $"{x}\n").Aggregate("Language Options:\n", (total, current) => total + current);

            await context.Channel.SendMessageAsync(text: message);
        }
    }
}
