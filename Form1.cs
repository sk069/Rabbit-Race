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
            int RaceTrackLength = pictureBox1.Width - Joe.Right;

            Variable.Rabbit[0] = new Rabbit() { RabbitImage = Rabbit1, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variable.Rabbit[1] = new Rabbit() { RabbitImage = Rabbit2, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variable.Rabbit[2] = new Rabbit() { RabbitImage = Rabbit3, positionToFinish = RaceTrackLength, positionToStart = StartRace };


            Variable.RabbitGambler[0] = new Bettor() { PocketCash = 65, activityIndicator = Joe, selectedGambler = radioButton1, title = "Joe" };
            Variable.RabbitGambler[1] = new Bettor() { PocketCash = 75, activityIndicator = Bob, selectedGambler = radioButton2, title = "Bob" };
            Variable.RabbitGambler[2] = new Bettor() { PocketCash = 55, activityIndicator = Al, selectedGambler = radioButton3, title = "Al" };

            // Sets the default values to the labels
            Variable.RabbitGambler[0].ActivityLabelUpdator();
            Variable.RabbitGambler[1].ActivityLabelUpdator();
            Variable.RabbitGambler[2].ActivityLabelUpdator();
            Variable.RabbitGambler[0].ResetBettingHistory();
            Variable.RabbitGambler[1].ResetBettingHistory();
            Variable.RabbitGambler[2].ResetBettingHistory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        


            private void MoveRabbits()
            {
                Variable.Rabbit[0].MoveRabbitsToStart();
                Variable.Rabbit[1].MoveRabbitsToStart();
                Variable.Rabbit[2].MoveRabbitsToStart();
               
            }

            private void ResetBids()
            {
                Joe.Text = "Player 1 hasn't placed a bet.";
                Bob.Text = "Player 2 hasn't placed a bet.";
                Al.Text = "Player 3 hasn't placed a bet.";
            }

            private void DeclarTheWinner(int Winner)
            {
                MessageBox.Show("Rabbit #" + Winner + " is the Winning Rabbit");
                for (int i = 0; i < Variable.RabbitGambler.Length; i++)
                {
                    Variable.RabbitGambler[i].CollectWinnings(Winner);
                    Variable.RabbitGambler[i].ActivityLabelUpdator();
                    MoveRabbits();
                    ResetBids();
                }
            }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < Variable.Rabbit.Length; i++)
            {
                Variable.Rabbit[Variable.randomSpeed.Next(0, 4)].Fly();
                if (Variable.Rabbit[i].Fly())
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    button2.Enabled = false;
                    DeclarTheWinner(i + 1);
                }
            }
        }
    }
}







       