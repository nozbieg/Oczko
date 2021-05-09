using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oczko.Core.Enums
{
    public class Deck
    {
        public Deck()
        {
            GetCards();
        }

        public IList<Card> Cards { get; set; }

        public IList<Card> GetCards()
        {
            List<Card> cards = new List<Card>();


            return cards;
        }
    }
}
