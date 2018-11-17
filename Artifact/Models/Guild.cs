using System;
using System.Collections.Generic;
using System.Text;

namespace Artifact.Models
{

    public enum LookupSetting { all, brackets, none }
    public enum DisplaySettings { full, link, image, mini }
    public enum LinkTypes { artifactFire,  articraft}
    public enum Languages
    {
        english,
        german,
        french,
        italian,
        koreana,
        spanish,
        schinese,
        tchinese,
        russian,
        thai,
        japanese,
        portuguese,
        polish,
        danish,
        dutch,
        finnish,
        norwegian,
        swedish,
        hungarian,
        czech,
        romanian,
        turkish,
        brazilian,
        bulgarian,
        greek,
        ukrainian,
        latam,
        vietnamese
    }

    public class Guild
    {
        public int ID { get; set; }
        public string DiscordId { get; set; }
        public LookupSetting LookupSetting { get; set; } = LookupSetting.brackets;
        public DisplaySettings DisplaySetting { get; set; } = DisplaySettings.link;
        public Languages Language { get; set; } = Languages.english;
    }
}

