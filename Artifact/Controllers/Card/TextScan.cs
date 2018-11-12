using Artifact.Models;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Artifact.Controllers.Card
{
    class TextScan
    {
        public static async Task PerformAsync(SocketCommandContext context, DataBase db)
        {
            var guild = Guild.FindOrCreate.Perform(context.Guild, db);
            var message = context.Message.Content.ToLower();
            var hits = new List<Models.Card>();

            switch (guild.LookupSetting)
            {
                case LookupSetting.none:
                    break;
                case LookupSetting.all:
                    hits = LoadCards.Instance.cards.Where(x => message.Contains(x.card_name.english.ToLower())).ToList();
                    break;
                case LookupSetting.brackets:
                    // this could be cleaner with some substring logic
                    hits = LoadCards.Instance.cards.Where(x => message.Contains($"[[{x.card_name.english.ToLower()}]]")).ToList();
                    break;
            }
            await Helpers.SendCards.PerformAsync(context, hits, guild.DisplaySetting);

            return;

        }
    }
}
