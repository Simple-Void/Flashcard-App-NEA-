namespace NEA_Project_UI
{
    partial class Main_Menu_UI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCrtCrd = new System.Windows.Forms.Button();
            this.btnCrtSt = new System.Windows.Forms.Button();
            this.txtbxMMSearch = new System.Windows.Forms.TextBox();
            this.btnMMSearch = new System.Windows.Forms.Button();
            this.btnRev = new System.Windows.Forms.Button();
            this.btnQuiz = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnMMQuit = new System.Windows.Forms.Button();
            this.btnMMTeacher = new System.Windows.Forms.Button();
            this.lstvwSets = new System.Windows.Forms.ListView();
            this.SetID = new System.Windows.Forms.ColumnHeader();
            this.SetName = new System.Windows.Forms.ColumnHeader();
            this.Resources = new System.Windows.Forms.ColumnHeader();
            this.lstvwCards = new System.Windows.Forms.ListView();
            this.CardID = new System.Windows.Forms.ColumnHeader();
            this.CardTerm = new System.Windows.Forms.ColumnHeader();
            this.CardDefinition = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnCrtCrd
            // 
            this.btnCrtCrd.Location = new System.Drawing.Point(696, 45);
            this.btnCrtCrd.Name = "btnCrtCrd";
            this.btnCrtCrd.Size = new System.Drawing.Size(188, 29);
            this.btnCrtCrd.TabIndex = 0;
            this.btnCrtCrd.Text = "CREATE CARD";
            this.btnCrtCrd.UseVisualStyleBackColor = true;
            this.btnCrtCrd.Click += new System.EventHandler(this.crtcrd_Click);
            // 
            // btnCrtSt
            // 
            this.btnCrtSt.Location = new System.Drawing.Point(696, 80);
            this.btnCrtSt.Name = "btnCrtSt";
            this.btnCrtSt.Size = new System.Drawing.Size(188, 29);
            this.btnCrtSt.TabIndex = 1;
            this.btnCrtSt.Text = "CREATE SET";
            this.btnCrtSt.UseVisualStyleBackColor = true;
            this.btnCrtSt.Click += new System.EventHandler(this.crtst_Click);
            // 
            // txtbxMMSearch
            // 
            this.txtbxMMSearch.Location = new System.Drawing.Point(9, 12);
            this.txtbxMMSearch.Name = "txtbxMMSearch";
            this.txtbxMMSearch.Size = new System.Drawing.Size(320, 27);
            this.txtbxMMSearch.TabIndex = 2;
            this.txtbxMMSearch.Text = "Search..";
            // 
            // btnMMSearch
            // 
            this.btnMMSearch.Location = new System.Drawing.Point(335, 10);
            this.btnMMSearch.Name = "btnMMSearch";
            this.btnMMSearch.Size = new System.Drawing.Size(29, 29);
            this.btnMMSearch.TabIndex = 3;
            this.btnMMSearch.Text = "S";
            this.btnMMSearch.UseVisualStyleBackColor = true;
            // 
            // btnRev
            // 
            this.btnRev.Location = new System.Drawing.Point(696, 480);
            this.btnRev.Name = "btnRev";
            this.btnRev.Size = new System.Drawing.Size(188, 29);
            this.btnRev.TabIndex = 6;
            this.btnRev.Text = "REVISE";
            this.btnRev.UseVisualStyleBackColor = true;
            this.btnRev.Click += new System.EventHandler(this.btnRev_Click);
            // 
            // btnQuiz
            // 
            this.btnQuiz.Location = new System.Drawing.Point(696, 515);
            this.btnQuiz.Name = "btnQuiz";
            this.btnQuiz.Size = new System.Drawing.Size(188, 29);
            this.btnQuiz.TabIndex = 7;
            this.btnQuiz.Text = "QUIZ";
            this.btnQuiz.UseVisualStyleBackColor = true;
            this.btnQuiz.Click += new System.EventHandler(this.btnQuiz_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(696, 550);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(188, 29);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnMMQuit
            // 
            this.btnMMQuit.Location = new System.Drawing.Point(696, 585);
            this.btnMMQuit.Name = "btnMMQuit";
            this.btnMMQuit.Size = new System.Drawing.Size(188, 58);
            this.btnMMQuit.TabIndex = 9;
            this.btnMMQuit.Text = "QUIT";
            this.btnMMQuit.UseVisualStyleBackColor = true;
            this.btnMMQuit.Click += new System.EventHandler(this.btnMMQuit_Click);
            // 
            // btnMMTeacher
            // 
            this.btnMMTeacher.Location = new System.Drawing.Point(696, 12);
            this.btnMMTeacher.Name = "btnMMTeacher";
            this.btnMMTeacher.Size = new System.Drawing.Size(188, 29);
            this.btnMMTeacher.TabIndex = 10;
            this.btnMMTeacher.Text = "LOGIN AS TEACHER";
            this.btnMMTeacher.UseVisualStyleBackColor = true;
            // 
            // lstvwSets
            // 
            this.lstvwSets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SetID,
            this.SetName,
            this.Resources});
            this.lstvwSets.FullRowSelect = true;
            this.lstvwSets.Location = new System.Drawing.Point(9, 45);
            this.lstvwSets.Name = "lstvwSets";
            this.lstvwSets.Size = new System.Drawing.Size(320, 596);
            this.lstvwSets.TabIndex = 11;
            this.lstvwSets.UseCompatibleStateImageBehavior = false;
            this.lstvwSets.View = System.Windows.Forms.View.Details;
            this.lstvwSets.SelectedIndexChanged += new System.EventHandler(this.lstvwSets_SelectedIndexChanged);
            // 
            // SetID
            // 
            this.SetID.Text = "ID";
            this.SetID.Width = 50;
            // 
            // SetName
            // 
            this.SetName.Text = "Name";
            this.SetName.Width = 135;
            // 
            // Resources
            // 
            this.Resources.Text = "Resources";
            this.Resources.Width = 135;
            // 
            // lstvwCards
            // 
            this.lstvwCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CardID,
            this.CardTerm,
            this.CardDefinition});
            this.lstvwCards.Location = new System.Drawing.Point(370, 12);
            this.lstvwCards.Name = "lstvwCards";
            this.lstvwCards.Size = new System.Drawing.Size(320, 631);
            this.lstvwCards.TabIndex = 12;
            this.lstvwCards.UseCompatibleStateImageBehavior = false;
            this.lstvwCards.View = System.Windows.Forms.View.Details;
            // 
            // CardID
            // 
            this.CardID.Text = "ID";
            this.CardID.Width = 50;
            // 
            // CardTerm
            // 
            this.CardTerm.Text = "Term";
            this.CardTerm.Width = 135;
            // 
            // CardDefinition
            // 
            this.CardDefinition.Text = "Definition";
            this.CardDefinition.Width = 135;
            // 
            // Main_Menu_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 653);
            this.Controls.Add(this.lstvwCards);
            this.Controls.Add(this.lstvwSets);
            this.Controls.Add(this.btnMMTeacher);
            this.Controls.Add(this.btnMMQuit);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnQuiz);
            this.Controls.Add(this.btnRev);
            this.Controls.Add(this.btnMMSearch);
            this.Controls.Add(this.txtbxMMSearch);
            this.Controls.Add(this.btnCrtSt);
            this.Controls.Add(this.btnCrtCrd);
            this.Name = "Main_Menu_UI";
            this.Text = "FlashCard App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCrtCrd;
        private Button btnCrtSt;
        private TextBox txtbxMMSearch;
        private Button btnMMSearch;
        private Button btnRev;
        private Button btnQuiz;
        private Button btnTest;
        private Button btnMMQuit;
        private Button btnMMTeacher;
        private ListView lstvwSets;
        private ListView lstvwCards;
        private ColumnHeader SetID;
        private ColumnHeader SetName;
        private ColumnHeader Resources;
        private ColumnHeader CardID;
        private ColumnHeader CardTerm;
        private ColumnHeader CardDefinition;
    }
}