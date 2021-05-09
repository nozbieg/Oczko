using Oczko.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oczko.Core
{
    public class Deck
    {
        public Deck()
        {
            Cards = GetCards();
        }

        public IList<Card> Cards { get; set; }

        public IList<Card> GetCards()
        {           
            List<Card> cards = new List<Card>();
            foreach(var type in (CardType[])Enum.GetValues(typeof(CardType)))
            {
                foreach (var colour in (CardColour[])Enum.GetValues(typeof(CardColour)))
                {
                    var card = new Card(type, colour);
                    cards.Add(card);
                }
            }
            return cards;
        }
    }
}
