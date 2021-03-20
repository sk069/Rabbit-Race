using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Race
{
     abstract class Variable
     {
        public static Rabbit[] Rabbit = new Rabbit[4];
        public static Bettor[] RabbitBetter = new Bettor[3];
        public static Random randomSpeed = new Random();
        public static int CurrentBetter { get; set; }
     }
}
