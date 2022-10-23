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
    public partial class Test_Mode_UI : Form
    {
        //variables to store for the card data to display
        static Set selectedSet;
        static Dictionary<int, Flashcard> FlashcardsDictionary = new Dictionary<int, Flashcard>();
        string cardQuestion = "Question";
        string cardAnswer = "Answer";
        string[] cardFA = new string[5];
        int totalCards;
        int cardIndex = -1;
        int[] correctCards = new int[2];
        //you did this daniel jennings :)
        Queue<int> cardIDs = new Queue<int>();
        int correctPlacement = 0;
        string textToWrite = "";

        int totalTimeInSecs = (60 * 3);

        public Test_Mode_UI(Set setToUse, Dictionary<int, Flashcard> _cardsDictionary, bool enableTimer)
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

            //is the timer enabled?
            if (enableTimer == true)
            {
                //enable the timer
                countUpComponent.Enabled = false;
                //set up the component data
                countUpComponent.Interval = 1000;
                countUpComponent.Tick += countUpComponent_Tick;
                //sets the timer text to 3:00
                lblTMTimer.Text = "3:00";
                //starts timer
                countUpComponent.Start();
            }
            else
            {
                //set text to nothing so it doesn't look out of place
                lblTMTimer.Text = "";
                //disable the timer
                countUpComponent.Enabled = false;
            }

            //flip the card from -1 to 0 to start the set
            nextQuestion();
        }

        private void btnTMQuit_Click(object sender, EventArgs e)
        {
            //closes the current window
            this.Close();
        }

        private void btnTMSubmit_Click(object sender, EventArgs e)
        {
            int btnSelected = 0;
            //submits current selection
            if (rdbtnTMQ1.Checked == true)
            {
                btnSelected = 1;
            }
            else if (rdbtnTMQ2.Checked == true)
            {
                btnSelected = 2;
            }
            else if (rdbtnTMQ3.Checked == true)
            {
                btnSelected = 3;
            }
            else
            {
                btnSelected = 4;
            }

            //progresses card
            nextQuestion();
        }

        void editSucRate()
        {

        }

        public void nextQuestion()
        {
            Random rnd = new Random();
            if (cardIDs.Count() <= 0)
            {
                //set is over, go home
                MessageBox.Show($"You completed the set! You got {correctCards[0]} card(s) right and {correctCards[1]} card(s) wrong.", "Congratulations!");
                this.Close();
            }
            else
            {
                //takes the next item from the queue cardIDs.Dequeue()
                cardQuestion = FlashcardsDictionary[cardIDs.Peek()].questions[rnd.Next(1,3)];
                cardAnswer = FlashcardsDictionary[cardIDs.Peek()].term;
                //random false answers
                List<int> chosenNums = new List<int>();
                int foundNums = 0;

                //pick a random place for the correct answer to appear
                bool found = false;
                int rand = 0;
                correctPlacement = rnd.Next(1,4);
                //show the new data
                for (int c = 1; c < 5; c++)
                {
                    found = false;
                    //if the chosen line is the 'correct' one
                    //the string to set is changed to the correct answer
                    if (c == correctPlacement)
                    {
                        textToWrite = cardAnswer;
                    } else
                    {
                        //set to the next false answer
                        //find the next value
                        do
                        {
                            rand = rnd.Next(0, 4);
                            if (!chosenNums.Contains(rand))
                            {
                                //does not contain the val, add rand and state found
                                chosenNums.Add(rand);
                                //set it to display too
                                textToWrite = FlashcardsDictionary[cardIDs.Peek()].falseAnswers[rand];
                                found = true;
                            }
                        } while (found == false);
                    }

                    //actually display the information
                    switch (c)
                    {
                        case 1:
                            //option 1
                            rdbtnTMQ1.Text = textToWrite;
                            break;

                        case 2:
                            //option 2
                            rdbtnTMQ2.Text = textToWrite;
                            break;

                        case 3:
                            //option 3
                            rdbtnTMQ3.Text = textToWrite;
                            break;

                        default:
                            //option 4
                            rdbtnTMQ4.Text = textToWrite;
                            break;
                    }
                }
                //set the base question
                lblTMQuestion.Text = cardQuestion;
                cardIDs.Dequeue();
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
                lblTMTimer.Text = $"{timerTextMins}:{timerTextSecs}";
            }
        }
    }
}

