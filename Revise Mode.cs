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
        //variables to store for the card data to display
        static Set selectedSet;
        static Dictionary<int, Flashcard> FlashcardsDictionary = new Dictionary<int, Flashcard>();
        string cardTerm = "Term";
        string cardDefinition = "Definition";
        string cardImage = "";
        int totalCards;
        bool flashcardShowTerm = false;
        Queue<int> cardIDs = new Queue<int>();

        bool flashcardData = true;
        bool enableTimer = false;
        int totalTimeInSecs = (60*3);
        public Revise_Mode_UI(Set setToUse, Dictionary<int, Flashcard> _cardsDictionary, bool enableTimer)
        {
            selectedSet = setToUse;
            FlashcardsDictionary = _cardsDictionary;
            //set the max cards to the number of cards in the set to avoid overflow
            totalCards = selectedSet.cards.Count();
            //set up the queue for the card IDs
            for (int c = 0; c < totalCards; c++)
            {
                cardIDs.Enqueue(selectedSet.cards[c]);
            }
            InitializeComponent();

            //is the timer enabled?
            if (enableTimer == true)
            {
                //enable the timer
                countUpComponent.Enabled = false;
                //set up the component data
                countUpComponent.Interval = 1000;
                countUpComponent.Tick += countUpComponent_Tick;
                //sets the timer text to 3:00
                lblRMTimer.Text = "3:00";
                //starts timer
                countUpComponent.Start();
            }
            else
            {
                //set text to nothing so it doesn't look out of place
                lblRMTimer.Text = "";
                //disable the timer
                countUpComponent.Enabled = false;
            }

            //display the default image
            pcbxCardPic.Image = Image.FromFile(@"D:\School Work\Computing\NEA\Default.png");
            pcbxCardPic.SizeMode = PictureBoxSizeMode.StretchImage;
            nextCard();
            flashcardShowTerm = true;
            flipCard();
        }

        private void btnRMQuit_Click(object sender, EventArgs e)
        {
            //closes the current window
            this.Close();
        }

        private void btnRMFlashCard_Click(object sender, EventArgs e)
        {
            //offload functionality
            flipCard();
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
            }
            else
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
                }
                else if (timerMinutes < 10)
                {
                    //put a 0 in front to make it two digits long
                    timerTextMins = $"0{timerMinutes}";
                }
                else
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
                }
                else if (timerSeconds < 10)
                {
                    //add a 0 to make it two digits
                    timerTextSecs = $"0{timerSeconds}";
                }
                else
                {
                    //regular text
                    timerTextSecs = $"{timerSeconds}";
                }
                lblRMTimer.Text = $"{timerTextMins}:{timerTextSecs}";
            }
        }

        private void btnRMNext_Click(object sender, EventArgs e)
        {
            nextCard();
        }

        //a separate section to increment the cards to allow a reference to it at the start
        //works
        private void nextCard()
        {
            //takes the next item from the queue, displays and moves to back of queue
            cardTerm = FlashcardsDictionary[cardIDs.Peek()].term;
            cardDefinition = FlashcardsDictionary[cardIDs.Peek()].definition;
            //set card image and check if it exists before displaying
            cardImage = FlashcardsDictionary[cardIDs.Peek()].pictureLocation;
            if (File.Exists(cardImage))
            {
                pcbxCardPic.Image = Image.FromFile(@cardImage);
            } else
            {
                pcbxCardPic.Image = Image.FromFile(@"D:\School Work\Computing\NEA\Default.png");
            }
            cardIDs.Enqueue(cardIDs.Dequeue());
            flashcardShowTerm = true;
            flipCard();
        }

        //works
        private void flipCard()
        {
            if (flashcardShowTerm == true)
            {
                //is showing the term, swap to def
                btnRMFlashCard.Text = cardTerm;
                //swap the bool val
                flashcardShowTerm = false;
            }
            else
            {
                //is showing the def, swap to term
                btnRMFlashCard.Text = cardDefinition;
                //swap the bool val
                flashcardShowTerm = true;
            }
        }

        private void btnNextCard_Click(object sender, EventArgs e)
        {
            nextCard();
        }
    }
}
