using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Race
{
     abstract class Factory
     {
        public static Greyhound[] Rabbit = new Greyhound[4];
        public static Punter[] RabbitBetter = new Punter[3];
        public static Random randomSpeed = new Random();
        public static int CurrentBetter { get; set; }
     }
}
