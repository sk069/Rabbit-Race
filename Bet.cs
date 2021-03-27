using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Race
{
    public class Bet : Greyhound
    {
        //This is a class which has code for betting and fields of betting//
        public int betBalance { get; set; }
        public Punter betPlacer { get; set; }
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
