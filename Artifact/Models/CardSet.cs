using Artifact.Models.CardInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artifact.Models
{

    public class CardRoot
    {
        public Card_Set card_set { get; set; }
    }

    public class Card_Set
    {
        public int version { get; set; }
        public Set_Info set_info { get; set; }
        public Card[] card_list { get; set; }
    }

    public class Set_Info
    {
        public int set_id { get; set; }
        public int pack_item_def { get; set; }
        public Name name { get; set; }
    }

    public class Name : ILanguageable
    {
        public string english { get; set; }
        public string german { get; set; }
        public string french { get; set; }
        public string italian { get; set; }
        public string koreana { get; set; }
        public string spanish { get; set; }
        public string schinese { get; set; }
        public string tchinese { get; set; }
        public string russian { get; set; }
        public string thai { get; set; }
        public string japanese { get; set; }
        public string portuguese { get; set; }
        public string polish { get; set; }
        public string danish { get; set; }
        public string dutch { get; set; }
        public string finnish { get; set; }
        public string norwegian { get; set; }
        public string swedish { get; set; }
        public string hungarian { get; set; }
        public string czech { get; set; }
        public string romanian { get; set; }
        public string turkish { get; set; }
        public string brazilian { get; set; }
        public string bulgarian { get; set; }
        public string greek { get; set; }
        public string ukrainian { get; set; }
        public string latam { get; set; }
        public string vietnamese { get; set; }

        public string InLanguage(Languages language)
        {
            return Methods.InLanguage(language, this);
        }
    }

    public class Card
    {
        public int card_id { get; set; }
        public int base_card_id { get; set; }
        public string card_type { get; set; }
        public Card_Name card_name { get; set; }
        public Card_Text card_text { get; set; }
        public Mini_Image mini_image { get; set; }
        public Large_Image large_image { get; set; }
        public Ingame_Image ingame_image { get; set; }
        public int hit_points { get; set; }
        public Reference[] references { get; set; }
        public string illustrator { get; set; }
        public string rarity { get; set; }
        public int mana_cost { get; set; }
        public int attack { get; set; }
        public bool is_black { get; set; }
        public string sub_type { get; set; }
        public int gold_cost { get; set; }
        public bool is_green { get; set; }
        public bool is_red { get; set; }
        public int armor { get; set; }
        public bool is_blue { get; set; }
    }

    public class Card_Name : ILanguageable
    {
        public string english { get; set; }
        public string german { get; set; }
        public string french { get; set; }
        public string italian { get; set; }
        public string koreana { get; set; }
        public string spanish { get; set; }
        public string schinese { get; set; }
        public string tchinese { get; set; }
        public string russian { get; set; }
        public string thai { get; set; }
        public string japanese { get; set; }
        public string portuguese { get; set; }
        public string polish { get; set; }
        public string danish { get; set; }
        public string dutch { get; set; }
        public string finnish { get; set; }
        public string norwegian { get; set; }
        public string swedish { get; set; }
        public string hungarian { get; set; }
        public string czech { get; set; }
        public string romanian { get; set; }
        public string turkish { get; set; }
        public string brazilian { get; set; }
        public string bulgarian { get; set; }
        public string greek { get; set; }
        public string ukrainian { get; set; }
        public string latam { get; set; }
        public string vietnamese { get; set; }

        public string InLanguage(Languages language)
        {
            return Methods.InLanguage(language, this);
        }
    }

    public class Card_Text : ILanguageable
    {
        public string english { get; set; }
        public string german { get; set; }
        public string french { get; set; }
        public string italian { get; set; }
        public string koreana { get; set; }
        public string spanish { get; set; }
        public string schinese { get; set; }
        public string tchinese { get; set; }
        public string russian { get; set; }
        public string thai { get; set; }
        public string japanese { get; set; }
        public string portuguese { get; set; }
        public string polish { get; set; }
        public string danish { get; set; }
        public string dutch { get; set; }
        public string finnish { get; set; }
        public string norwegian { get; set; }
        public string swedish { get; set; }
        public string hungarian { get; set; }
        public string czech { get; set; }
        public string romanian { get; set; }
        public string turkish { get; set; }
        public string brazilian { get; set; }
        public string bulgarian { get; set; }
        public string greek { get; set; }
        public string ukrainian { get; set; }
        public string latam { get; set; }
        public string vietnamese { get; set; }

        public string InLanguage(Languages language)
        {
            return Methods.InLanguage(language, this);
        }
    }

    public class Mini_Image
    {
        public string def { get; set; }
    }

    public class Large_Image : ILanguageable
    {
        public string def { get; set; }
        public string german { get; set; }
        public string french { get; set; }
        public string italian { get; set; }
        public string koreana { get; set; }
        public string spanish { get; set; }
        public string schinese { get; set; }
        public string tchinese { get; set; }
        public string russian { get; set; }
        public string japanese { get; set; }
        public string brazilian { get; set; }
        public string latam { get; set; }
        public string english { get => def; set { } }
        public string thai { get => def; set { } }
        public string portuguese { get => def; set { } }
        public string polish { get => def; set { } }
        public string danish { get => def; set { } }
        public string dutch { get => def; set { } }
        public string finnish { get => def; set { } }
        public string norwegian { get => def; set { } }
        public string swedish { get => def; set { } }
        public string hungarian { get => def; set { } }
        public string czech { get => def; set { } }
        public string romanian { get => def; set { } }
        public string turkish { get => def; set { } }
        public string bulgarian { get => def; set { } }
        public string greek { get => def; set { } }
        public string ukrainian { get => def; set { } }
        public string vietnamese { get => def; set { } }

        public string InLanguage(Languages language)
        {
            return Methods.InLanguage(language, this);
        }
    }

    public class Ingame_Image
    {
        public string def { get; set; }
    }

    public class Reference
    {
        public int card_id { get; set; }
        public string ref_type { get; set; }
        public int count { get; set; }
    }

}
