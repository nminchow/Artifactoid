using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artifact.Views.Info
{
    class JoinedGuild
    {
        public static Tuple<string, Embed> Response()
        {
            return new Tuple<string, Embed>("Thanks for adding Artifactoid to your server! Try: `!a help` to get rolling.", null);
        }
    }
}
