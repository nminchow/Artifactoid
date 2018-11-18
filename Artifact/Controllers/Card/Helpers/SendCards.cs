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
        public static async Task PerformAsync(Discord.WebSocket.ISocketMessageChannel channel, IEnumerable<Models.Card> cards, Models.DisplaySettings display, Models.Languages language)
        {
            var cardViews = cards.Select(x => Views.Card.Response(x, display, language));

            var messages = cardViews.Select(x =>
                SendCardAndReactions(x.Item2, x.Item1, channel)
            );

            await Task.WhenAll(messages);

            return;
        }

        public static async Task SendCardAndReactions(List<Discord.Emoji> reactions, Discord.Embed embed, Discord.WebSocket.ISocketMessageChannel channel)
        {
            var message = await channel.SendMessageAsync("", embed: embed);
            // loop itself is async so we get them in the right order
            var reacionResults = reactions.Select(async x =>
                await message.AddReactionAsync(x)
            );
            await Task.WhenAll(reacionResults);
            return;
        }
    }
}
