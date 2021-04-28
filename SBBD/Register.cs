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
using System.Text.RegularExpressions;
using System.Drawing.Text;
using static SBBD.ExtendedClass;

namespace SBBD
{
    public partial class Register : Form
    {
        VFEntities context;
        PrivateFontCollection pfc;
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

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
            context = new VFEntities();
            context.Users.Load();
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
            AppExit("Czy na pewno chcesz \n zakończyć rejestracje?");
        }
       
        private void registerRegister_Click(object sender, EventArgs e)
        {
            if (
                IsEmpty(emailRegister, "Login (adres e-mail)") ||
                IsEmpty(firstNameRegister, "Imię") ||
                IsEmpty(lastNameRegister, "Nazwisko") ||
                IsEmpty(passwordRegister, "Hasło") ||
                IsEmpty(passwordRegister1, "Powtórz hasło")
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
                if (!IsValid(emailRegister.Text)) ShowErrorMsg(warnLabel1, warningTimer);
                if (!RegexD(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", emailRegister)) ShowErrorMsg(warnLabel1, warningTimer);
                if (!RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister)) ShowMsg(0, warnLabel2, warningTimer);
                if (!RegexD(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", passwordRegister1)) ShowMsg(0, warnLabel2, warningTimer);
                if (!(passwordRegister.Text.Equals(passwordRegister1.Text))) ShowMsg(1, warnLabel2, warningTimer);
                if (passwordRegister.TextLength < 8 && passwordRegister1.TextLength < 8) ShowMsg(2, warnLabel2, warningTimer);
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
                context.Users.Add(user);
                context.SaveChanges();
                CustomMessageBox.CustomMsg("Rejestracja udana! Możesz \n teraz się zalogować", 2000, false);
                register.Close();
                this.Hide();
                Login.ShowLogin();
                this.Close();
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
            var userName = context.Users.Where(x => x.email == email).FirstOrDefault();
            return userName != null;
        }

        private void loginRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.ShowLogin();
            this.Close();
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
            this.context.Dispose();
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
            ShowPassword(passwordRegister, showPassword);
            ShowPassword(passwordRegister1, showPassword);
        }

        private void showPassword_MouseUp(object sender, MouseEventArgs e)
        {
            HidePassword(passwordRegister, showPassword);
            HidePassword(passwordRegister1, showPassword);
        }
    }
}

