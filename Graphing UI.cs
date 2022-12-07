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
    public partial class Graphing_UI : Form
    {
        //global arrays for the success % of any class test
        List<TestData> TestDataDictionary = new List<TestData>();
        int importedFiles = 0;

        public Graphing_UI(Dictionary<int, Flashcard> _cardsDictionary, Dictionary<int, Set> _setsDictionary)
        {
            InitializeComponent();
            //clear any dictionaries from past loads
            TestDataDictionary.Clear();
        }

        //closes the window
        //works 
        private void btnGQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void graphPanel_Paint_1(object sender, PaintEventArgs e)
        {
            //set up the panel and the background colour
            Graphics panel = graphPanel.CreateGraphics();
            Pen pWhite = new Pen(Color.White);
            pWhite.Width = 2.0F;
            Brush bWhite = new SolidBrush(Color.White);
            Pen pBlack = new Pen(Color.Black);
            pBlack.Width = 2.0F;
            Brush bBlack = new SolidBrush(Color.Black);
            Pen pGreen = new Pen(Color.DarkSeaGreen);
            pGreen.Width = 2.0F;
            Brush bGreen = new SolidBrush(Color.DarkSeaGreen);
            Pen pRed = new Pen(Color.PaleVioletRed);
            pRed.Width = 2.0F;
            Brush bRed = new SolidBrush(Color.PaleVioletRed);

            //thsi brush will be changed to match the others for more compact code
            Brush currentBrush = new SolidBrush(Color.White);

            //draw the white background
            panel.FillRectangle(bWhite, 0, 0, 574, 451);

            //draw data
            if (TestDataDictionary.Count > 0)
            {
                int Width = 500 / TestDataDictionary.Count;
                float Height = 0;
                for (int c = 0; c <= TestDataDictionary.Count()-1; c++)
                {
                    //Height is 400 divided by the total number of cards in the set (correct + incorrect) and multiplied by correct
                    Height = (400 * TestDataDictionary[c].correct) / (TestDataDictionary[c].correct + TestDataDictionary[c].incorrect);
                    //70 is the bottom left of the graph
                    //25 is the top of the y axis

                    if (TestDataDictionary[c].outOfTime == true)
                    {
                        currentBrush = bRed;
                    } else
                    {
                        currentBrush = bGreen;
                    }
                    panel.FillRectangle(currentBrush, (70 + (c * Width)), 25 + (400 - Height), (500 / TestDataDictionary.Count()) - 5, Height);
                }
            }

            //draw the axis after the data to ensure a neat bottom of the graph :)
            //draw the default axis
            //horizontal
            panel.DrawLine(pBlack, 70, 425, 570, 425);
            //vertical
            panel.DrawLine(pBlack, 70, 25, 70, 425);
            //axis key up the side
            panel.DrawLine(pBlack, 60, 25, 70, 25);
            panel.DrawLine(pBlack, 60, 125, 70, 125);
            panel.DrawLine(pBlack, 60, 225, 70, 225);
            panel.DrawLine(pBlack, 60, 325, 70, 325);
            panel.DrawLine(pBlack, 60, 425, 70, 425);
        }

        private void graphPanel_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            //forces the panel to redraw itself
            graphPanel.Invalidate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //empties the array and redraws the graph
            TestDataDictionary.Clear();
            refresh();
            lblTotalTests.Text = ($"{importedFiles}/8 Tests Displayed");
            lstbxTestNames.Items.Clear();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string dataAddress = "";
            string testName = "";
            bool outOfTime = false;
            int correct = 0;
            int incorrect = 0;
            //open file explorer
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //starts in the base c: drive
            openFileDialog.InitialDirectory = @"C:\Users\Public\FlashcardAppData\";
            //ensures only text files can be chosen
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            //other assorted filtering
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (importedFiles >= 8)
            {
                MessageBox.Show("Cannot import any more files, please clear the graph first");
            } else
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //the file name strings
                    dataAddress = openFileDialog.FileName;
                    testName = System.IO.Path.GetFileNameWithoutExtension(dataAddress);
                    //read file and check validity (bool, int, int)
                    //add to the list
                    string[] allLines = File.ReadAllLines(dataAddress);
                    //nested ifs to avoid unnecessary CPU time and error check the file
                    if (allLines.Count() < 3)
                    {
                        MessageBox.Show("There are not enough lines in the file", "Invalid File Selection");
                    }
                    else
                    {
                        //first line is boolean
                        if (!bool.TryParse(allLines[0], out bool placeholder)
                            || !int.TryParse(allLines[1], out int _placeholder)
                            || !int.TryParse(allLines[2], out _placeholder))
                        {
                            MessageBox.Show("invalid file contents", "Invalid File Selection");
                        }
                        else
                        {
                            //read bool line
                            outOfTime = bool.Parse(allLines[0]);
                            //read int line
                            correct = int.Parse(allLines[1]);
                            //read int line
                            incorrect = int.Parse(allLines[2]);
                            //create the object and add to the dictionary
                            TestData TempTestData = new TestData(outOfTime, correct, incorrect);
                            TestDataDictionary.Add(TempTestData);
                            refresh();
                            importedFiles++;
                            lblTotalTests.Text = ($"{importedFiles}/8 Tests Displayed");
                            lstbxTestNames.Items.Add(testName);
                        }
                    }
                }
            }
        }
    }
}
