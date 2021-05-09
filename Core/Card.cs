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
        public CardType CardType { get; set; }
        public CardColour CardColour { get; set; }
        public int CardValue { get; set; }
    }
}
