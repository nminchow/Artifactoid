using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artifact.Views.Info
{
    public static class Help
    {

        public static Tuple<string, Embed> Response(Models.LookupSetting setting)
        {
            var lookupText = "";
            switch (setting)
            {
                case Models.LookupSetting.all:
                    lookupText = "Any card names detected within messages in this server will have the relevant card data posted, ex:\n" +
                        "`I'm going to try axe.`\n Automatic card name detection is configurable - see: `!d config`";
                    break;
                case Models.LookupSetting.brackets:
                    lookupText = "Any card names surrouneded by `[[` and `]]` will have the relevant card data posted, ex:\n" +
                        "`I'm going to try [[axe]].`\n Automatic card name detection is configurable - see: `!d config`";
                    break;
                case Models.LookupSetting.none:
                    lookupText = "To get more info about a card, use the `!c` command show below." +
                        "Automatic card name detection is configurable - see: `!d config`.";
                    break;
            }

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    Name = "Guide"
                },
                Description = "Artifactoid shows artifact card data within your discord channels.\n\n" +
                lookupText +
                "\n\n Support Server: https://discord.gg/KxNzKFN \n\n" +
                "**Additional Commands:**",
            };

            embed.AddField("!c {card name}", "Perform a lookup by card name." +
                $"\nex: `!c Axe`");
            embed.AddField("!a config", "Get a list of admin only configuration commands.");
            embed.AddField("!a help", "Display this help dialogue.");

            return new Tuple<string, Embed>("", embed);
        }
    }
}
