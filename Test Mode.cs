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
        string cardImage = "";
        int[] correctCards = new int[2];
        //you did this daniel jennings :)
        Queue<int> cardIDs = new Queue<int>();
        int correctPlacement = 0;
        string textToWrite = "";
        bool personalOrClass = false;

        int totalTimeInSecs = (60 * 3);

        public Test_Mode_UI(Set setToUse, Dictionary<int, Flashcard> _cardsDictionary, bool enableTimer, bool _classOrPersonal)
        {
            //import the flashcard
            FlashcardsDictionary = _cardsDictionary;
            //import the set to use
            selectedSet = setToUse;
            //set the max cards to the number of cards in the set to avoid overflow
            totalCards = selectedSet.cards.Count();
            //create the array of the values
            int[] cardsArray = setToUse.cards;
            Random random = new Random();
            int loc1;
            int loc2;
            int tempID;
            for (int c = 0; c < totalCards; c++)
            {
                loc1 = random.Next(0, totalCards);
                tempID = cardsArray[loc1];
                loc2 = random.Next(0, totalCards);
                cardsArray[loc1] = cardsArray[loc2];
                cardsArray[loc2] = tempID;
            }
            //set up the queue for the card IDs
            for (int c = 0; c < totalCards; c++)
            {
                cardIDs.Enqueue(cardsArray[c]);
            }

            InitializeComponent();

            //display the default image
            pcbxCardPic.Image = Image.FromFile(@"D:\School Work\Computing\NEA\Default.png");
            pcbxCardPic.SizeMode = PictureBoxSizeMode.StretchImage;

            //classorpersonal
            //false means personal
            personalOrClass = _classOrPersonal;

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
            bool correct = false;
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

            //determines if the selected option is the same as the correct one
            if (btnSelected == correctPlacement)
            {
                correct = true;
                correctCards[0]++;
            } else
            {
                correct = false;
                correctCards[1]++;
            }

            //changes the correct / incorrect ratio if it's a personal test
            if (personalOrClass == false)
            {
                //personal test, edit data
                editSucRate(correct, cardIDs.Peek());
            }
            cardIndex++;
            cardIDs.Dequeue();

            //progresses card
            nextQuestion();
        }

        void editSucRate(bool correct, int cardID)
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

        //fully functional
        public void nextQuestion()
        {
            Random rnd = new Random();
            if (cardIDs.Count() <= 0)
            {
                //set is over, go home
                MessageBox.Show($"You completed the set! You got {correctCards[0]} card(s) right and {correctCards[1]} card(s) wrong.", "Congratulations!");
                //if personal flush the cards
                if (personalOrClass == false)
                {
                    flushAllCards();
                } else
                {
                    //otherwise we write as a class test file
                    writeClassSuccessRate(false, correctCards[0], correctCards[1]);
                }
                this.Close();
            }
            else
            {
                //takes the next item from the queue cardIDs.Dequeue()
                cardQuestion = FlashcardsDictionary[cardIDs.Peek()].questions[rnd.Next(1,3)];
                cardAnswer = FlashcardsDictionary[cardIDs.Peek()].term;
                //set card image and check if it exists before displaying
                cardImage = FlashcardsDictionary[cardIDs.Peek()].pictureLocation;
                if (File.Exists(cardImage))
                {
                    pcbxCardPic.Image = Image.FromFile(@cardImage);
                }
                else
                {
                    pcbxCardPic.Image = Image.FromFile(@"D:\School Work\Computing\NEA\Default.png");
                }
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
            }
        }

        private async Task flushAllCards()
        {
            //set the address to a constant to make it a bit easier to edit :)
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Flashcards.txt";

            //clear the file
            File.WriteAllText(fileAddress, String.Empty);

            foreach (KeyValuePair<int, Flashcard> entry in FlashcardsDictionary)
            {
                //create a flashcard object with the data temporarily
                Flashcard tempFlashcard = FlashcardsDictionary[entry.Key];

                //sets the file to append and states the file to append to
                using StreamWriter file = new(fileAddress, append: true);
                //formats the data appropriately for the file
                string textToWrite = (tempFlashcard.ID).ToString() + "#~#" + (tempFlashcard.term) + "#~#" + (tempFlashcard.definition)
                    + "#~#" + (tempFlashcard.pictureLocation) + "#~#" + (tempFlashcard.questions[0]) + "#~#" + (tempFlashcard.questions[1]) +
                    "#~#" + (tempFlashcard.questions[2]) + "#~#" + (tempFlashcard.falseAnswers[0]) + "#~#" + (tempFlashcard.falseAnswers[1]) +
                    "#~#" + (tempFlashcard.falseAnswers[2]) + "#~#" + (tempFlashcard.falseAnswers[3]) + "#~#" + (tempFlashcard.falseAnswers[4]) +
                    "#~#" + (tempFlashcard.tags[0]) + "#~#" + (tempFlashcard.tags[1]) + "#~#" + (tempFlashcard.tags[2]) + "#~#" +
                    (tempFlashcard.successRate[0]) + "#~#" + (tempFlashcard.successRate[1]) + "#~#";
                //appends the given value to the file
                await file.WriteLineAsync(textToWrite);
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
                //if personal flush the cards
                if (personalOrClass == false)
                {
                    flushAllCards();
                } else
                {
                    //write as a class test file
                    writeClassSuccessRate(false, correctCards[0], correctCards[1]);
                }
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

        private void writeClassSuccessRate(bool _timeOut, int _correct, int _incorrect)
        {
            bool valid = true;
            bool writeFile = true;
            string fileName = "";
            //timeOut determines if the class ran out of time or not
            //successRate is the success rate
            //writes the class success rate
            do
            {
                //creates the file the user requested
                fileName = @"C:\Users\Public\FlashcardAppData\" + 
                    Microsoft.VisualBasic.Interaction.InputBox("Please enter the file name for this test", 
                    "Input File Name", "Class_Test") + ".txt";
                if (File.Exists(fileName))
                {
                    //if the file exists and the user does not want to overwrite then loop
                    //otherwise permit the action
                    if (MessageBox.Show("Would you like to overwrite the existing file?",
                    "File Already Exists", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        writeFile = false;
                        valid = false;
                    }
                }
            } while (valid == false);

            if (writeFile == true)
            {
                using (StreamWriter w = File.AppendText(fileName));
                //clear the file
                File.WriteAllText(fileName, String.Empty);
                //add the data to the file
                using StreamWriter file = new(fileName, append: true);
                //finish condition
                file.WriteLine(_timeOut.ToString());
                //right
                file.WriteLine(_correct.ToString());
                //wrong
                file.WriteLine(_incorrect.ToString());
                file.Close();
                valid = true;
            }
        }
    }
}

