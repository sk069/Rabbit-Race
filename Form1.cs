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

            Variable.Rabbit[0] = new Rabbit() { RabbitImage = Rabbit1, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variable.Rabbit[1] = new Rabbit() { RabbitImage = Rabbit2, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variable.Rabbit[2] = new Rabbit() { RabbitImage = Rabbit3, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variable.Rabbit[3] = new Rabbit() { RabbitImage = Rabbit4, positionToFinish = RaceTrackLength, positionToStart = StartRace };


            Variable.RabbitBetter[0] = new Bettor() { PocketCash = 65, activityIndicator = Joe, selectedBetter = radioButton1, title = "Player 1" };
            Variable.RabbitBetter[1] = new Bettor() { PocketCash = 75, activityIndicator = Bob, selectedBetter = radioButton2, title = "Player 2" };
            Variable.RabbitBetter[2] = new Bettor() { PocketCash = 55, activityIndicator = Al, selectedBetter = radioButton3, title = "Player 3" };

            // Sets the default values to the labels
            Variable.RabbitBetter[0].ActivityLabelUpdator();
            Variable.RabbitBetter[1].ActivityLabelUpdator();
            Variable.RabbitBetter[2].ActivityLabelUpdator();
            Variable.RabbitBetter[0].ResetBettingHistory();
            Variable.RabbitBetter[1].ResetBettingHistory();
            Variable.RabbitBetter[2].ResetBettingHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Variable.RabbitBetter[Variable.CurrentBetter].Betting((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Variable.RabbitBetter[Variable.CurrentBetter].ActivityLabelUpdator();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            button2.Enabled = true;


        }
        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
                    button2.Enabled = true;
                    DeclarTheWinner(i + 1);
                }
            }
        }

        private void MoveRabbits()
        {
            Variable.Rabbit[0].MoveRabbitsToStart();
            Variable.Rabbit[1].MoveRabbitsToStart();
            Variable.Rabbit[2].MoveRabbitsToStart();
            Variable.Rabbit[3].MoveRabbitsToStart();

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Variable.CurrentBetter = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Variable.CurrentBetter = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Variable.CurrentBetter = 2;
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
                for (int i = 0; i < Variable.RabbitBetter.Length; i++)
                {
                    Variable.RabbitBetter[i].CollectWinnings(Winner);
                    Variable.RabbitBetter[i].ActivityLabelUpdator();
                    MoveRabbits();
                    ResetBids();
                }
            }

        
    }
}







       