using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.Entity;
using System.Drawing.Text;

namespace SBBD
{
    public partial class Login : Form
    {
        VFEntities login_context;
        bool moving;
        int moveX;
        int moveY;
        Users logged_user;
        public static Users logged_user_value
        {
            get;set;
        }

        static Login login;
        static DialogResult dialogResult = DialogResult.No;
        public Login()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            login_context = new VFEntities();
            login_context.Users.Load();
            
        }

        public static DialogResult ShowLogin()
        {
            login = new Login();
            login.ShowDialog();
            return dialogResult;
        }

        private void closeLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerLogin_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Register.ShowRegister();
            this.Close();
        }

        private void loginLogin_Click(object sender, EventArgs e)
        {
            if (
                IsEmpty(emailLogin, "Login (adres e-mail)") ||
                IsEmpty(passwordLogin, "Hasło")
                )
            {
                warningTimer.Start();
                ShowErrorMsg(warnLabel1);
            }
            else
            {
                /*var allUsers = login_context.Users.Select(x => x).ToList();
                //var User = login_context.Users.Where(x => x.email == emailLogin.Text).FirstOrDefault();
                Users user1=new Users();
                foreach (Users user in allUsers)
                {
                    if (emailLogin.Text == user.email)
                    {
                        user1 = user;
                        break;
                    }
                }
                if (user1.email == null)
                {
                    warningTimer.Start();
                    ShowErrorMsg(warnLabel2);
                }
                else
                {
                    if (ComputeSha256Hash(passwordLogin.Text) == user1.password)
                    {
                        logged_user_value = user1;
                        this.Close();
                    }
                    else
                    {
                        warningTimer.Start();
                        ShowErrorMsg(warnLabel3);
                    }
                }*/
                string pass = ComputeSha256Hash(passwordLogin.Text);
                var user = login_context.Users.Where(x => x.email == emailLogin.Text && x.password == pass).FirstOrDefault();
                if(user == null)
                {
                    warningTimer.Start();
                    ShowErrorMsg(warnLabel2);
                }
                else
                {
                    logged_user_value = user;
                    this.Close();
                }
            }
        }

        private void ShowErrorMsg(Label warnLabel)
        {
            warnLabel.Visible = true;
            warningTimer.Start();
        }

        private bool IsEmpty(TextBox textBox, string placeholder)
        {
            return textBox.Text == "" || textBox.Text == placeholder;
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void titleBarLogin_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            moveX = e.X;
            moveY = e.Y;
        }

        private void titleBarLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }

        private void titleBarLogin_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void loginLogin_MouseLeave(object sender, EventArgs e)
        {
            loginLogin.BackgroundImage = SBBD.Properties.Resources.B1;
        }

        private void loginLogin_MouseEnter(object sender, EventArgs e)
        {
            loginLogin.BackgroundImage = SBBD.Properties.Resources.BL2on;
        }

        private void registerLogin_MouseEnter(object sender, EventArgs e)
        {
            registerLogin.BackgroundImage = SBBD.Properties.Resources.BL1on;
        }

        private void registerLogin_MouseLeave(object sender, EventArgs e)
        {
            registerLogin.BackgroundImage = SBBD.Properties.Resources.B2;
        }

        private void emailLogin_Enter(object sender, EventArgs e)
        {
            if (emailLogin.Text == "Login (adres e-mail)")
            {
                emailLogin.Text = "";
                emailLogin.ForeColor = Color.White;
            }
        }

        private void emailLogin_Leave(object sender, EventArgs e)
        {
            if(emailLogin.Text == "")
            {
                emailLogin.Text = "Login (adres e-mail)";
                emailLogin.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void passwordLogin_Enter(object sender, EventArgs e)
        {
            if(passwordLogin.Text == "Hasło")
            {
                passwordLogin.Text = "";
                passwordLogin.PasswordChar = '*';
                passwordLogin.ForeColor = Color.White;
            }
        }

        private void passwordLogin_Leave(object sender, EventArgs e)
        {
            {
                if (passwordLogin.Text == "")
                {
                    passwordLogin.PasswordChar = '\0';
                    passwordLogin.Text = "Hasło";
                    passwordLogin.ForeColor = Color.FromArgb(77, 77, 77);
                }

            }
        }

        private void closeLogin_MouseEnter(object sender, EventArgs e)
        {
            closeLogin.BackgroundImage = Properties.Resources.B3;
        }

        private void closeLogin_MouseLeave(object sender, EventArgs e)
        {
            closeLogin.BackgroundImage = Properties.Resources.CloseBTN;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.login_context.Dispose();
        }

        private void warningTimer_Tick(object sender, EventArgs e)
        {
            warningTimer.Stop();
            warnLabel1.Visible = false;
            warnLabel2.Visible = false;
            warnLabel2.Visible = false;
        }

        private void passwordLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginLogin_Click(null, null);
            }
        }
    }
}
