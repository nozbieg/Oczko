using Oczko.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oczko.Core
{
    public class Card
    {
        public Card() { }
        public Card(CardType cardType, CardColour cardColour)
        {
            CardType = cardType;
            CardColour = cardColour;
            CardValue = GetCardValue(CardType);
        }

        public CardType CardType { get; set; }
        public CardColour CardColour { get; set; }
        public int CardValue { get; set; }

        private int GetCardValue(CardType cardType)
        {
            var val = 0;
            switch (cardType)
            {
                case CardType.Ace:
                    val= 11;
                    break;

                case CardType.King:
                    val = 4;
                    break;

                case CardType.Queen:
                    val = 3;
                    break;

                case CardType.Jack:
                    val = 2;
                    break;

                case CardType.Ten:
                    val = 10;
                    break;

                case CardType.Nine:
                    val = 9;
                    break;

                case CardType.Eigth:
                    val = 8;
                    break;

                case CardType.Seven:
                    val = 7;
                    break;

                case CardType.Six:
                    val = 6;
                    break;

                case CardType.Five:
                    val = 5;
                    break;

                case CardType.Four:
                    val = 4;
                    break;

                case CardType.Three:
                    val = 3;
                    break;

                case CardType.Two:
                    val = 2;
                    break;
            }
            return val;
        }
    }
}
