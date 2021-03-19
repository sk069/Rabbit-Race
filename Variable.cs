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
        public static Bettor[] RabbitGambler = new Bettor[3];
        public static Random randomSpeed = new Random();
        public static int CurrentGambler { get; set; }
     }
}
