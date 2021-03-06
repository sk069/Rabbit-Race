using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabbit_Race
{
    //This is a class which has fields of images, race start position and track lenght//
    public class Greyhound
    {
        public int positionToStart { get; set; }
        public int positionToFinish { get; set; }
        public PictureBox RabbitImage { get; set; }
        private Random randomSpeed = new Random();

        public bool Run()
        {
            Point CurrentCoordinates = RabbitImage.Location;
            CurrentCoordinates.X += randomSpeed.Next(1, 6);
            RabbitImage.Location = CurrentCoordinates;
            if (CurrentCoordinates.X >= positionToFinish)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveRabbitsToStart()
        {
            RabbitImage.Left = positionToStart;
        }

        internal void MoveRabbitToStart()
        {
            throw new NotImplementedException();
        }
    }
}
