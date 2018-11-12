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

    public class Name
    {
        public string english { get; set; }
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

    public class Card_Name
    {
        public string english { get; set; }
    }

    public class Card_Text
    {
        public string english { get; set; }
    }

    public class Mini_Image
    {
        public string def { get; set; }
    }

    public class Large_Image
    {
        public string def { get; set; }
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
