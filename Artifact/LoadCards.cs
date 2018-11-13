using Artifact.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Artifact
{
    public sealed class LoadCards
    {
        private static readonly Lazy<LoadCards> lazy =
            new Lazy<LoadCards>(() => new LoadCards());

        public static LoadCards Instance { get { return lazy.Value; } }

        public Card_Set[] sets;

        public List<Card> cards;

        private LoadCards()
        {
            sets = new Card_Set[2];
            for (int i = 0; i < sets.Length; i++)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "RawSets", $"set_{i}.json");
                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var root = (CardRoot)serializer.Deserialize(file, typeof(CardRoot));
                    sets[i] = root.card_set;
                }
            }

            cards = sets.Select(x => x.card_list).Aggregate(new List<Card>(), (acc, obj) => acc.Concat(obj).ToList());
        }
    }
}
