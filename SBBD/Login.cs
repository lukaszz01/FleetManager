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
        PrivateFontCollection pfc;

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

            pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"Resources\fontBold.ttf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], c.Font.Size, FontStyle.Regular);
            }

        }

        public static DialogResult ShowLogin()
        {
            login = new Login();
            login.ShowDialog();
            return dialogResult;
        }

        private void closeLogin_Click(object sender, EventArgs e)
        {
            switch(CustomMessageBox.CustomMsg("Czy na pewno chcesz \n zamknąć aplikację?", 1500, true))
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
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
                string pass = ComputeSha256Hash(passwordLogin.Text);
                var user = login_context.Users.Where(x => x.email == emailLogin.Text && x.password == pass).FirstOrDefault();
                if (user == null)
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

        private void showPassword_MouseDown(object sender, MouseEventArgs e)
        {
            passwordLogin.PasswordChar = '\0';
        }

        private void showPassword_MouseUp(object sender, MouseEventArgs e)
        {
            if(passwordLogin.Text == passwordLogin.PlaceHolder)
            {
                passwordLogin.PasswordChar = '\0';
            }
            else
            {
                passwordLogin.PasswordChar = '*';
            }
        }
    }
}
