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
    public partial class Teacher_Login_UI : Form
    {
        //the dictionary of logins
        Dictionary<string, string> logins = new();
        int newLoginID = 0;

        public Teacher_Login_UI()
        {
            InitializeComponent();
            readLoginsToArray();
            //defaults assume a login not a check
            loginSizing();
        }

        public void readLoginsToArray()
        {
            //read the logins to the array
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Usernames.txt";
            string[] usernames = System.IO.File.ReadAllLines(fileAddress);
            fileAddress = @"C:\Users\Public\FlashcardAppData\Passwords.txt";
            string[] passwords = System.IO.File.ReadAllLines(fileAddress);
            //each string username will have a corresponding password
            //if it doesn't the user has touched files
            //user should not touch files, stop it
            int totalLogins = usernames.Length;
            for (int i = 0; i < totalLogins; i++)
            {
                //add to the dictionary
                logins.Add(usernames[i], passwords[i]);
                //increment newLogin for later use
                newLoginID++;
            }
        }
        //set UI for login
        public void loginSizing()
        {
            //changes height to match UI
            this.Height = 233;
            //hides UI elements that the user won't need for login
            lblCP.Hide();
            txtPasswordConfirm.Hide();
            lblAC.Hide();
            txtbxAC.Hide();
            //renames / moves some UI elements
            btnLoginorCreate.Text = "Log In";
            btnLoginorCreate.Location = new System.Drawing.Point(12, 148);
            chkbxCreate.Location = new System.Drawing.Point(12, 118);
        }
        //set UI for creation
        public void createSizing()
        {
            //changes height to match UI
            this.Height = 339;
            //shows UI elements for creation
            lblCP.Show();
            txtPasswordConfirm.Show();
            lblAC.Show();
            txtbxAC.Show();
            //renames / moves some UI elements
            btnLoginorCreate.Text = "Create Account";
            btnLoginorCreate.Location = new System.Drawing.Point(13, 254);
            chkbxCreate.Location = new System.Drawing.Point(13, 224);
        }

        private void chkbxCreate_CheckedChanged(object sender, EventArgs e)
        {
            //checks what to do based on if it's checked
            if (chkbxCreate.Checked == true)
            {
                //resize for create
                createSizing();
            } else
            {
                //resize for login
                loginSizing();
            }
        }

        private void btnLoginorCreate_Click(object sender, EventArgs e)
        {
            if (chkbxCreate.Checked == true)
            {
                //do passwords match and is the creation valid?
                if (txtbxAC.Text == "OV1")
                {
                    if ((txtbxPassword.Text == txtPasswordConfirm.Text) && (txtbxPassword.Text != ""))
                    {
                        if (logins.ContainsKey(txtbxUsername.Text))
                        {
                            MessageBox.Show("Account username already exists");
                        }
                        else
                        {
                            //add to dictionary
                            logins.Add(txtbxUsername.Text, txtbxPassword.Text);
                            //add to file
                            appendLogin(txtbxUsername.Text, txtbxPassword.Text);
                            MessageBox.Show("Account created, please log in");
                            loginSizing();
                        }
                    } else
                    {
                        MessageBox.Show("Passwords do not match or are empty");
                    }
                } else
                {
                    MessageBox.Show("Please enter the correct Account Code");
                }
            } else
            {
                //check the logins / login
                if (logins.ContainsKey(txtbxUsername.Text) && logins[txtbxUsername.Text]==txtbxPassword.Text)
                {
                    MessageBox.Show("You are now logged in");
                    //sets the global var to true to signify the user is logged in as a teacher
                    Global.teacherLoggedIn = true;
                    this.Close();
                } else
                {
                    MessageBox.Show("Invalid Login");
                }
            }
        }

        //fully functional
        public async Task appendLogin(string username, string password)
        {
            //set the address to a constant to make it a bit easier to edit :)
            string fileAddress = @"C:\Users\Public\FlashcardAppData\Usernames.txt";

            //sets the file to append and states the file to append to
            using StreamWriter Usernamefile = new(fileAddress, append: true);
            //appends the username to the file
            await Usernamefile.WriteLineAsync(username);
            Usernamefile.Close();

            fileAddress = @"C:\Users\Public\FlashcardAppData\Passwords.txt";
            //sets the file to append and states the file to append to
            using StreamWriter Passwordfile = new(fileAddress, append: true);
            //appends the username to the file
            await Passwordfile.WriteLineAsync(username);
            Passwordfile.Close();
        }
    }
}
