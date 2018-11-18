using Artifact.Models;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks; 

namespace Artifact.Controllers.Card
{
    class TextScan
    {
        public static async Task PerformAsync(SocketCommandContext context, DataBase db)
        {
            var regex = new Regex(@"[^\p{L}\[\] ]");
            var guild = Guild.FindOrCreate.Perform(context.Guild, db);
            var message = regex.Replace(context.Message.Content.ToLower(), "");
            var hits = new List<Models.Card>();

            switch (guild.LookupSetting)
            {
                case LookupSetting.none:
                    break;
                case LookupSetting.all:
                    hits = LoadCards.Instance.cards.Where(x => message.Contains(replace(regex, x, guild.Language))).ToList();
                    break;
                case LookupSetting.brackets:
                    // this could be cleaner with some substring logic
                    hits = LoadCards.Instance.cards.Where(x => message.Contains($"[[{replace(regex, x, guild.Language)}]]")).ToList();
                    break;
            }

            hits = hits.Where(x => x.card_type != "Ability").ToList();

            if(hits.Any()) Console.WriteLine("processed message!");

            await Helpers.SendCards.PerformAsync(context.Channel, hits, guild.DisplaySetting, guild.Language);

            await DeckLinks.PerformAsync(context, db);

            return;

        }

        public static string replace(Regex regex, Models.Card card, Languages language)
        {
            return regex.Replace(card.card_name.InLanguage(language).ToLower(), "");
        }
    }
}
