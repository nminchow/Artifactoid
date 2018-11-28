using Artifact.Models;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Controllers.Card
{
    class SendReactionCard
    {
        public static async Task PerformAsync(ISocketMessageChannel channel, Discord.IUserMessage message, Discord.Emoji candidate, DataBase db)
        {
            if (!(channel is SocketGuildChannel guildChannel)) return;

            var guild = Guild.FindOrCreate.Perform(guildChannel.Guild, db);

            var author = message.Embeds.First().Author.Value;

            var description = message.Embeds.First().Fields.Last().Value;

            var id = Convert.ToInt32(description.Substring(description.IndexOf('#')+1).Split("\n")[0]);

            var card = Helpers.FindById.Perform(id);

            var cards = Views.Card.GetAssociatedCards(card);

            var childCard = cards[Views.Card.Labels.IndexOf(candidate)];

            await Helpers.SendCards.PerformAsync(channel, new Models.Card[] { childCard.Item1 }, guild.DisplaySetting, guild.Language);
        }
    }
}
