namespace NEA_Project_UI
{
    partial class Revise_Mode_UI
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
            this.btnRMFlashCard = new System.Windows.Forms.Button();
            this.btnRMQuit = new System.Windows.Forms.Button();
            this.lblRMTimer = new System.Windows.Forms.Label();
            this.countUpComponent = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnRMFlashCard
            // 
            this.btnRMFlashCard.Location = new System.Drawing.Point(12, 12);
            this.btnRMFlashCard.Name = "btnRMFlashCard";
            this.btnRMFlashCard.Size = new System.Drawing.Size(630, 420);
            this.btnRMFlashCard.TabIndex = 0;
            this.btnRMFlashCard.Text = "flashcard data";
            this.btnRMFlashCard.UseVisualStyleBackColor = true;
            this.btnRMFlashCard.Click += new System.EventHandler(this.btnRMFlashCard_Click);
            // 
            // btnRMQuit
            // 
            this.btnRMQuit.Location = new System.Drawing.Point(648, 339);
            this.btnRMQuit.Name = "btnRMQuit";
            this.btnRMQuit.Size = new System.Drawing.Size(140, 93);
            this.btnRMQuit.TabIndex = 1;
            this.btnRMQuit.Text = "QUIT";
            this.btnRMQuit.UseVisualStyleBackColor = true;
            this.btnRMQuit.Click += new System.EventHandler(this.btnRMQuit_Click);
            // 
            // lblRMTimer
            // 
            this.lblRMTimer.Location = new System.Drawing.Point(648, 12);
            this.lblRMTimer.Name = "lblRMTimer";
            this.lblRMTimer.Size = new System.Drawing.Size(140, 93);
            this.lblRMTimer.TabIndex = 2;
            this.lblRMTimer.Text = "timer text";
            this.lblRMTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Revise_Mode_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.lblRMTimer);
            this.Controls.Add(this.btnRMQuit);
            this.Controls.Add(this.btnRMFlashCard);
            this.Name = "Revise_Mode_UI";
            this.Text = "Revise";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRMFlashCard;
        private Button btnRMQuit;
        private Label lblRMTimer;
        private System.Windows.Forms.Timer countUpComponent;
    }
}