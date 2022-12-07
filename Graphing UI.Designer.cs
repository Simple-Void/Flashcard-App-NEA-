namespace NEA_Project_UI
{
    partial class Graphing_UI
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
            this.graphPanel = new System.Windows.Forms.Panel();
            this.lbl100p = new System.Windows.Forms.Label();
            this.lbl75p = new System.Windows.Forms.Label();
            this.lbl50p = new System.Windows.Forms.Label();
            this.lbl25p = new System.Windows.Forms.Label();
            this.lbl0p = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnGQuit = new System.Windows.Forms.Button();
            this.lblTotalTests = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstbxTestNames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.graphPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.Controls.Add(this.lbl100p);
            this.graphPanel.Controls.Add(this.lbl75p);
            this.graphPanel.Controls.Add(this.lbl50p);
            this.graphPanel.Controls.Add(this.lbl25p);
            this.graphPanel.Controls.Add(this.lbl0p);
            this.graphPanel.Location = new System.Drawing.Point(12, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(574, 451);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Click += new System.EventHandler(this.graphPanel_Click);
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint_1);
            // 
            // lbl100p
            // 
            this.lbl100p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl100p.AutoSize = true;
            this.lbl100p.BackColor = System.Drawing.Color.White;
            this.lbl100p.Location = new System.Drawing.Point(15, 15);
            this.lbl100p.Name = "lbl100p";
            this.lbl100p.Size = new System.Drawing.Size(45, 20);
            this.lbl100p.TabIndex = 4;
            this.lbl100p.Text = "100%";
            this.lbl100p.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl75p
            // 
            this.lbl75p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl75p.AutoSize = true;
            this.lbl75p.BackColor = System.Drawing.Color.White;
            this.lbl75p.Location = new System.Drawing.Point(15, 115);
            this.lbl75p.Name = "lbl75p";
            this.lbl75p.Size = new System.Drawing.Size(37, 20);
            this.lbl75p.TabIndex = 3;
            this.lbl75p.Text = "75%";
            this.lbl75p.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl50p
            // 
            this.lbl50p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl50p.AutoSize = true;
            this.lbl50p.BackColor = System.Drawing.Color.White;
            this.lbl50p.Location = new System.Drawing.Point(15, 215);
            this.lbl50p.Name = "lbl50p";
            this.lbl50p.Size = new System.Drawing.Size(37, 20);
            this.lbl50p.TabIndex = 2;
            this.lbl50p.Text = "50%";
            this.lbl50p.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl25p
            // 
            this.lbl25p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl25p.AutoSize = true;
            this.lbl25p.BackColor = System.Drawing.Color.White;
            this.lbl25p.Location = new System.Drawing.Point(15, 315);
            this.lbl25p.Name = "lbl25p";
            this.lbl25p.Size = new System.Drawing.Size(37, 20);
            this.lbl25p.TabIndex = 1;
            this.lbl25p.Text = "25%";
            this.lbl25p.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl0p
            // 
            this.lbl0p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0p.AutoSize = true;
            this.lbl0p.BackColor = System.Drawing.Color.White;
            this.lbl0p.Location = new System.Drawing.Point(15, 415);
            this.lbl0p.Name = "lbl0p";
            this.lbl0p.Size = new System.Drawing.Size(29, 20);
            this.lbl0p.TabIndex = 0;
            this.lbl0p.Text = "0%";
            this.lbl0p.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(600, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(188, 29);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "IMPORT TEST";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnGQuit
            // 
            this.btnGQuit.Location = new System.Drawing.Point(600, 405);
            this.btnGQuit.Name = "btnGQuit";
            this.btnGQuit.Size = new System.Drawing.Size(188, 58);
            this.btnGQuit.TabIndex = 10;
            this.btnGQuit.Text = "QUIT";
            this.btnGQuit.UseVisualStyleBackColor = true;
            this.btnGQuit.Click += new System.EventHandler(this.btnGQuit_Click);
            // 
            // lblTotalTests
            // 
            this.lblTotalTests.Location = new System.Drawing.Point(600, 79);
            this.lblTotalTests.Name = "lblTotalTests";
            this.lblTotalTests.Size = new System.Drawing.Size(188, 50);
            this.lblTotalTests.TabIndex = 11;
            this.lblTotalTests.Text = "0/8 Tests Displayed";
            this.lblTotalTests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(600, 47);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(188, 29);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "CLEAR DATA";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lstbxTestNames
            // 
            this.lstbxTestNames.FormattingEnabled = true;
            this.lstbxTestNames.ItemHeight = 20;
            this.lstbxTestNames.Location = new System.Drawing.Point(600, 235);
            this.lstbxTestNames.Name = "lstbxTestNames";
            this.lstbxTestNames.Size = new System.Drawing.Size(188, 164);
            this.lstbxTestNames.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(600, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "Test Names (L to R)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Graphing_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstbxTestNames);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotalTests);
            this.Controls.Add(this.btnGQuit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.graphPanel);
            this.Name = "Graphing_UI";
            this.Text = "Graphing";
            this.graphPanel.ResumeLayout(false);
            this.graphPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel graphPanel;
        private Button btnImport;
        private Button btnGQuit;
        private Label lblTotalTests;
        private Button btnClear;
        private Label lbl0p;
        private Label lbl25p;
        private Label lbl100p;
        private Label lbl75p;
        private Label lbl50p;
        private ListBox lstbxTestNames;
        private Label label1;
    }
}