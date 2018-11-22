using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artifact.Views.Info
{
    public static class Admin
    {

        public static Tuple<string, Embed> Response(Models.Guild guild)
        {


            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = "Admin Guide"
                },
                Description = "These commands are only callable by admin users.\n\n" +
                "Support Server: https://discord.gg/KxNzKFN \n\n"
            };

            embed.AddField("!a config match {type}", "Toggle the bot's automatic card name detection between three types:\n" +
                "**brackets** - Look for card names between brackets: `I'm going to try [[axe]].`\n" +
                "**singleBracket** - Look for card names between single bracket: `I'm going to try [axe].`\n" +
                "**all** - Look for card names everywhere in messages: `I'm going to try axe.`\n" +
                "**none** - Disable automatic card name matching."
                );
            embed.AddField("!a config display {type}", "Select the display type you would like used when an automatic match is found:\n" +
                "**full** - Display the full card art and the card link.\n" +
                "**link** - Display mini card art and the card link.\n" +
                "**image** - Display the full card art, but do not display the card link.\n" +
                "**mini** - Diplay mini card art and do not display the card link.");
            embed.AddField("!a config language {type}", "Select the language used for matching and display cards.\n" +
                "(use `!a config language` for a list - note that not all languages are fully supported)");
            embed.AddField("Current Settings", $"match: {guild.LookupSetting}\n" +
                $"display: {guild.DisplaySetting}\n" +
                $"language: {guild.Language}");

            return new Tuple<string, Embed>("", embed);
        }
    }
}
