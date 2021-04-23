using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Drawing.Text;

namespace SBBD
{
    public partial class Register : Form
    {
        VFEntities user_context;
        bool moving;
        int moveX;
        int moveY;
        PrivateFontCollection pfc;

        static Register register;
        static DialogResult dialogResult = DialogResult.No;
        public Register()
        {
            InitializeComponent();

            showPassword.FlatAppearance.MouseOverBackColor = showPassword.BackColor;
            showPassword.BackColorChanged += (s, e) =>
            {
                showPassword.FlatAppearance.MouseOverBackColor = showPassword.BackColor;
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            user_context = new VFEntities();
            user_context.Users.Load();
            toolTip.SetToolTip(passwordInfo, "Musi zawierać min. 8 znaków, w tym (A-Z, a-z, 0-9) oraz znak specjalny (@$!%*?&)");

            pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"Resources\fontBold.ttf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], c.Font.Size, FontStyle.Regular);
            }
        }

        public static DialogResult ShowRegister()
        {
            register = new Register();
            register.ShowDialog();
            return dialogResult;
        }

        private void closeRegister_Click(object sender, EventArgs e)
        { 
            switch (CustomMessageBox.CustomMsg("Czy na pewno chcesz \n zakończyć rejestracje?", 1500, true))
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void registerRegister_Click(object sender, EventArgs e)
        {
            if (
                IsEmpty(emailRegister, "Login (adres e-mail)") ||
                IsEmpty(firstNameRegister, "Imię") ||
                IsEmpty(lastNameRegister, "Nazwisko") ||
                IsEmpty(passwordRegister, "Hasło") ||
                IsEmpty(passwordRegister1, "Hasło")
                )
            {
                warningTimer.Start();
                warnLabel3.Visible = true;
            }
            else if (
                !IsValid(emailRegister.Text) || 
                !RegexD(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", emailRegister) ||
                !RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister) ||
                !RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister1)
                )
            {
                if (!IsValid(emailRegister.Text)) ShowErrorMsg(warnLabel1);
                if (!RegexD(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", emailRegister)) ShowErrorMsg(warnLabel1);
                if (!RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister)) ShowErrorMsg(warnLabel2);
                if (!RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister1)) ShowErrorMsg(warnLabel2);
                if (passwordRegister.PasswordChar.Equals(passwordRegister1.PasswordChar)) ShowErrorMsg(warnLabel2);
            }
            else if (emailIsRepeat(emailRegister.Text))
            {
                warningTimer.Start();
                warnLabel4.Visible = true;
            }
            else
            {
                Users user = new Users()
                {
                    email = emailRegister.Text,
                    first_name = firstNameRegister.Text,
                    last_name = lastNameRegister.Text,
                    password = ComputeSha256Hash(passwordRegister.Text),
                    admin = false
                };
                user_context.Users.Add(user);
                user_context.SaveChanges();
                CustomMessageBox.CustomMsg("Rejestracja udana! Możesz \n teraz się zalogować", 2000, false);
                register.Close();
                this.Hide();
                Login.ShowLogin();
                this.Close();
            }
        }

        private void ShowErrorMsg(Label warnLabel)
        {
            warnLabel.Visible = true;
            warningTimer.Start();
        }

        private  string ComputeSha256Hash(string rawData)
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

        private bool RegexD(string reg, TextBox textbox)
        {
            Regex regex = new Regex(reg);
            if (!regex.IsMatch(textbox.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch
            {
                return false;
            }
        }  

        private bool emailIsRepeat(string email)
        {
            var allUsers = user_context.Users.Select(x => x).ToList();
            bool isTrue = false;
            foreach(Users user in allUsers)
            {
                if(email == user.email)
                {
                    isTrue = true;
                    break;
                }
            }
            return isTrue;
        }

        private bool IsEmpty(TextBox textBox, string placeholder)
        {
            return textBox.Text == "" || textBox.Text == placeholder;
        } 

        private void loginRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.ShowLogin();
            this.Close();
        }

        private void titleBarRegister_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            moveX = e.X;
            moveY = e.Y;
        }

        private void titleBarRegister_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void titleBarRegister_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }
        private void closeRegister_MouseEnter(object sender, EventArgs e)
        {
            closeRegister.BackgroundImage = Properties.Resources.B3;
        }

        private void closeRegister_MouseLeave(object sender, EventArgs e)
        {
            closeRegister.BackgroundImage = Properties.Resources.CloseBTN;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.user_context.Dispose();
        }

        private void warningTimer_Tick(object sender, EventArgs e)
        {
            warningTimer.Stop();
            warnLabel1.Visible = false;
            warnLabel2.Visible = false;
            warnLabel3.Visible = false;
        }

        private void passwordRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                registerRegister_Click(null, null);
            }
        }

        private void showPassword_MouseDown(object sender, MouseEventArgs e)
        {
            passwordRegister.PasswordChar = '\0';
            passwordRegister1.PasswordChar = '\0';
        }

        private void showPassword_MouseUp(object sender, MouseEventArgs e)
        {
            if(passwordRegister.Text == passwordRegister.PlaceHolder && passwordRegister1.Text == passwordRegister1.PlaceHolder)
            {
                passwordRegister.PasswordChar = '\0';
                passwordRegister1.PasswordChar = '\0';
            }
            else
            {
                passwordRegister.PasswordChar = '*';
                passwordRegister1.PasswordChar = '*';
            }
        }
    }
}

