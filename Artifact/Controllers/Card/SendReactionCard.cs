using Artifact.Models;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Controllers.Card
{
    class SendReactionCard
    {
        public static async Task PerformAsync(Discord.WebSocket.ISocketMessageChannel channel, Discord.IUserMessage message, Discord.Emoji candidate)
        {
            var author = message.Embeds.First().Author.Value;

            var card = Controllers.Card.ByName.CardsByName(author.Name).First();

            var cards = Views.Card.GetAssociatedCards(card);

            var childCard = cards[Views.Card.Labels.IndexOf(candidate)];

            var view = Views.Card.Response(childCard, DisplaySettings.full);

            await channel.SendMessageAsync("", embed: view.Item1);
        }
    }
}
