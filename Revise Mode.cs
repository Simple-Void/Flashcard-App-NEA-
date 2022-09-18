using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_Project_UI
{
    public partial class Revise_Mode_UI : Form
    {
        bool flashcardData = true;
        int totalTimeInSecs = (60*3);
        public Revise_Mode_UI()
        {
            InitializeComponent();
            countUpComponent.Interval = 1000;
            countUpComponent.Tick += countUpComponent_Tick;
            //sets the flashcard to default value
            btnRMFlashCard.Text = "Term";
            //sets the timer text to 3:00
            lblRMTimer.Text = "3:00";
            //starts timer
            countUpComponent.Start();
        }

        private void btnRMQuit_Click(object sender, EventArgs e)
        {
            //closes the current window
            this.Close();
        }

        private void btnRMFlashCard_Click(object sender, EventArgs e)
        {
            //some very rough text switching as proof of concept
            if (flashcardData == true)
            {
                flashcardData = false;
                btnRMFlashCard.Text = "Definition";
            } else
            {
                flashcardData = true;
                btnRMFlashCard.Text = "Term";
            }
        }

        private void countUpComponent_Tick(object sender, EventArgs e)
        {
            //ticks down the total seconds remaining
            totalTimeInSecs--;
            //if the timer is done the mode is over and window closes
            if (totalTimeInSecs < 0)
            {
                countUpComponent.Stop();
                MessageBox.Show("your time is up!");
                this.Close();
            } else
            {
                //otherwise find minutes and seconds for display
                int timerMinutes = (int)(totalTimeInSecs / 60);
                int timerSeconds = (int)(totalTimeInSecs % 60);

                //this is formatting just for the look of the program,
                //it has no bearing on function
                //minutes
                string timerTextMins = "";
                if (timerMinutes == 0)
                {
                    //make it 00
                    timerTextMins = "00";
                } else if (timerMinutes < 10)
                {
                    //put a 0 in front to make it two digits long
                    timerTextMins = $"0{timerMinutes}";
                } else
                {
                    //already double digits no formatting
                    timerTextMins = $"{timerMinutes}";
                }
                //seconds
                string timerTextSecs = "";
                if (timerSeconds == 0)
                {
                    //make it 00
                    timerTextSecs = "00";
                } else if (timerSeconds < 10)
                {
                    //add a 0 to make it two digits
                    timerTextSecs = $"0{timerSeconds}";
                } else
                {
                    //regular text
                    timerTextSecs = $"{timerSeconds}";
                }
                lblRMTimer.Text = $"{timerTextMins}:{timerTextSecs}";
            }
        }
    }
}
