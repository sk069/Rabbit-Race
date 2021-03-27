using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabbit_Race
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int StartRace = Joe.Left;
            int RaceTrackLength = pictureBox1.Width - Rabbit1.Right;

            Factory.Rabbit[0] = new Greyhound() { RabbitImage = Rabbit1, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Factory.Rabbit[1] = new Greyhound() { RabbitImage = Rabbit2, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Factory.Rabbit[2] = new Greyhound() { RabbitImage = Rabbit3, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Factory.Rabbit[3] = new Greyhound() { RabbitImage = Rabbit4, positionToFinish = RaceTrackLength, positionToStart = StartRace };


            Factory.RabbitBetter[0] = new Punter() { PocketCash = 50, activityIndicator = Joe, selectedBetter = radioButton1, title = "Player 1" };
            Factory.RabbitBetter[1] = new Punter() { PocketCash = 50, activityIndicator = Bob, selectedBetter = radioButton2, title = "Player 2" };
            Factory.RabbitBetter[2] = new Punter() { PocketCash = 50, activityIndicator = Al, selectedBetter = radioButton3, title = "Player 3" };

            //  the code is Sets the default values to the labels
            Factory.RabbitBetter[0].ActivityLabelUpdator();
            Factory.RabbitBetter[1].ActivityLabelUpdator();
            Factory.RabbitBetter[2].ActivityLabelUpdator();
            Factory.RabbitBetter[0].ResetBettingHistory();
            Factory.RabbitBetter[1].ResetBettingHistory();
            Factory.RabbitBetter[2].ResetBettingHistory();
        }
        //Place bet button code
        private void button1_Click(object sender, EventArgs e)
        {

            Factory.RabbitBetter[Factory.CurrentBetter].Betting((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Factory.RabbitBetter[Factory.CurrentBetter].ActivityLabelUpdator();
        }

        //Start race button code
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button2.Enabled = false;


        }
        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
         // code to call the start race button//
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < Factory.Rabbit.Length; i++)
            {
                Factory.Rabbit[Factory.randomSpeed.Next(0, 4)].Run();
                if (Factory.Rabbit[i].Run())
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    button2.Enabled = true;
                    DeclarTheWinner(i + 1);
                }
            }
        }

        private void MoveRabbits()
        {
            Factory.Rabbit[0].MoveRabbitsToStart();
            Factory.Rabbit[1].MoveRabbitsToStart();
            Factory.Rabbit[2].MoveRabbitsToStart();
            Factory.Rabbit[3].MoveRabbitsToStart();

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Factory.CurrentBetter = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Factory.CurrentBetter = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Factory.CurrentBetter = 2;
        }

  
        //Code for reset bids
            private void ResetBids()
            {
                Joe.Text = "Player 1 hasn't placed a bet.";
                Bob.Text = "Player 2 hasn't placed a bet.";
                Al.Text = "Player 3 hasn't placed a bet.";
            }

        //code for declair winner in race
            private void DeclarTheWinner(int Winner)
            {
                MessageBox.Show("Rabbit #" + Winner + " is the Winning Rabbit");
                for (int i = 0; i < Factory.RabbitBetter.Length; i++)
                {
                    Factory.RabbitBetter[i].CollectWinnings(Winner);
                    Factory.RabbitBetter[i].ActivityLabelUpdator();
                    MoveRabbits();
                    ResetBids();
                }
            }

        
    }
}







       