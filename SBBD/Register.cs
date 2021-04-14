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

namespace SBBD
{
    public partial class Register : Form
    {
        VFEntities user_context;
        bool moving;
        int moveX;
        int moveY;

        static Register register;
        static DialogResult dialogResult = DialogResult.No;
        public Register()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            user_context = new VFEntities();
            user_context.Users.Load();

            toolTip.SetToolTip(passwordInfo, "Poprawny format min. 8 znaków, jedna mała litera, jedna duża litera,\njedna cyfra, jeden znak specjalny(@$!%*?&) ");

        }

        public static DialogResult ShowRegister()
        {
            register = new Register();
            register.ShowDialog();
            return dialogResult;
        }

        private void closeRegister_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerRegister_Click(object sender, EventArgs e)
        {
            if (
                IsEmpty(emailRegister, "Login (adres e-mail)") ||
                IsEmpty(firstNameRegister, "Imię") ||
                IsEmpty(lastNameRegister, "Nazwisko") ||
                IsEmpty(passwordRegister, "Hasło")
                )
            {
                warningTimer.Start();
                warnLabel3.Visible = true;
            }
            else if (
                !IsValid(emailRegister.Text) || 
                !RegexD(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", emailRegister) ||
                !RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister)
                )
            {
                if (!IsValid(emailRegister.Text)) ShowErrorMsg(warnLabel1);
                if (!RegexD(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", emailRegister)) ShowErrorMsg(warnLabel1);
                if (!RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister)) ShowErrorMsg(warnLabel2);
                //            ^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$
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

        private void loginRegister_MouseEnter(object sender, EventArgs e)
        {
            loginRegister.BackgroundImage = SBBD.Properties.Resources.BR1on;
        }

        private void loginRegister_MouseLeave(object sender, EventArgs e)
        {
            loginRegister.BackgroundImage = SBBD.Properties.Resources.BR2;
        }

        private void registerRegister_MouseEnter(object sender, EventArgs e)
        {
            registerRegister.BackgroundImage = SBBD.Properties.Resources.BR2on;
        }

        private void registerRegister_MouseLeave(object sender, EventArgs e)
        {
            registerRegister.BackgroundImage = SBBD.Properties.Resources.BR1;
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

        private void textBoxEnter(TextBox textBox, string placeholder, bool password)
        {
            if (textBox.Text == placeholder)
            {
                if(password)
                    textBox.PasswordChar = '*';
                textBox.Text = "";
                textBox.ForeColor = Color.FromArgb(165, 166, 167);
            }
        }

        private void textBoxLeave(TextBox textBox, string placeholder, bool password)
        {
            if (textBox.Text == "")
            {
                if(password)
                    textBox.PasswordChar = '\0';
                textBox.Text = placeholder;
                textBox.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void emailRegister_Enter(object sender, EventArgs e)
        {
            textBoxEnter((TextBox)sender, "Login (adres e-mail)", false);
        }

        private void emailRegister_Leave(object sender, EventArgs e)
        {
            textBoxLeave((TextBox)sender, "Login (adres e-mail)", false);
        }

        private void firstNameRegister_Enter(object sender, EventArgs e)
        {
            textBoxEnter((TextBox)sender, "Imię", false);
        }

        private void firstNameRegister_Leave(object sender, EventArgs e)
        {
            textBoxLeave((TextBox)sender, "Imię", false);
        }

        private void lastNameRegister_Enter(object sender, EventArgs e)
        {
            textBoxEnter((TextBox)sender, "Nazwisko", false);
        }

        private void lastNameRegister_Leave(object sender, EventArgs e)
        {
            textBoxLeave((TextBox)sender, "Nazwisko", false);
        }

        private void passwordRegister_Enter(object sender, EventArgs e)
        {
            textBoxEnter((TextBox)sender, "Hasło", true);
        }

        private void passwordRegister_Leave(object sender, EventArgs e)
        {
            textBoxLeave((TextBox)sender, "Hasło", true);
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
    }
}
