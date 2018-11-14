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
        private static string GenerateLink(Models.Card card)
        {
            var str = new Regex("[^a-zA-Z0-9 -]").Replace(card.card_name.english, "");
            // replace space with dash and create link
            return $"https://www.artifactfire.com/artifact/cards/{str.Replace(' ', '-')}";
        }

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


            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            // remove special characters
            var str = rgx.Replace(card.card_name.english, "");
            // replace space with dash and create link
            var artifactFireLink = $"https://www.artifactfire.com/artifact/cards/{str.Replace(' ', '-')}";

            artifactFireLink = GenerateLink(card);

            var description = card.card_text.english;

            if (string.IsNullOrEmpty(description) && card.references.Any(x => x.ref_type == "passive_ability"))
            {
                var reference = card.references.First(x => x.ref_type == "passive_ability");
                var supplemental_card = Controllers.Card.Helpers.FindById.Perform(reference.card_id);
                description = $"{supplemental_card.card_name.english}\n{supplemental_card.card_text.english}";
            }

            description = description ?? "-";

            card.references.Where(x => x.ref_type == "includes").Select(x =>
                Controllers.Card.Helpers.FindById.Perform(x.card_id)
            ).ToList().ForEach(x =>
                description += $"\n\n**[{x.card_name.english}]({GenerateLink(x)})**: {x.card_text.english}"
            );

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = card.card_name.english,
                    Url = artifactFireLink,
                    IconUrl = card.mini_image.def
                },
                //ThumbnailUrl = card.large_image.def,
                Color = color,
                Description = Regex.Replace(description, "<.*?>", string.Empty)
            };

            if (new[] { Models.DisplaySettings.full, Models.DisplaySettings.image }.Contains(display))
            {
                embed.ImageUrl = card.large_image.def;
            } else
            {
                embed.ThumbnailUrl = card.large_image.def;
            }

            var lastField = card.rarity;

            if (new[] { Models.DisplaySettings.full, Models.DisplaySettings.fire }.Contains(display))
            {
                lastField += $"\n[ArtifactFire]({artifactFireLink})";
            }


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
