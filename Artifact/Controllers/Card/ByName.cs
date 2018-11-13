using Artifact.Models;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Artifact.Controllers.Card
{
    class ByName
    {
        public static async Task PerformAsync(SocketCommandContext context, string name)
        {
            IEnumerable<Models.Card> hits = CardsByName(name);
            await Helpers.SendCards.PerformAsync(context, hits, DisplaySettings.full);
            return;
        }

        public static IEnumerable<Models.Card> CardsByName(string name)
        {
            return LoadCards.Instance.cards.Where(x => x.card_name.english.ToLower() == name.ToLower());
        }
    }
}
