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
    public partial class Card_Creator_UI : Form
    {
        //really I should send the dictionary from main to here and vice versa
        //issue being I don't know how
        //I also can't call the function from main
        //so enjoy my b******* duplicate functions
        int cardCreationStage = 0;
        static Dictionary<int, Flashcard> CardsDictionary = new Dictionary<int, Flashcard>();

        //UI panel heights at different stages
        int[] panelHeight = new int[4];
        //next button position at different stages
        int[] nextPosition = new int[4];
        //variable for image file directory, this is hard to access unless global
        string imageFileAddress;
        public Card_Creator_UI(Dictionary<int, Flashcard> _cardsDictionary)
        {
            //
            CardsDictionary = _cardsDictionary;

            InitializeComponent();
            setUpCMBBX();
            panelHeight[0] = 255;
            panelHeight[1] = 247;
            panelHeight[2] = 334;
            panelHeight[3] = 159;

            nextPosition[0] = 171;
            nextPosition[1] = 164;
            nextPosition[2] = 250;
            nextPosition[3] = 69;

            //set UI to defaults
            //clear
            lblCCQuestions.Hide();
            lblCCQExplanation.Hide();
            txtbxCCQ1.Hide();
            txtbxCCQ2.Hide();
            txtbxCCQ3.Hide();

            lblCCFalse.Hide();
            lblCCFExplanation.Hide();
            txtbxCCF1.Hide();
            txtbxCCF2.Hide();
            txtbxCCF3.Hide();
            txtbxCCF4.Hide();
            txtbxCCF5.Hide();

            lblCCTags.Hide();
            cmbCCT1.Hide();
            cmbCCT2.Hide();
            cmbCCT3.Hide();

            //setup
            this.Height = panelHeight[0];
            lblCCTerm.Show();
            txtbxCCTerm.Show();
            lblCCDefinition.Show();
            txtbxDefinition.Show();
            lblCCPicture.Show();
            btnPickFile.Show();
            Point nextButtonLocation = new Point (12,(nextPosition[0]));
            btnCCNext.Location = nextButtonLocation;
        }

        //fully functional
        private void btnCCNext_Click(object sender, EventArgs e)
        {
            cardCreationStage++;
            if (cardCreationStage == 3)
            {
                btnCCNext.Text = "CREATE CARD";
            }

            if (cardCreationStage > 3)
            {
                if (cmbCCT1.SelectedIndex < 0 && cmbCCT2.SelectedIndex < 0 && cmbCCT3.SelectedIndex < 0)
                {
                    MessageBox.Show("please select all three tags");
                } else
                {
                    createFlashcard();
                    this.Close();
                }
            }

            if (cardCreationStage == 1)
            {
                //hide old UI components
                lblCCTerm.Hide();
                txtbxCCTerm.Hide();
                lblCCDefinition.Hide();
                txtbxDefinition.Hide();
                lblCCPicture.Hide();
                btnPickFile.Hide();

                //reveal new
                lblCCQuestions.Show();
                lblCCQExplanation.Text = $"All questions should answer with this card's term ({txtbxCCTerm.Text})";
                lblCCQExplanation.Show();
                txtbxCCQ1.Show();
                txtbxCCQ2.Show();
                txtbxCCQ3.Show();
            } else if (cardCreationStage == 2)
            {
                //hide old UI components
                lblCCQuestions.Hide();
                lblCCQExplanation.Hide();
                txtbxCCQ1.Hide();
                txtbxCCQ2.Hide();
                txtbxCCQ3.Hide();

                //reveal new
                lblCCFalse.Show();
                lblCCFExplanation.Show();
                txtbxCCF1.Show();
                txtbxCCF2.Show();
                txtbxCCF3.Show();
                txtbxCCF4.Show();
                txtbxCCF5.Show();
            } else if (cardCreationStage == 3)
            {
                //hide old UI components
                lblCCFalse.Hide();
                lblCCFExplanation.Hide();
                txtbxCCF1.Hide();
                txtbxCCF2.Hide();
                txtbxCCF3.Hide();
                txtbxCCF4.Hide();
                txtbxCCF5.Hide();

                //reveal new
                lblCCTags.Show();
                cmbCCT1.Show();
                cmbCCT2.Show();
                cmbCCT3.Show();
            }

            if (cardCreationStage < 4)
            {
                //resize etc
                Point nextButtonLocation = new Point(12, (nextPosition[cardCreationStage]));
                btnCCNext.Location = nextButtonLocation;

                this.Height = panelHeight[cardCreationStage];
            }
        }

        //fully functional
        public void createFlashcard()
        {
            //run required procedures to get the information required
            int CardID = findAvailableCardID();
            string[] cardParameters = inpCardParameters();

            //sort through the parameters and makes them into usable data
            string term = cardParameters[0];
            string definition = cardParameters[1];
            string pictureAddress = cardParameters[2];
            //loops through the question values because it makes my code easier to split up
            string[] questions = new string[3];
            for (int c = 3; c < 6; c++)
            {
                questions[c-3] = cardParameters[c];
            }
            //loops through false answer values for easier reading
            string[] falseAnswers = new string[5];
            for (int c = 6; c < 11; c++)
            {
                falseAnswers[c-6] = cardParameters[c];
            }
            //get the tags list
            int[] tags = new int[3];
            tags = inpCardTags();
            //set up the successRate
            //sets the successful attempts to 1 as otherwise it won't get picked
            int[] successRate = new int[2];
            successRate[0] = 0;
            successRate[1] = 1;

            //create the flashcard object
            Flashcard CurrentlyAddingFlashcard = new Flashcard(CardID, term, definition, pictureAddress, questions, falseAnswers, tags, successRate);
            //add this card to the hashtable
            //I am safe to override the flashcard object here as the dictionary effectively stores a snapshot
            CardsDictionary.Add(CurrentlyAddingFlashcard.ID, CurrentlyAddingFlashcard);

            appendCardToFile(CurrentlyAddingFlashcard.ID);
        }

        //fully functional
        public static int findAvailableCardID()
        {
            //initial setup of variables
            //this count returns the count from 1 not 0
            int TotalLength = CardsDictionary.Count;
            int Check = 0;
            bool Valid = false;



            //leonard the leopard is the reason this works
            //loops until a valid value is found
            do
            {
                if (CardsDictionary.ContainsKey(Check))
                {
                    //ID is taken
                    Check++;
                }
                else
                {
                    //is free, break loop
                    Valid = true;
                }
                //else the ID is free
            } while (Valid == false);
            //return the valid ID
            return Check;
        }

        //fully functional
        public string[] inpCardParameters()
        {
            //initial setup of return array
            //values are as follows (for easier reference)
            //term, definition, picLocation, Q1, Q2, Q3, FA1, FA2, FA3, FA4, FA5
            string[] returnValues = new string[11];

            //read the values from textboxes
            returnValues[0] = txtbxCCTerm.Text;
            returnValues[1] = txtbxDefinition.Text;
            returnValues[2] = imageFileAddress;
            returnValues[3] = txtbxCCQ1.Text;
            returnValues[4] = txtbxCCQ2.Text;
            returnValues[5] = txtbxCCQ3.Text;
            returnValues[6] = txtbxCCF1.Text;
            returnValues[7] = txtbxCCF2.Text;
            returnValues[8] = txtbxCCF3.Text;
            returnValues[9] = txtbxCCF4.Text;
            returnValues[10] = txtbxCCF5.Text;

            //return the array, the values will need to be #
            //edited to fit in a flashcard object
            return returnValues;
        }

        


        //setup the comboboxes
        public string[] tagsArray;
        //fully functional
        public void setUpCMBBX()
        {
            //reads in all the tags as lines of an array
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Tags.txt";
            tagsArray = System.IO.File.ReadAllLines(fileAddress);
            int totalTags = tagsArray.Length;

            cmbCCT1.Items.Clear();
            for (int c = 0; c < totalTags; c++) {
                cmbCCT1.Items.Add(tagsArray[c]);
            }

            cmbCCT2.Items.Clear();
            for (int c = 0; c < totalTags; c++) {
                cmbCCT2.Items.Add(tagsArray[c]);
            }

            cmbCCT3.Items.Clear();
            for (int c = 0; c < totalTags; c++)
            {
                cmbCCT3.Items.Add(tagsArray[c]);
            }
        }

        //fully functional
        public int[] inpCardTags()
        {
            int[] returnValues = new int[3];

            //gets the index of the selectors
            //this is much simpler than my pseudocode
            returnValues[0] = cmbCCT1.SelectedIndex;
            returnValues [1] = cmbCCT2.SelectedIndex;
            returnValues[2] = cmbCCT3.SelectedIndex;

            return returnValues;
        }

        //fully functional
        public async Task appendCardToFile(int cardIDToAppend)
        {
            //set the address to a constant to make it a bit easier to edit :)
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Flashcards.txt";

            //sets the file to append and states the file to append to
            using StreamWriter file = new(fileAddress, append: true);
            //formats the data appropriately for the file
            //create a flashcard object with the data temporarily
            Flashcard tempFlashcard = CardsDictionary[cardIDToAppend]; 
            string textToWrite = (tempFlashcard.ID).ToString() + "#~#" + (tempFlashcard.term) + "#~#" + (tempFlashcard.definition)
                + "#~#" + (tempFlashcard.pictureLocation) + "#~#" + (tempFlashcard.questions[0]) + "#~#" + (tempFlashcard.questions[1]) +
                "#~#" + (tempFlashcard.questions[2]) + "#~#" + (tempFlashcard.falseAnswers[0]) + "#~#" + (tempFlashcard.falseAnswers[1]) +
                "#~#" + (tempFlashcard.falseAnswers[2]) + "#~#" + (tempFlashcard.falseAnswers[3]) + "#~#" + (tempFlashcard.falseAnswers[4]) +
                "#~#" + (tempFlashcard.tags[0]) + "#~#" + (tempFlashcard.tags[1]) + "#~#" + (tempFlashcard.tags[2]) + "#~#" + 
                (tempFlashcard.successRate[0]) + "#~#" + (tempFlashcard.successRate[1]) + "#~#";
            //appends the given value to the file
            await file.WriteLineAsync(textToWrite);
        }

        private void btnPickFile_Click(object sender, EventArgs e)
        {
            //open the file picker
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //starts in the base c: drive
            openFileDialog.InitialDirectory = "c:\\";
            //ensures only image files can be chosen
            openFileDialog.Filter = "Image files (*.png, *.jpeg, *.jpg)|*.png;*.jpeg;*.jpg";
            //other assorted filtering
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //the final stirng
                imageFileAddress = openFileDialog.FileName;
            }
        }
    }
}
