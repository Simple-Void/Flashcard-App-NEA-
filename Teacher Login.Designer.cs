namespace NEA_Project_UI
{
    partial class Teacher_Login_UI
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
            this.txtbxUsername = new System.Windows.Forms.TextBox();
            this.txtbxPassword = new System.Windows.Forms.TextBox();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lblU = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.chkbxCreate = new System.Windows.Forms.CheckBox();
            this.btnLoginorCreate = new System.Windows.Forms.Button();
            this.lblAC = new System.Windows.Forms.Label();
            this.txtbxAC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtbxUsername
            // 
            this.txtbxUsername.Location = new System.Drawing.Point(12, 32);
            this.txtbxUsername.Name = "txtbxUsername";
            this.txtbxUsername.Size = new System.Drawing.Size(429, 27);
            this.txtbxUsername.TabIndex = 0;
            // 
            // txtbxPassword
            // 
            this.txtbxPassword.Location = new System.Drawing.Point(12, 85);
            this.txtbxPassword.Name = "txtbxPassword";
            this.txtbxPassword.PasswordChar = '*';
            this.txtbxPassword.Size = new System.Drawing.Size(429, 27);
            this.txtbxPassword.TabIndex = 1;
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(12, 138);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(429, 27);
            this.txtPasswordConfirm.TabIndex = 2;
            // 
            // lblU
            // 
            this.lblU.AutoSize = true;
            this.lblU.Location = new System.Drawing.Point(12, 9);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(75, 20);
            this.lblU.TabIndex = 3;
            this.lblU.Text = "Username";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(12, 62);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(70, 20);
            this.lblP.TabIndex = 4;
            this.lblP.Text = "Password";
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(12, 115);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(127, 20);
            this.lblCP.TabIndex = 5;
            this.lblCP.Text = "Confirm Password";
            // 
            // chkbxCreate
            // 
            this.chkbxCreate.AutoSize = true;
            this.chkbxCreate.Location = new System.Drawing.Point(13, 224);
            this.chkbxCreate.Name = "chkbxCreate";
            this.chkbxCreate.Size = new System.Drawing.Size(429, 24);
            this.chkbxCreate.TabIndex = 6;
            this.chkbxCreate.Text = "Create Account? (check to create, leave unchecked to log in)";
            this.chkbxCreate.UseVisualStyleBackColor = true;
            this.chkbxCreate.CheckedChanged += new System.EventHandler(this.chkbxCreate_CheckedChanged);
            // 
            // btnLoginorCreate
            // 
            this.btnLoginorCreate.Location = new System.Drawing.Point(13, 254);
            this.btnLoginorCreate.Name = "btnLoginorCreate";
            this.btnLoginorCreate.Size = new System.Drawing.Size(429, 29);
            this.btnLoginorCreate.TabIndex = 7;
            this.btnLoginorCreate.Text = "Log In";
            this.btnLoginorCreate.UseVisualStyleBackColor = true;
            this.btnLoginorCreate.Click += new System.EventHandler(this.btnLoginorCreate_Click);
            // 
            // lblAC
            // 
            this.lblAC.AutoSize = true;
            this.lblAC.Location = new System.Drawing.Point(12, 168);
            this.lblAC.Name = "lblAC";
            this.lblAC.Size = new System.Drawing.Size(323, 20);
            this.lblAC.TabIndex = 8;
            this.lblAC.Text = "Account Code (Provided By Your Administrator)";
            // 
            // txtbxAC
            // 
            this.txtbxAC.Location = new System.Drawing.Point(12, 191);
            this.txtbxAC.Name = "txtbxAC";
            this.txtbxAC.Size = new System.Drawing.Size(430, 27);
            this.txtbxAC.TabIndex = 9;
            // 
            // Teacher_Login_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 292);
            this.Controls.Add(this.txtbxAC);
            this.Controls.Add(this.lblAC);
            this.Controls.Add(this.btnLoginorCreate);
            this.Controls.Add(this.chkbxCreate);
            this.Controls.Add(this.lblCP);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.lblU);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.txtbxPassword);
            this.Controls.Add(this.txtbxUsername);
            this.Name = "Teacher_Login_UI";
            this.Text = "Teacher Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtbxUsername;
        private TextBox txtbxPassword;
        private TextBox txtPasswordConfirm;
        private Label lblU;
        private Label lblP;
        private Label lblCP;
        private CheckBox chkbxCreate;
        private Button btnLoginorCreate;
        private Label lblAC;
        private TextBox txtbxAC;
    }
}