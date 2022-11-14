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
    public partial class Quiz_Mode_UI : Form
    {
        //variables to store for the card data to display
        static Set selectedSet;
        static Dictionary<int, Flashcard> FlashcardsDictionary = new Dictionary<int, Flashcard>();
        string cardTerm = "Term";
        string cardDefinition = "Definition";
        int totalCards;
        int cardIndex = -1;
        //YOU DID THIS DANIEL JENNINGS 29/12/2004 18 Booth Road OX16 1EG NATWEST DEBIT CARD
        int[] correctCards = new int[2];
        //you did this daniel jennings :)
        Queue<int> cardIDs = new Queue<int>();

        bool flashcardShowTerm = false;
        int totalTimeInSecs = (60 * 3);
        public Quiz_Mode_UI(Set setToUse, Dictionary<int, Flashcard> _cardsDictionary, bool enableTimer)
        {
            //import the flashcard
            FlashcardsDictionary = _cardsDictionary;
            //import the set to use
            selectedSet = setToUse;
            //set the max cards to the number of cards in the set to avoid overflow
            totalCards = selectedSet.cards.Count();
            //set up the queue for the card IDs
            for (int c = 0; c < totalCards; c++)
            {
                cardIDs.Enqueue(selectedSet.cards[c]);
            }

            InitializeComponent();

            //post initialisation setup
            nextCard();
            //is the timer enabled?
            if (enableTimer == true)
            {
                //enable the timer
                countUpComponent.Enabled = false;
                //set up the component data
                countUpComponent.Interval = 1000;
                countUpComponent.Tick += countUpComponent_Tick;
                //sets the timer text to 3:00
                lblQMTimer.Text = "3:00";
                //starts timer
                countUpComponent.Start();
            }
            else
            {
                //set text to nothing so it doesn't look out of place
                lblQMTimer.Text = "";
                //disable the timer
                countUpComponent.Enabled = false;
                //also move the card count up to where the timer was
                Point newCCLocation = new Point(648, 59);
                lblQMCardCount.Location = newCCLocation;
            }
            //sets the flashcard to default value
            btnQMFlashCard.Text = cardTerm;
            //sets the card count to default value
            lblQMCardCount.Text = $"CARD {cardIndex+1}/{totalCards}";
        }

        //fully functional
        private void btnQMQuit_Click(object sender, EventArgs e)
        {
            //closes the current window
            this.Close();
        }

        //offloads functionality
        private void btnQMFlashCard_Click(object sender, EventArgs e)
        {
            //offloads functionality to another sub for proper refresh
            flipCard();
        }

        //works
        private void flipCard()
        {
            if (flashcardShowTerm == true)
            {
                //is showing the term, swap to def
                btnQMFlashCard.Text = cardTerm;
                //swap the bool val
                flashcardShowTerm = false;
            } else
            {
                //is showing the def, swap to term
                btnQMFlashCard.Text = cardDefinition;
                //swap the bool val
                flashcardShowTerm = true;
            }
        }

        //fully functional
        private void countUpComponent_Tick(object sender, EventArgs e)
        {
            //ticks down the total seconds remaining
            totalTimeInSecs--;
            //if the timer is done the mode is over and window closes
            if (totalTimeInSecs < 0)
            {
                countUpComponent.Stop();
                MessageBox.Show($"Your time is up!");
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
                lblQMTimer.Text = $"{timerTextMins}:{timerTextSecs}";
            }
        }

        //a separate section to increment the cards to allow a reference to it at the start
        //fully functional
        private void nextCard()
        {
            if (cardIDs.Count() <= 0)
            {
                //set is over, go home
                MessageBox.Show($"You completed the set! You got {correctCards[1]} card(s) wrong to start, but you got them all in the end!", "Congratulations!");
                this.Close();
            } else
            {
                //takes the next item from the queue cardIDs.Dequeue()
                cardTerm = FlashcardsDictionary[cardIDs.Peek()].term;
                cardDefinition = FlashcardsDictionary[cardIDs.Peek()].definition;
                lblQMCardCount.Text = $"CARD {cardIndex+1}/{totalCards}";
                flashcardShowTerm = true;
                flipCard();
            }
        }

        //fully functional
        private void editSucRate(bool correct, int cardID)
        {
            //creates a temporary item
            Flashcard tempFlashcard = FlashcardsDictionary[cardID];
            //if it was correct increment the correct attempts too
            if (correct == true)
            {
                tempFlashcard.successRate[0]++;
            }
            //regardless of correct or not another attempt has been made and total attempts increases
            tempFlashcard.successRate[1]++;
            //writes back to the dictionary
            FlashcardsDictionary[cardID] = tempFlashcard;
        }

        //offloads funtionality
        //got it right, changes card success rate data and then flips the card
        private void btnQMRight_Click(object sender, EventArgs e)
        {
            editSucRate(true, cardIDs.Peek());
            //ARE YOU HAPPY YET DANIEL JENNINGS 29/12/2004 18 Booth Road OX16 1EG NATWEST DEBIT CARD USING MASTERCARD
            correctCards[0]++;
            //increments the card count here as incorrect cards don't count toward it
            cardIndex++;
            //got it right the card can be removed
            cardIDs.Dequeue();
            //uses a separate function as the card must be indexed at the start of the set
            nextCard();
        }

        //offloads functionality
        //got it wrong, changes card success rate data and then flips the card
        private void btnQMWrong_Click(object sender, EventArgs e)
        {
            editSucRate(false, cardIDs.Peek());
            //ARE YOU SATISFIED?????? DANIEL JENNINGS 29/12/2004 18 Booth Road OX16 1EG NATWEST DEBIT CARD USING MASTERCARD
            correctCards[1]++;
            //dequeue the card and requeue the card since it was wrong but not the next card
            cardIDs.Enqueue(cardIDs.Dequeue());
            //uses a separate function as the card must be indexed at the start of the set
            nextCard();
        }
    }
}
