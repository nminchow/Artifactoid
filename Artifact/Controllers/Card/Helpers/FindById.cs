using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artifact.Controllers.Card.Helpers
{
    class FindById
    {
        public static Models.Card Perform(int id)
        {
            return LoadCards.Instance.cards.FirstOrDefault(x => x.card_id == id);
        }
    }
}
