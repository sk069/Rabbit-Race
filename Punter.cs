using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabbit_Race
{
    //This is a abstract class which has code for placing bet//
     public class Punter : Bet
    {
        public string title { get; set; }
        public int PocketCash { get; set; }
        public Bet ExistingBet;

        public RadioButton selectedBetter { get; set; }
        public Label activityIndicator { get; set; }

        public void ActivityLabelUpdator()
        {
            selectedBetter.Text = title + " has $" + PocketCash;
        }

        public void ResetBettingHistory()
        {
            ExistingBet = null;
            activityIndicator.Text = title + " hasn't placed a bet";
        }

        public bool Betting(int Amount, int BidPlayer)
        {
            this.ExistingBet = new Bet() { betBalance = Amount, betRabbit = BidPlayer };

            if (Amount <= PocketCash)
            {
                activityIndicator.Text = this.title + " has placed $" + Amount + " on Player #" + BidPlayer;
                this.ActivityLabelUpdator();
                return true;
            }
            else
            {
                MessageBox.Show(this.title + " doesn't have enough money to cover for the bet!");
                this.ExistingBet = null;
                return false;
            }
        }

        public void CollectWinnings(int WinningBetter)
        {
            if (this.ExistingBet != null)
            {
                PocketCash += ExistingBet.CashOut(WinningBetter);
                ResetBettingHistory();
                ActivityLabelUpdator();
            }
        }
    }
}
