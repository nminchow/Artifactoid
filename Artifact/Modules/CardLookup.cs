using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Modules
{
    public class Messages : ModuleBase<SocketCommandContext>
    {
        [Command("c", RunMode = RunMode.Async)]
        public async Task Card([Remainder] string message)
        {
            await Controllers.Card.ByName.PerformAsync(Context, message);
        }
    }
}
