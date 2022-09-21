using System.Diagnostics;
using System.Text.Json;

namespace NEA_Project_UI
{
    public partial class Main_Menu_UI : Form
    {
        //the dictionary that stores all flashcards
        public Dictionary<int, Flashcard> CardsDictionary = new();
        //the dictionary that stores all the sets
        public Dictionary<int, Set> SetsDictionary = new();

        public Main_Menu_UI()
        {
            InitializeComponent();
            btnMMTeacher.Enabled = false;
            btnMMSearch.Enabled = false;
            //takes the flashcards into the dictionary for proper handling
            readFileToCardsDictionary();
            //write the sets and flashcards within that set to the UI elements
            readFileToSetsDictionary();
            displayAllSets();
        }

        //private functions managing UI navigation
        #region UI Management
        private void crtcrd_Click(object sender, EventArgs e)
        {
            //create and show the card creator UI
            Card_Creator_UI newCCUI = new Card_Creator_UI(CardsDictionary);
            newCCUI.Show();
        }

        private void crtst_Click(object sender, EventArgs e)
        {
            //create and show the set creator UI
            Set_Creator_UI newSCUI = new Set_Creator_UI(SetsDictionary, CardsDictionary);
            newSCUI.Show();
        }

        private void btnRev_Click(object sender, EventArgs e)
        {
            //create and show the revision mode UI
            Revise_Mode_UI newRMUI = new Revise_Mode_UI();
            newRMUI.Show();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            //create and show the quiz mode UI
            Quiz_Mode_UI newQMUI = new Quiz_Mode_UI();
            newQMUI.Show();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //create and show the test mode UI
            Test_Mode_UI newTMUI = new Test_Mode_UI();
            newTMUI.Show();
        }

        private void btnMMQuit_Click(object sender, EventArgs e)
        {
            //closes the current window
            this.Close();
        }
        #endregion

        //fully functional
        public void readFileToCardsDictionary()
        {
            //crashes if there is no file data to read
            //set the address to a constant to make it a bit easier to edit :)
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Flashcards.txt";
            string[] flashcardsAsLines = System.IO.File.ReadAllLines(fileAddress);
            string currentString = "";
            int writeToObjectStage = 0;

            //values for creating flashcard
            //these have to have a default value or it won't compile
            int ID = 0;
            string term = "";
            string definition = "";
            string pictureLocation = "";
            string[] questions = new string[3];
            string[] falseAnswers = new string[5];
            int[] tags = new int[3];
            int[] successRate = new int[2];

            //loops through all the lines in the array
            //the -1 on the length is to stop it reading the blank line for insertion and crashing
            for (int c = 0; c <= flashcardsAsLines.Length - 1; c++)
            {
                //loops through all the characters in the line
                for (int i = 0; i < flashcardsAsLines[c].Length - 3; i++)
                {
                    currentString = currentString + flashcardsAsLines[c].Substring(i, 1);
                    if (flashcardsAsLines[c].Substring(i + 1, 3) == "#~#")
                    {
                        //MessageBox.Show($"string found, string val '{currentString}', i val '{i}'");
                        switch (writeToObjectStage)
                        {
                            case 0:
                                //ID
                                ID = int.Parse(currentString);
                                break;
                            case 1:
                                //term
                                term = currentString;
                                break;
                            case 2:
                                //definition
                                definition = currentString;
                                break;
                            case 3:
                                //picture
                                pictureLocation = currentString;
                                break;
                            case 4:
                                //question
                                questions[0] = currentString;
                                break;
                            case 5:
                                //question
                                questions[1] = currentString;
                                break;
                            case 6:
                                //question
                                questions[2] = currentString;
                                break;
                            case 7:
                                //answer
                                falseAnswers[0] = currentString;
                                break;
                            case 8:
                                //answer
                                falseAnswers[1] = currentString;
                                break;
                            case 9:
                                //answer
                                falseAnswers[2] = currentString;
                                break;
                            case 10:
                                //answer
                                falseAnswers[3] = currentString;
                                break;
                            case 11:
                                //answer
                                falseAnswers[4] = currentString;
                                break;
                            case 12:
                                //tag
                                tags[0] = int.Parse(currentString);
                                break;
                            case 13:
                                //tag
                                tags[1] = int.Parse(currentString);
                                break;
                            case 14:
                                //tag
                                tags[2] = int.Parse(currentString);
                                break;
                            case 15:
                                //success
                                successRate[0] = int.Parse(currentString);
                                break;
                            case 16:
                                //success
                                successRate[1] = int.Parse(currentString);
                                //write the values gathered to a flashcard object
                                Flashcard CurrentlyAddingFlashcard = new Flashcard(ID, term, definition, pictureLocation, questions, falseAnswers, tags, successRate);
                                CardsDictionary.Add(CurrentlyAddingFlashcard.ID, CurrentlyAddingFlashcard);
                                //this means that when the program increments to the next step and starts
                                //the next line it will start at the right place
                                writeToObjectStage = -1;
                                break;
                        }
                        writeToObjectStage++;
                        currentString = "";
                        i = i + 3;
                    }
                }
            }
        }

        //fully functional
        public void readFileToSetsDictionary()
        {
            //crashes if there is no file data to read
            //oops
            //set the address to a constant to make it a bit easier to edit :)
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Sets.txt";
            string[] setsAsLines = System.IO.File.ReadAllLines(fileAddress);
            string currentString = "";
            int writeToObjectStage = 0;

            //values for creating flashcard
            //these have to have a default value or it won't compile
            int ID = 0;
            string name = "";
            string resources = "";
            int[] tags = new int[3];
            List<int> cards = new List<int>();

            //loops through all the lines in the array
            //the -1 on the length is to stop it reading the blank line for insertion and crashing
            for (int c = 0; c <= setsAsLines.Length - 1; c++)
            {
                //loops through all the characters in the line
                for (int i = 0; i < setsAsLines[c].Length - 3; i++)
                {
                    currentString = currentString + setsAsLines[c].Substring(i, 1);
                    if (setsAsLines[c].Substring(i + 1, 3) == "#~#" || setsAsLines[c].Substring(i + 1, 3) == "~#~")
                    {
                        switch (writeToObjectStage)
                        {
                            case 0:
                                //ID
                                ID = int.Parse(currentString);
                                break;
                            case 1:
                                //name
                                name = currentString;
                                break;
                            case 2:
                                //resources
                                resources = currentString;
                                break;
                            case 3:
                                //tag 1
                                tags[0] = int.Parse(currentString);
                                break;
                            case 4:
                                //tag 2
                                tags[1] = int.Parse(currentString);
                                break;
                            case 5:
                                //tag 3
                                tags[2] = int.Parse(currentString);
                                break;
                            default:
                                //add the card ID to the list, if it's the last term the code below will
                                //trigger and finish this
                                cards.Add(int.Parse(currentString));

                                //if the end of the file then write to the dictionary
                                if (setsAsLines[c].Substring(i + 1, 3) == "~#~")
                                {
                                    //convert the list we have been using into an array
                                    int[] cardsInsert = cards.ToArray();
                                    Set CurrentlyAddingSet = new Set(ID, name, resources, tags, cardsInsert);
                                    //actually add to the dictionary
                                    SetsDictionary.Add(CurrentlyAddingSet.ID, CurrentlyAddingSet);
                                    //clears the cards to ensure it doesn't add too many
                                    cards.Clear();
                                    //this means that when the program increments to the next step and starts
                                    //the next line it will start at the right place
                                    writeToObjectStage = -1;
                                }
                                break;
                        }
                        writeToObjectStage++;
                        currentString = "";
                        i = i + 3;
                    }
                }
            }
        }

        //fully functional
        public void displayAllSets()
        {
            //clears the existing data to ensure no duplicates
            lstvwSets.Items.Clear();
            //gets the total count of the sets to ensure it doesn't overflow from
            //the hashtable
            int totalSets = SetsDictionary.Count;
            for (int i = 0; i < totalSets; i++)
            {
                //loops through all the data, gives relevant information to an array then sets the array to display as a line
                //I can manually assign each column for each line but this was is easier to read and more robust if I rename things
                string[] rowData = {(SetsDictionary[i].ID).ToString(), SetsDictionary[i].name, SetsDictionary[i].resources};
                var lstvwItem = new ListViewItem(rowData);
                lstvwSets.Items.Add(lstvwItem);
            }
        }

        //fully functional
        private void lstvwSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clears the existing data to ensure no duplicates
            lstvwCards.Items.Clear();
            //makes all the cardIDs stored in the set into a local array to reference
            int[] cardsInSet = SetsDictionary[lstvwSets.FocusedItem.Index].cards;
            //gets the total number of cards in that set to know how many times to loop
            int totalCardsInSet = cardsInSet.Length;
            for (int c = 0; c < totalCardsInSet; c++)
            {
                //loops through for all cards in set, adding the information for the **CARD ID IN THE LOCAL ARRAY WITH THE INDEX OF THE LOOP COUNT**
                //again, assigns to an array before assigning as a row in the listview
                string[] rowData = { (CardsDictionary[cardsInSet[c]].ID).ToString(), CardsDictionary[cardsInSet[c]].term, CardsDictionary[cardsInSet[c]].definition};
                var lstvwItem = new ListViewItem(rowData);
                lstvwCards.Items.Add(lstvwItem);
            }
        }
    }
}