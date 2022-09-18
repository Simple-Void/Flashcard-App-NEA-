namespace NEA_Project_UI
{
    partial class Quiz_Mode_UI
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
            this.components = new System.ComponentModel.Container();
            this.btnQMFlashCard = new System.Windows.Forms.Button();
            this.lblQMTimer = new System.Windows.Forms.Label();
            this.btnQMQuit = new System.Windows.Forms.Button();
            this.lblQMCardCount = new System.Windows.Forms.Label();
            this.countUpComponent = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnQMFlashCard
            // 
            this.btnQMFlashCard.Location = new System.Drawing.Point(12, 12);
            this.btnQMFlashCard.Name = "btnQMFlashCard";
            this.btnQMFlashCard.Size = new System.Drawing.Size(630, 420);
            this.btnQMFlashCard.TabIndex = 1;
            this.btnQMFlashCard.Text = "flashcard data";
            this.btnQMFlashCard.UseVisualStyleBackColor = true;
            this.btnQMFlashCard.Click += new System.EventHandler(this.btnQMFlashCard_Click);
            // 
            // lblQMTimer
            // 
            this.lblQMTimer.Location = new System.Drawing.Point(648, 12);
            this.lblQMTimer.Name = "lblQMTimer";
            this.lblQMTimer.Size = new System.Drawing.Size(140, 93);
            this.lblQMTimer.TabIndex = 4;
            this.lblQMTimer.Text = "timer text";
            this.lblQMTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQMQuit
            // 
            this.btnQMQuit.Location = new System.Drawing.Point(648, 339);
            this.btnQMQuit.Name = "btnQMQuit";
            this.btnQMQuit.Size = new System.Drawing.Size(140, 93);
            this.btnQMQuit.TabIndex = 3;
            this.btnQMQuit.Text = "QUIT";
            this.btnQMQuit.UseVisualStyleBackColor = true;
            this.btnQMQuit.Click += new System.EventHandler(this.btnQMQuit_Click);
            // 
            // lblQMCardCount
            // 
            this.lblQMCardCount.Location = new System.Drawing.Point(648, 105);
            this.lblQMCardCount.Name = "lblQMCardCount";
            this.lblQMCardCount.Size = new System.Drawing.Size(140, 25);
            this.lblQMCardCount.TabIndex = 5;
            this.lblQMCardCount.Text = "Card 1/23";
            this.lblQMCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // countUpComponent
            // 
            this.countUpComponent.Tick += new System.EventHandler(this.countUpComponent_Tick);
            // 
            // Quiz_Mode_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.lblQMCardCount);
            this.Controls.Add(this.lblQMTimer);
            this.Controls.Add(this.btnQMQuit);
            this.Controls.Add(this.btnQMFlashCard);
            this.Name = "Quiz_Mode_UI";
            this.Text = "Quiz";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnQMFlashCard;
        private Label lblQMTimer;
        private Button btnQMQuit;
        private Label lblQMCardCount;
        private System.Windows.Forms.Timer countUpComponent;
    }
}