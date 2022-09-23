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
    public partial class Set_Creator_UI : Form
    {
        static Dictionary<int, Set> SetsDictionary = new Dictionary<int, Set>();
        static Dictionary<int, Flashcard> FlashcardsDictionary = new Dictionary<int, Flashcard>();
        int setCreationStage = 0;

        //UI panel heights at different stages
        int[] panelHeight = new int[3];
        //next button position at different stages
        int[] nextPosition = new int[3];
        public Set_Creator_UI(Dictionary<int, Set> _setsDictionary, Dictionary<int, Flashcard> _cardsDictionary)
        {
            SetsDictionary = _setsDictionary;
            FlashcardsDictionary = _cardsDictionary;
            InitializeComponent();
            populateTags();
            displayCardsInUI();
            panelHeight[0] = 202;
            panelHeight[1] = 700;
            panelHeight[2] = 151;

            nextPosition[0] = 118;
            nextPosition[1] = 612;
            nextPosition[2] = 66;


            //set UI to defaults
            //clear
            lblSCCards.Hide();
            txtbxSCSearch.Hide();
            btnSCSearch.Hide();
            lstVCards.Hide();
            lblSCTags.Hide();
            cmbbxSCT1.Hide();
            cmbbxSCT2.Hide();
            cmbbxSCT3.Hide();

            //setup
            lblSCName.Show();
            txtbxSCName.Show();
            lblSCResources.Show();
            txtbxSCResources.Show();
            this.Height = panelHeight[0];
            Point nextButtonLocation = new Point(12, (nextPosition[0]));
            btnSCNext.Location = nextButtonLocation;
        }

        private void btnSCNext_Click(object sender, EventArgs e)
        {
            setCreationStage++;
            if (setCreationStage == 2)
            {
                btnSCNext.Text = "CREATE SET";
            }

            if (setCreationStage > 2)
            {
                //make the object and write to array & file
                createSet();
                this.Close();
            }

            if (setCreationStage == 1)
            {
                //hide old UI
                lblSCName.Hide();
                txtbxSCName.Hide();
                lblSCResources.Hide();
                txtbxSCResources.Hide();

                //reveal new
                lblSCCards.Show();
                txtbxSCSearch.Show();
                btnSCSearch.Show();
                lstVCards.Show();
            }

            if (setCreationStage ==2)
            {
                //hide old UI
                lblSCCards.Hide();
                txtbxSCSearch.Hide();
                btnSCSearch.Hide();
                lstVCards.Hide();

                //reveal new
                lblSCTags.Show();
                cmbbxSCT1.Show();
                cmbbxSCT2.Show();
                cmbbxSCT3.Show();
            }

            if (setCreationStage < 3)
            {
                //resize etc
                Point nextButtonLocation = new Point(12, (nextPosition[setCreationStage]));
                btnSCNext.Location = nextButtonLocation;

                this.Height = panelHeight[setCreationStage];
            }
        }

        public void createSet()
        {
            //run required procedures for set information
            int SetID = findAvailableSetID();
            string[] setParameters = inpSetParameters();
            int[] cardsSelection = inpCardsSelection();
            //write the string params to usable vars in the object
            string name = setParameters[0];
            string resources = setParameters[1];
            //get the tags array
            int[] tags = inpSetTags();

            //create the set object
            Set CurrentlyAddingSet = new Set(SetID, name, resources,tags , cardsSelection);
            //add this card to the hashtable
            //I am safe to override the flashcard object here as the dictionary effectively stores a snapshot
            SetsDictionary.Add(CurrentlyAddingSet.ID, CurrentlyAddingSet);

            appendSetToFile(CurrentlyAddingSet.ID);
        }

        //no worky
        public void displayCardsInUI()
        {
            //this needs to go through all the cards and write them to the panel to pick from
            //gets the number so as not to overrun
            int cardsCount = FlashcardsDictionary.Count;
            for (int i = 0; i < cardsCount; i++)
            {
                //loops through for all cards in set, adding the information for the **CARD ID IN THE LOCAL ARRAY WITH THE INDEX OF THE LOOP COUNT**
                //again, assigns to an array before assigning as a row in the listview
                string[] rowData = { (FlashcardsDictionary[i].ID).ToString(), FlashcardsDictionary[i].term, FlashcardsDictionary[i].definition };
                var lstvwItem = new ListViewItem(rowData);
                lstVCards.Items.Add(lstvwItem);
            }
        }

        //fully functional
        public int findAvailableSetID()
        {
            //initial setup of variables
            //this count returns the count from 1 not 0
            int TotalLength = SetsDictionary.Count;
            int Check = 0;
            bool Valid = false;

            //leonard has not read this therefore it don't work
            //UPDATE: leonard has read this and now it works - told you he's a great coding buddy
            //loops until a valid value is found
            do
            {
                //exits with the default value if there are no sets to check
                if (TotalLength < 1)
                {
                    Valid = true;
                }
                //loops through all existing flashcards
                for (int c = 0; c < TotalLength; c++)
                {
                    //checks if the card has the ID it checks for
                    if (SetsDictionary[c].ID == Check)
                    {
                        //the ID is in use
                        //increment check val and break loop
                        Check++;
                        break;
                    }
                    else if (c == TotalLength - 1 && SetsDictionary[c].ID != Check)
                    {
                        //ID not found and end of flashcards so value is free
                        //ID not in use
                        MessageBox.Show($"valid {Check}");
                        Valid = true;
                        break;
                    }
                }
            } while (Valid == false);
            //return the valid ID
            MessageBox.Show($"Found {Check}");
            return Check;
        }

        //fully functional
        public string[] inpSetParameters()
        {
            //takes the values in name and resources field and then 
            //returns them to the caller
            string[] returnValues = new string[2];
            returnValues[0] = txtbxSCName.Text;
            returnValues[1] = txtbxSCResources.Text;
            return returnValues;
        }

        //placeholder values
        public int[] inpCardsSelection()
        {
            int[] result = new int[4];
            result[0] = 0;
            result[1] = 1;
            result[2] = 2;
            result[3] = 3;
            return result;
        }

        //fully functional
        public int[] inpSetTags()
        {
            int[] returnValues = new int[3];

            //gets the index of the selectors
            //this is much simpler than my pseudocode
            returnValues[0] = cmbbxSCT1.SelectedIndex;
            returnValues[1] = cmbbxSCT2.SelectedIndex;
            returnValues[2] = cmbbxSCT3.SelectedIndex;

            return returnValues;
        }

        //adapt for tags
        public async Task appendSetToFile(int SetIDToAppend)
        {
            //set the address to a constant to make it a bit easier to edit :)
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Sets.txt";

            //sets the file to append and states the file to append to
            using StreamWriter file = new(fileAddress, append: true);
            //formats the data appropriately for the file
            //create a flashcard object with the data temporarily
            Set tempSet = SetsDictionary[SetIDToAppend];
            string textToWrite = (tempSet.ID).ToString() + "#~#" + (tempSet.name) + "#~#" + (tempSet.resources)
                + "#~#" + (tempSet.tags[0]) + "#~#" + (tempSet.tags[1]) + "#~#" + (tempSet.tags[2]);
            //loop adding the cards until it reaches the end of the cards array
            int noOfCardsToAdd = tempSet.cards.Length;
            for (int c = 0; c < noOfCardsToAdd; c++)
            {
                textToWrite = textToWrite + "#~#" + (tempSet.cards[c]).ToString() ;
            }
            //the end of the cards needs to be a different separator string to signify the end
            //as there isn't a defined length
            textToWrite = textToWrite + "~#~";
            //appends the given value to the file
            await file.WriteLineAsync(textToWrite);
        }


        //setup the comboboxes
        public string[] tagsArray;
        //fully functional
        public void populateTags()
        {
            //reads in all the tags as lines of an array
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Tags.txt";
            tagsArray = System.IO.File.ReadAllLines(fileAddress);
            int totalTags = tagsArray.Length;

            cmbbxSCT1.Items.Clear();
            for (int c = 0; c < totalTags; c++)
            {
                cmbbxSCT1.Items.Add(tagsArray[c]);
            }

            cmbbxSCT2.Items.Clear();
            for (int c = 0; c < totalTags; c++)
            {
                cmbbxSCT2.Items.Add(tagsArray[c]);
            }

            cmbbxSCT3.Items.Clear();
            for (int c = 0; c < totalTags; c++)
            {
                cmbbxSCT3.Items.Add(tagsArray[c]);
            }
        }
    }
}
