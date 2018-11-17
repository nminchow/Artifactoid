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
            var cardViews = cards.Select(x => Views.Card.Response(x, display));

            var messages = cardViews.Select(x =>
                SendCardAndReactions(x.Item2, x.Item1, context)
            );

            await Task.WhenAll(messages);

            return;
        }

        public static async Task SendCardAndReactions(List<Discord.Emoji> reactions, Discord.Embed embed, SocketCommandContext context)
        {
            var message = await context.Channel.SendMessageAsync("", embed: embed);
            var reacionResults = reactions.Select(x =>
                message.AddReactionAsync(x)
            );
            await Task.WhenAll(reacionResults);
            return;
        }
    }
}
