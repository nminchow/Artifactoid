using System;
using System.Collections.Generic;
using System.Text;

namespace Artifact.Models
{

    public enum LookupSetting { all, brackets, none }
    public enum DisplaySettings { full, link, image, mini }
    public enum LinkTypes { artifactFire,  articraft}

    public class Guild
    {
        public int ID { get; set; }
        public string DiscordId { get; set; }
        public LookupSetting LookupSetting { get; set; } = LookupSetting.brackets;
        public DisplaySettings DisplaySetting { get; set; } = DisplaySettings.link;
    }
}

