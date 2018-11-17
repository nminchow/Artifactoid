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
    class DeckLinks
    {
        private const string prefix = "ADC";

        public static async Task PerformAsync(SocketCommandContext context, DataBase db)
        { 
            var message = context.Message.Content;
            if (message.Contains(prefix) && !message.Contains("http"))
            {
                // first word that ends after prefix
                var candidateWord = message.Substring(message.IndexOf(prefix)).Split(' ')[0];
                // everything before the last underscore
                var candidate = candidateWord.Substring(0, candidateWord.LastIndexOf('_') + 1);
                // todo: figure out the actual params on this
                if (candidate.Length > 50 && candidate.Length < 100)
                {
                    await context.Channel.SendMessageAsync($"Deck link detected!\nhttps://playartifact.com/d/{candidate}");
                }
            }
            return;

        }
    }
}
