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
            this.button1 = new System.Windows.Forms.Button();
            this.btnGQuit = new System.Windows.Forms.Button();
            this.lblTotalTests = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.Location = new System.Drawing.Point(12, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(574, 451);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Click += new System.EventHandler(this.graphPanel_Click);
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(600, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "IMPORT TEST";
            this.button1.UseVisualStyleBackColor = true;
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
            this.lblTotalTests.Location = new System.Drawing.Point(600, 44);
            this.lblTotalTests.Name = "lblTotalTests";
            this.lblTotalTests.Size = new System.Drawing.Size(188, 56);
            this.lblTotalTests.TabIndex = 11;
            this.lblTotalTests.Text = "0/8 Tests Displayed";
            this.lblTotalTests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Graphing_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.lblTotalTests);
            this.Controls.Add(this.btnGQuit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.graphPanel);
            this.Name = "Graphing_UI";
            this.Text = "Graphing";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel graphPanel;
        private Button button1;
        private Button btnGQuit;
        private Label lblTotalTests;
    }
}