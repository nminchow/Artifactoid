using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Artifact.Views
{
    class Card
    {
        public static Tuple<string, Embed> Response(Models.Card card, Models.DisplaySettings display)
        {
            // Color (default black)
            var color = new Color(115, 110, 128);
            if(card.is_blue)
            {
                color = new Color(47, 116, 146);
            }
            else if(card.is_green)
            {
                color = new Color(71, 144, 54);
            }
            else if(card.is_red)
            {
                color = new Color(194, 53, 45);
            }
            else if(card.card_type == "Item")
            {
                color = new Color(220, 175, 78);
            }

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = card.card_name.english
                },
                ThumbnailUrl = card.mini_image.def,
                Color = color,
                Description = Regex.Replace(card.card_text.english ?? "-", "<.*?>", string.Empty)
            };

            if (new[] { Models.DisplaySettings.full, Models.DisplaySettings.image }.Contains(display))
            {
                embed.ImageUrl = card.large_image.def;
            }


            var artifactFireLink = "";

            if (new[] { Models.DisplaySettings.full, Models.DisplaySettings.fire }.Contains(display))
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                // remove special characters
                var str = rgx.Replace(card.card_name.english, "");
                // replace space with dash and create link
                artifactFireLink = $"\n[ArtifactFire](https://www.artifactfire.com/artifact/cards/{str.Replace(' ', '-')})";
            }

            var lastField = $"{card.rarity}{artifactFireLink}";

            switch (card.card_type)
            {
                case "Hero":
                case "Creep":
                    embed.AddField($"{card.attack}/{card.armor}/{card.hit_points}", card.card_type);
                    embed.AddField($"Mana Cost: {card.mana_cost}", lastField);
                    break;
                case "Item":
                    embed.AddField("Item", card.sub_type ?? "*no type*");
                    embed.AddField($"Gold Cost: {card.gold_cost}", lastField);
                    break;
                // spells, improvements, and creeps
                default:
                    embed.AddField(card.card_type, "-");
                    embed.AddField($"Mana Cost: {card.mana_cost}", lastField);
                    break;
            }

            return new Tuple<string, Embed>("", embed);
        }
    }
}
