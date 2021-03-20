using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Race
{
    public class Bet : Rabbit
    {
        public int betBalance { get; set; }
        public Bettor betPlacer { get; set; }
        public int betRabbit { get; set; }

        public int CashOut(int Winner)
        {
            if (Winner == betRabbit)
            {
                return betBalance * 4;
            }
            else
            {
                return (0 - betBalance);
            }
        }
    }
}
