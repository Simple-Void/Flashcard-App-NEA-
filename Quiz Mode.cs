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
        //YOU DID THIS DANIEL JENNINGS 29/12/2004 18 Booth Road OX16 1EG NATWEST DEBIT CARD USING MASTERCARD
        int[] correctCards = new int[2];

        bool flashcardShowTerm = false;
        int totalTimeInSecs = (60 * 3);
        public Quiz_Mode_UI(Set setToUse, Dictionary<int, Flashcard> _cardsDictionary)
        {
            //import the flashcard
            FlashcardsDictionary = _cardsDictionary;
            //import the set to use
            selectedSet = setToUse;
            //set the max cards to the number of cards in the set to avoid overflow
            totalCards = selectedSet.cards.Count();

            InitializeComponent();
            nextCard();
            countUpComponent.Interval = 1000;
            countUpComponent.Tick += countUpComponent_Tick;
            //sets the flashcard to default value
            btnQMFlashCard.Text = cardTerm;
            //sets the card count to default value
            lblQMCardCount.Text = $"CARD {cardIndex+1}/{totalCards}";
            //sets the timer text to 3:00
            lblQMTimer.Text = "3:00";
            //starts timer
            countUpComponent.Start();
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
                lblQMTimer.Text = $"{timerTextMins}:{timerTextSecs}";
            }
        }

        //a separate section to increment the cards to allow a reference to it at the start
        //works
        private void nextCard()
        {
            if (cardIndex == totalCards-1)
            {
                //set is over, go home
                MessageBox.Show($"You completed the set! You got {correctCards[0]} card(s) right and {correctCards[1]} card(s) wrong.", "Congratulations!");
                this.Close();
            } else
            {
                cardIndex++;
                cardTerm = FlashcardsDictionary[selectedSet.cards[cardIndex]].term;
                cardDefinition = FlashcardsDictionary[selectedSet.cards[cardIndex]].definition;
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
            editSucRate(true, selectedSet.cards[cardIndex]);
            //ARE YOU HAPPY YET DANIEL JENNINGS 29/12/2004 18 Booth Road OX16 1EG NATWEST DEBIT CARD USING MASTERCARD
            correctCards[0]++;
            //uses a separate function as the card must be indexed at the start of the set
            nextCard();
        }

        //offloads functionality
        //got it wrong, changes card success rate data and then flips the card
        private void btnQMWrong_Click(object sender, EventArgs e)
        {
            editSucRate(false, selectedSet.cards[cardIndex]);
            //ARE YOU SATISFIED?????? DANIEL JENNINGS 29/12/2004 18 Booth Road OX16 1EG NATWEST DEBIT CARD USING MASTERCARD
            correctCards[1]++;
            //uses a separate function as the card must be indexed at the start of the set
            nextCard();
        }
    }
}
