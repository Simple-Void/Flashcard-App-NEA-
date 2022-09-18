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
        int[] panelHeight = new int[2];
        //next button position at different stages
        int[] nextPosition = new int[2];
        public Set_Creator_UI(Dictionary<int, Set> _setsDictionary, Dictionary<int, Flashcard> _cardsDictionary)
        {
            SetsDictionary = _setsDictionary;
            FlashcardsDictionary = _cardsDictionary;
            InitializeComponent();
            panelHeight[0] = 202;
            panelHeight[1] = 700;

            nextPosition[0] = 118;
            nextPosition[1] = 612;


            //set UI to defaults
            //clear
            lblSCCards.Hide();
            txtbxSCSearch.Hide();
            btnSCSearch.Hide();
            lstVCards.Hide();

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
            if (setCreationStage == 1)
            {
                btnSCNext.Text = "CREATE SET";
            }

            if (setCreationStage > 1)
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

            if (setCreationStage < 2)
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

            //create the set object
            Set CurrentlyAddingSet = new Set(SetID, name, resources, cardsSelection);
            //add this card to the hashtable
            //I am safe to override the flashcard object here as the dictionary effectively stores a snapshot
            SetsDictionary.Add(CurrentlyAddingSet.ID, CurrentlyAddingSet);

            appendSetToFile(CurrentlyAddingSet.ID);
        }

        //no worky
        public void displayCardsInUI()
        {
            //this needs to go through all the cards and write them to the panel to pick from
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
            int[] result = new int[2];
            return result;
        }

        //fully functional
        public async Task appendSetToFile(int SetIDToAppend)
        {
            //set the address to a constant to make it a bit easier to edit :)
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Sets.txt";

            //sets the file to append and states the file to append to
            using StreamWriter file = new(fileAddress, append: true);
            //formats the data appropriately for the file
            //create a flashcard object with the data temporarily
            Set tempSet = SetsDictionary[SetIDToAppend];
            string textToWrite = (tempSet.ID).ToString() + "#~#" + (tempSet.name) + "#~#" + (tempSet.resources);
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
    }
}
