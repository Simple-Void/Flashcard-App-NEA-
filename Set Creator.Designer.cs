namespace NEA_Project_UI
{
    partial class Set_Creator_UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSCName = new System.Windows.Forms.Label();
            this.txtbxSCName = new System.Windows.Forms.TextBox();
            this.lblSCResources = new System.Windows.Forms.Label();
            this.txtbxSCResources = new System.Windows.Forms.TextBox();
            this.btnSCNext = new System.Windows.Forms.Button();
            this.lblSCCards = new System.Windows.Forms.Label();
            this.txtbxSCSearch = new System.Windows.Forms.TextBox();
            this.btnSCSearch = new System.Windows.Forms.Button();
            this.lstVCards = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.Term = new System.Windows.Forms.ColumnHeader();
            this.Definition = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblSCName
            // 
            this.lblSCName.AutoSize = true;
            this.lblSCName.Location = new System.Drawing.Point(12, 9);
            this.lblSCName.Name = "lblSCName";
            this.lblSCName.Size = new System.Drawing.Size(77, 20);
            this.lblSCName.TabIndex = 0;
            this.lblSCName.Text = "Set Name:";
            // 
            // txtbxSCName
            // 
            this.txtbxSCName.Location = new System.Drawing.Point(12, 32);
            this.txtbxSCName.Name = "txtbxSCName";
            this.txtbxSCName.Size = new System.Drawing.Size(481, 27);
            this.txtbxSCName.TabIndex = 1;
            // 
            // lblSCResources
            // 
            this.lblSCResources.AutoSize = true;
            this.lblSCResources.Location = new System.Drawing.Point(12, 62);
            this.lblSCResources.Name = "lblSCResources";
            this.lblSCResources.Size = new System.Drawing.Size(103, 20);
            this.lblSCResources.TabIndex = 2;
            this.lblSCResources.Text = "Set Resources:";
            // 
            // txtbxSCResources
            // 
            this.txtbxSCResources.Location = new System.Drawing.Point(12, 85);
            this.txtbxSCResources.Name = "txtbxSCResources";
            this.txtbxSCResources.Size = new System.Drawing.Size(481, 27);
            this.txtbxSCResources.TabIndex = 3;
            // 
            // btnSCNext
            // 
            this.btnSCNext.Location = new System.Drawing.Point(12, 612);
            this.btnSCNext.Name = "btnSCNext";
            this.btnSCNext.Size = new System.Drawing.Size(481, 29);
            this.btnSCNext.TabIndex = 4;
            this.btnSCNext.Text = "NEXT";
            this.btnSCNext.UseVisualStyleBackColor = true;
            this.btnSCNext.Click += new System.EventHandler(this.btnSCNext_Click);
            // 
            // lblSCCards
            // 
            this.lblSCCards.AutoSize = true;
            this.lblSCCards.Location = new System.Drawing.Point(12, 9);
            this.lblSCCards.Name = "lblSCCards";
            this.lblSCCards.Size = new System.Drawing.Size(124, 20);
            this.lblSCCards.TabIndex = 5;
            this.lblSCCards.Text = "Add Cards to Set:";
            // 
            // txtbxSCSearch
            // 
            this.txtbxSCSearch.Location = new System.Drawing.Point(11, 32);
            this.txtbxSCSearch.Name = "txtbxSCSearch";
            this.txtbxSCSearch.Size = new System.Drawing.Size(447, 27);
            this.txtbxSCSearch.TabIndex = 6;
            // 
            // btnSCSearch
            // 
            this.btnSCSearch.Location = new System.Drawing.Point(464, 30);
            this.btnSCSearch.Name = "btnSCSearch";
            this.btnSCSearch.Size = new System.Drawing.Size(29, 29);
            this.btnSCSearch.TabIndex = 7;
            this.btnSCSearch.Text = "S";
            this.btnSCSearch.UseVisualStyleBackColor = true;
            // 
            // lstVCards
            // 
            this.lstVCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Term,
            this.Definition});
            this.lstVCards.Location = new System.Drawing.Point(12, 65);
            this.lstVCards.Name = "lstVCards";
            this.lstVCards.Size = new System.Drawing.Size(481, 541);
            this.lstVCards.TabIndex = 9;
            this.lstVCards.UseCompatibleStateImageBehavior = false;
            this.lstVCards.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 51;
            // 
            // Term
            // 
            this.Term.Text = "Term";
            this.Term.Width = 215;
            // 
            // Definition
            // 
            this.Definition.Text = "Definition";
            this.Definition.Width = 215;
            // 
            // Set_Creator_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 653);
            this.Controls.Add(this.lstVCards);
            this.Controls.Add(this.btnSCSearch);
            this.Controls.Add(this.txtbxSCSearch);
            this.Controls.Add(this.lblSCCards);
            this.Controls.Add(this.btnSCNext);
            this.Controls.Add(this.txtbxSCResources);
            this.Controls.Add(this.lblSCResources);
            this.Controls.Add(this.txtbxSCName);
            this.Controls.Add(this.lblSCName);
            this.Name = "Set_Creator_UI";
            this.Text = "Set Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSCName;
        private TextBox txtbxSCName;
        private Label lblSCResources;
        private TextBox txtbxSCResources;
        private Button btnSCNext;
        private Label lblSCCards;
        private TextBox txtbxSCSearch;
        private Button btnSCSearch;
        private ListView lstVCards;
        private ColumnHeader ID;
        private ColumnHeader Term;
        private ColumnHeader Definition;
    }
}