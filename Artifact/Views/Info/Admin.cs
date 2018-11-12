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
                ThumbnailUrl = "https://nminchow.github.io/VoltaireWeb/images/quill.png",
                Description = "These commands are only callable by admin users.\n\n" +
                "Support Server: https://discord.gg/ \n\n"
            };

            embed.AddField("!config match {type}", "Toggle the bot's automatic card name detection between three types:\n" +
                "**brackets** - Look for card names between brackets: `I'm going to try [[axe]].`\n" +
                "**all** - Look for card names everywhere in messages: `I'm going to try axe.`\n" +
                "**none** - Disable automatic card name matching."
                );
            embed.AddField("!config display {type}", "Select the display type you would like used when an automatic match is found:\n" +
                "**full** - Display the full card art and the ArtifactFire card link.\n" +
                "**fire** - Do not display card art, but do display the ArtifactFire card link.\n" +
                "**image** - Display the full card art, but do not display the ArtifactFire card link.\n" +
                "**mini** - Do not display the card art nor the ArtifactFire card link.");
            embed.AddField("Current Settings", $"match: {guild.LookupSetting}\ndisplay: {guild.DisplaySetting}");

            return new Tuple<string, Embed>("", embed);
        }
    }
}
