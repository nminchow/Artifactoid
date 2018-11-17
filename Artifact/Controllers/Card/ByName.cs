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
        public static async Task PerformAsync(SocketCommandContext context, string name, DataBase db)
        {
            var guild = Guild.FindOrCreate.Perform(context.Guild, db);
            IEnumerable<Models.Card> hits = CardsByName(name, guild.Language);
            await Helpers.SendCards.PerformAsync(context, hits, guild.DisplaySetting, guild.Language);
            return;
        }

        public static IEnumerable<Models.Card> CardsByName(string name, Languages language)
        {
            return LoadCards.Instance.cards.Where(x => x.card_name.InLanguage(language).ToLower() == name.ToLower());
        }
    }
}
