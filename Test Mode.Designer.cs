namespace NEA_Project_UI
{
    partial class Test_Mode_UI
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
            this.lblTMQuestion = new System.Windows.Forms.Label();
            this.lblTMTimer = new System.Windows.Forms.Label();
            this.rdbtnTMQ1 = new System.Windows.Forms.RadioButton();
            this.rdbtnTMQ2 = new System.Windows.Forms.RadioButton();
            this.rdbtnTMQ3 = new System.Windows.Forms.RadioButton();
            this.rdbtnTMQ4 = new System.Windows.Forms.RadioButton();
            this.btnTMSubmit = new System.Windows.Forms.Button();
            this.btnTMQuit = new System.Windows.Forms.Button();
            this.countUpComponent = new System.Windows.Forms.Timer(this.components);
            this.pcbxCardPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxCardPic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTMQuestion
            // 
            this.lblTMQuestion.Location = new System.Drawing.Point(12, 9);
            this.lblTMQuestion.Name = "lblTMQuestion";
            this.lblTMQuestion.Size = new System.Drawing.Size(472, 25);
            this.lblTMQuestion.TabIndex = 0;
            this.lblTMQuestion.Text = "Really Extra Mega Extraordinarily Length and Long Question Content?";
            // 
            // lblTMTimer
            // 
            this.lblTMTimer.Location = new System.Drawing.Point(490, 9);
            this.lblTMTimer.Name = "lblTMTimer";
            this.lblTMTimer.Size = new System.Drawing.Size(152, 25);
            this.lblTMTimer.TabIndex = 2;
            this.lblTMTimer.Text = "timer text";
            this.lblTMTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbtnTMQ1
            // 
            this.rdbtnTMQ1.AutoSize = true;
            this.rdbtnTMQ1.Location = new System.Drawing.Point(12, 37);
            this.rdbtnTMQ1.Name = "rdbtnTMQ1";
            this.rdbtnTMQ1.Size = new System.Drawing.Size(88, 24);
            this.rdbtnTMQ1.TabIndex = 3;
            this.rdbtnTMQ1.TabStop = true;
            this.rdbtnTMQ1.Text = "Option 1";
            this.rdbtnTMQ1.UseVisualStyleBackColor = true;
            // 
            // rdbtnTMQ2
            // 
            this.rdbtnTMQ2.AutoSize = true;
            this.rdbtnTMQ2.Location = new System.Drawing.Point(12, 67);
            this.rdbtnTMQ2.Name = "rdbtnTMQ2";
            this.rdbtnTMQ2.Size = new System.Drawing.Size(88, 24);
            this.rdbtnTMQ2.TabIndex = 4;
            this.rdbtnTMQ2.TabStop = true;
            this.rdbtnTMQ2.Text = "Option 2";
            this.rdbtnTMQ2.UseVisualStyleBackColor = true;
            // 
            // rdbtnTMQ3
            // 
            this.rdbtnTMQ3.AutoSize = true;
            this.rdbtnTMQ3.Location = new System.Drawing.Point(12, 97);
            this.rdbtnTMQ3.Name = "rdbtnTMQ3";
            this.rdbtnTMQ3.Size = new System.Drawing.Size(88, 24);
            this.rdbtnTMQ3.TabIndex = 5;
            this.rdbtnTMQ3.TabStop = true;
            this.rdbtnTMQ3.Text = "Option 3";
            this.rdbtnTMQ3.UseVisualStyleBackColor = true;
            // 
            // rdbtnTMQ4
            // 
            this.rdbtnTMQ4.AutoSize = true;
            this.rdbtnTMQ4.Location = new System.Drawing.Point(12, 127);
            this.rdbtnTMQ4.Name = "rdbtnTMQ4";
            this.rdbtnTMQ4.Size = new System.Drawing.Size(88, 24);
            this.rdbtnTMQ4.TabIndex = 6;
            this.rdbtnTMQ4.TabStop = true;
            this.rdbtnTMQ4.Text = "Option 4";
            this.rdbtnTMQ4.UseVisualStyleBackColor = true;
            // 
            // btnTMSubmit
            // 
            this.btnTMSubmit.Location = new System.Drawing.Point(12, 157);
            this.btnTMSubmit.Name = "btnTMSubmit";
            this.btnTMSubmit.Size = new System.Drawing.Size(472, 93);
            this.btnTMSubmit.TabIndex = 7;
            this.btnTMSubmit.Text = "SUBMIT";
            this.btnTMSubmit.UseVisualStyleBackColor = true;
            this.btnTMSubmit.Click += new System.EventHandler(this.btnTMSubmit_Click);
            // 
            // btnTMQuit
            // 
            this.btnTMQuit.Location = new System.Drawing.Point(489, 157);
            this.btnTMQuit.Name = "btnTMQuit";
            this.btnTMQuit.Size = new System.Drawing.Size(156, 93);
            this.btnTMQuit.TabIndex = 8;
            this.btnTMQuit.Text = "QUIT";
            this.btnTMQuit.UseVisualStyleBackColor = true;
            this.btnTMQuit.Click += new System.EventHandler(this.btnTMQuit_Click);
            // 
            // countUpComponent
            // 
            this.countUpComponent.Tick += new System.EventHandler(this.countUpComponent_Tick);
            // 
            // pcbxCardPic
            // 
            this.pcbxCardPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbxCardPic.InitialImage = null;
            this.pcbxCardPic.Location = new System.Drawing.Point(510, 37);
            this.pcbxCardPic.Name = "pcbxCardPic";
            this.pcbxCardPic.Size = new System.Drawing.Size(115, 115);
            this.pcbxCardPic.TabIndex = 9;
            this.pcbxCardPic.TabStop = false;
            // 
            // Test_Mode_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 261);
            this.Controls.Add(this.pcbxCardPic);
            this.Controls.Add(this.btnTMQuit);
            this.Controls.Add(this.btnTMSubmit);
            this.Controls.Add(this.rdbtnTMQ4);
            this.Controls.Add(this.rdbtnTMQ3);
            this.Controls.Add(this.rdbtnTMQ2);
            this.Controls.Add(this.rdbtnTMQ1);
            this.Controls.Add(this.lblTMTimer);
            this.Controls.Add(this.lblTMQuestion);
            this.Name = "Test_Mode_UI";
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.pcbxCardPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTMQuestion;
        private Label lblTMTimer;
        private RadioButton rdbtnTMQ1;
        private RadioButton rdbtnTMQ2;
        private RadioButton rdbtnTMQ3;
        private RadioButton rdbtnTMQ4;
        private Button btnTMSubmit;
        private Button btnTMQuit;
        private System.Windows.Forms.Timer countUpComponent;
        private PictureBox pcbxCardPic;
    }
}