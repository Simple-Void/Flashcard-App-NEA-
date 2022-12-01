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
        public Graphing_UI(Dictionary<int, Flashcard> _cardsDictionary, Dictionary<int, Set> _setsDictionary)
        {
            InitializeComponent();
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
            Pen pGreen = new Pen(Color.Green);
            pGreen.Width = 2.0F;
            Brush bGreen = new SolidBrush(Color.Green);
            Pen pRed = new Pen(Color.Red);
            pRed.Width = 2.0F;
            Brush bRed = new SolidBrush(Color.Red);

            //draw the white background
            panel.FillRectangle(bWhite, 0, 0, 574, 451);
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
            graphPanel.Invalidate();
        }
    }
}
