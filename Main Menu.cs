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
        //teacher login boolean
        public bool loggedIn = false;

        public Main_Menu_UI()
        {
            InitializeComponent();
            //takes the flashcards into the dictionary for proper handling
            readFileToCardsDictionary();
            //write the sets and flashcards within that set to the UI elements
            readFileToSetsDictionary();
            displayAllSets();
            showDefaultLoginStatus();
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
            //if there is no selected set show an integrated error
            if (lstvwSets.SelectedItems.Count > 0)
            {
                bool useTimer = false;
                //is the timer enabled?
                if (chkbxTimerYN.Checked == true)
                {
                    //enable the timer
                    useTimer = true;
                }
                else
                {
                    //disable the timer
                    useTimer = false;
                }
                //create and show the revision mode UI
                Revise_Mode_UI newRMUI = new Revise_Mode_UI(SetsDictionary[lstvwSets.FocusedItem.Index], CardsDictionary, useTimer);
                newRMUI.Show();
            }
            else
            {
                MessageBox.Show("Please select a set to revise");
            }
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            //if there is no selected set show an integrated error
            if (lstvwSets.SelectedItems.Count > 0)
            {
                bool useTimer = false;
                //is the timer enabled?
                if (chkbxTimerYN.Checked == true)
                {
                    //enable the timer
                    useTimer = true;
                } else
                {
                    //disable the timer
                    useTimer = false;
                }
                //create and show the quiz mode UI
                Quiz_Mode_UI newQMUI = new Quiz_Mode_UI(SetsDictionary[lstvwSets.FocusedItem.Index], CardsDictionary, useTimer);
                newQMUI.Show();
            } else
            {
                MessageBox.Show("Please select a set to quiz yourself on");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //if there is no selected set show an integrated error
            if (lstvwSets.SelectedItems.Count > 0)
            {
                bool useTimer = false;
                //is the timer enabled?
                if (chkbxTimerYN.Checked == true)
                {
                    //enable the timer
                    useTimer = true;
                }
                else
                {
                    //disable the timer
                    useTimer = false;
                }
                //create and show the test mode UI
                Test_Mode_UI newTMUI = new Test_Mode_UI(SetsDictionary[lstvwSets.FocusedItem.Index], CardsDictionary, useTimer, false);
                newTMUI.Show();
            }
            else
            {
                MessageBox.Show("Please select a set to quiz yourself on");
            }
        }

        private void btnClassTest_Click(object sender, EventArgs e)
        {
            //if there is no selected set show an integrated error
            if (lstvwSets.SelectedItems.Count > 0)
            {
                bool useTimer = false;
                //is the timer enabled?
                if (chkbxTimerYN.Checked == true)
                {
                    //enable the timer
                    useTimer = true;
                }
                else
                {
                    //disable the timer
                    useTimer = false;
                }
                //create and show the test mode UI
                Test_Mode_UI newCTMUI = new Test_Mode_UI(SetsDictionary[lstvwSets.FocusedItem.Index], CardsDictionary, useTimer, true);
                newCTMUI.Show();
            }
            else
            {
                MessageBox.Show("Please select a set to quiz yourself on");
            }
        }

        private void btnMMQuit_Click(object sender, EventArgs e)
        {
            //closes the current window
            this.Close();
        }

        private void btnMMTeacher_Click(object sender, EventArgs e)
        {
            //create and show the teacher login UI
            Teacher_Login_UI newTLUI = new Teacher_Login_UI();
            newTLUI.Show();
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            //create and show the graphing UI
            Graphing_UI newG_UI = new Graphing_UI(CardsDictionary, SetsDictionary);
            newG_UI.Show();
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

            //loops through all the lines in the array
            //the -1 on the length is to stop it reading the blank line for insertion and crashing
            for (int c = 0; c <= flashcardsAsLines.Length - 1; c++)
            {
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
                //I have to recreate these each loop or my objects break, nice (not nice)

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
                string[] rowData = { (SetsDictionary[i].ID).ToString(), SetsDictionary[i].name, SetsDictionary[i].resources };
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
            int[] cardsInSet = null;
            if (lstvwSets.SelectedItems.Count > 0)
            {
                cardsInSet = SetsDictionary[lstvwSets.FocusedItem.Index].cards;
                //gets the total number of cards in that set to know how many times to loop
                int totalCardsInSet = cardsInSet.Length;
                for (int c = 0; c < totalCardsInSet; c++)
                {
                    //loops through for all cards in set, adding the information for the **CARD ID IN THE LOCAL ARRAY WITH THE INDEX OF THE LOOP COUNT**
                    //again, assigns to an array before assigning as a row in the listview
                    string[] rowData = { (CardsDictionary[cardsInSet[c]].ID).ToString(), CardsDictionary[cardsInSet[c]].term, CardsDictionary[cardsInSet[c]].definition };
                    var lstvwItem = new ListViewItem(rowData);
                    lstvwCards.Items.Add(lstvwItem);
                }
            }
        }

        //refresh the sets on form focus
        private void Main_Menu_UI_Activated(object sender, EventArgs e)
        {
            displayAllSets();
            if (Global.teacherLoggedIn == true)
            {
                showLoggedInLoginStatus();
            } else
            {
                showDefaultLoginStatus();
            }
        }

        public void showLoggedInLoginStatus()
        {
            Point newPosition = new Point();
            //show log out
            btnMMTeacher.Hide();
            btnLogOut.Show();
            newPosition = new Point(696, 12);
            btnLogOut.Location = newPosition;
            //timer toggle position
            newPosition = new Point(696, 415);
            chkbxTimerYN.Location = newPosition;
            //revision position
            newPosition = new Point(696, 445);
            btnRev.Location = newPosition;
            //quiz position
            newPosition = new Point(696, 480);
            btnQuiz.Location = newPosition;
            //test position
            newPosition = new Point(696, 515);
            btnTest.Location = newPosition;
            //class test
            btnClassTest.Show();
            newPosition = new Point(696, 550);
            btnClassTest.Location = newPosition;
            //graph
            btnGraph.Show();
            newPosition = new Point(696, 115);
            btnGraph.Location = newPosition;
        }

        //works
        public void showDefaultLoginStatus()
        {
            Point newPosition = new Point();
            //show login not log out
            btnMMTeacher.Show();
            btnLogOut.Hide();
            btnGraph.Hide();
            //timer toggle position
            newPosition = new Point(698, 450);
            chkbxTimerYN.Location = newPosition;
            //revision position
            newPosition = new Point(696, 480);
            btnRev.Location = newPosition;
            //quiz position
            newPosition = new Point(696, 515);
            btnQuiz.Location = newPosition;
            //test position
            newPosition = new Point(696, 550);
            btnTest.Location = newPosition;
            //class test
            btnClassTest.Hide();
        }

        //works
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Global.teacherLoggedIn= false;
            showDefaultLoginStatus();
        }

        private void btnMMSearch_Click(object sender, EventArgs e)
        {
            //get input term
            string searchTerm = txtbxMMSearch.Text;
            int indexVal = 0;
            bool isTag = false;
            List<int> foundSetIDs = new List<int>();
            //get all the potential tags and as such their reference codes
            //reads in all the tags as lines of an array
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Tags.txt";
            List<string> tagsArray = System.IO.File.ReadAllLines(fileAddress).ToList();
            
            //check if the search term is a tag
            if (tagsArray.Contains(searchTerm))
            {
                indexVal = tagsArray.FindIndex(a => a.Contains(searchTerm));
                isTag = true;
            }

            //check the sets
            //index through the hashtable
            for (int c = 0; c <= SetsDictionary.Count()-1; c++)
            {
                //does any of the data in the set match?
                Set tempSet = SetsDictionary[c];
                if ((tempSet.ID).ToString() == searchTerm || tempSet.name == searchTerm 
                    || tempSet.resources == searchTerm || (tempSet.cards).ToString().Contains(searchTerm))
                {
                    foundSetIDs.Add(c);
                }
                //if the term is a tag too
                if (isTag == true)
                {
                    if ((tempSet.tags).Contains(indexVal))
                    {
                        foundSetIDs.Add(c);
                    }
                }
                //if any of these conditions are met, add to a list
            }

            //display the sets in the list
            lstvwSets.Items.Clear();
            for (int i = 0; i < foundSetIDs.Count(); i++)
            {
                //this creates a row of data as a variable before writing to the listview
                //it just makes it easier for me to read honestly
                string[] rowData = { (SetsDictionary[foundSetIDs[i]].ID).ToString(),
                    SetsDictionary[foundSetIDs[i]].name, SetsDictionary[foundSetIDs[i]].resources };
                var lstvwItem = new ListViewItem(rowData);
                lstvwSets.Items.Add(lstvwItem);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            displayAllSets();
            txtbxMMSearch.Clear();
        }
    }
}