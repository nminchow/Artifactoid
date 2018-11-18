using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Artifact.Models;

namespace Artifact.Views
{
    class Card
    {
        private static string GenerateLink(Models.Card card, LinkTypes linkType)
        {
            var str = new Regex("[^a-zA-Z0-9 -]").Replace(card.card_name.english, "");
            switch (linkType)
            {
                case LinkTypes.artifactFire:
                    return $"https://www.artifactfire.com/artifact/cards/{str.Replace(' ', '-')}";
                case LinkTypes.articraft:
                    return $"https://articraft.io/cards/view/{str.Replace(" ", "")}";
            }
            return "https://playartifact.com/";
        }

        public static string LinkName(LinkTypes linkType)
        {
            switch (linkType)
            {
                case LinkTypes.artifactFire:
                    return "ArtifactFire";
                case LinkTypes.articraft:
                    return "ARTICRAFT";
            }
            return "";
        }

        public static List<Emoji> Labels = new List<Emoji>
        {
            new Emoji("🔹"),
            new Emoji("🔸"),
            new Emoji("▫"),
            new Emoji("▪")
        };

        public static Tuple<Embed, List<Emoji>> Response(Models.Card card, DisplaySettings display, Languages language, LinkTypes linkType = LinkTypes.articraft)
        {

            // Color (default black)
            var color = new Color(115, 110, 128);
            if (card.is_blue)
            {
                color = new Color(47, 116, 146);
            }
            else if (card.is_green)
            {
                color = new Color(71, 144, 54);
            }
            else if (card.is_red)
            {
                color = new Color(194, 53, 45);
            }
            else if (card.card_type == "Item")
            {
                color = new Color(220, 175, 78);
            }

            var webLink = GenerateLink(card, linkType);

            var description = card.card_text.InLanguage(language);


            if (string.IsNullOrEmpty(description) && card.references.Any(x => x.ref_type == "passive_ability"))
            {
                var reference = card.references.First(x => x.ref_type == "passive_ability");
                var supplemental_card = Controllers.Card.Helpers.FindById.Perform(reference.card_id);
                description = $"{supplemental_card.card_name.InLanguage(language)}\n{supplemental_card.card_text.InLanguage(language)}";
            }

            description = string.IsNullOrWhiteSpace(description) ? "-" : $"{description}\n";
            List<Tuple<Models.Card, string>> associatedCards = GetAssociatedCards(card);

            var labels = new Queue<Emoji>(Labels);
            var usedLabels = new List<Emoji>();
            foreach (Tuple<Models.Card, string> x in associatedCards)
            {
                usedLabels.Add(labels.Peek());
                var refCard = x.Item1;
                var preText = x.Item2 == "includes" ? "Includes " : "";
                var refDescription = GetRefDescription(x, language);
                description += $"\n**{labels.Dequeue()}{preText}[{refCard.card_name.InLanguage(language)}]({GenerateLink(refCard, linkType)})**{refDescription}";
            }

            description = Regex.Replace(description, "<br/>", "\n");

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = card.card_name.InLanguage(language),
                    Url = webLink,
                    IconUrl = card.mini_image.def
                },
                //ThumbnailUrl = card.large_image.def,
                Color = color,
                Description = Regex.Replace(description, "<.*?>", string.Empty)
            };

            if (new[] { Models.DisplaySettings.full, Models.DisplaySettings.image }.Contains(display))
            {
                embed.ImageUrl = card.large_image.InLanguage(language);
            }
            else
            {
                embed.ThumbnailUrl = card.large_image.InLanguage(language);
            }

            var lastField = card.rarity ?? "No Rarity";

            if (new[] { Models.DisplaySettings.full, Models.DisplaySettings.link }.Contains(display))
            {
                lastField += $"\n[{LinkName(linkType)}]({webLink})";
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

            return new Tuple<Embed, List<Emoji>>(embed, usedLabels);
        }

        public static List<Tuple<Models.Card, string>> GetAssociatedCards(Models.Card card)
        {
            var matches = new[] { "includes", "references", "active_ability", "passive_ability" };
            return card.references.Where(x =>
                matches.Contains(x.ref_type)
            ).Select(x => 
                new Tuple<Models.Card, string>(Controllers.Card.Helpers.FindById.Perform(x.card_id), x.ref_type)
            ).ToList();
        }

        public static string GetRefDescription(Tuple<Models.Card, string> referece, Languages language)
        {
            var refCard = referece.Item1;
            if (referece.Item2 == "active_ability" || referece.Item2 == "passive_ability")
                return "";

            var refText = refCard.card_text.InLanguage(language).Contains("\n") ? $"\n{refCard.card_text.InLanguage(language)}" : refCard.card_text.InLanguage(language);
            return $": {refText}";

        }
    }
}
