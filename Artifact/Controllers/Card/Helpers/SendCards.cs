using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Controllers.Card.Helpers
{
    class SendCards
    {
        public static async Task PerformAsync(SocketCommandContext context, IEnumerable<Models.Card> cards, Models.DisplaySettings display)
        {
            var messages = cards.Select(x =>
                Views.Card.Response(x, display)
            ).Select(x =>
                context.Channel.SendMessageAsync(x.Item1, embed: x.Item2)
            );

            await Task.WhenAll(messages);
            return;
        }
    }
}
