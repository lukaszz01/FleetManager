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
using System.Drawing.Text;
using static SBBD.ExtendedClass;

namespace SBBD
{
    public partial class Login : Form
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
            context = new VFEntities();
            context.Users.Load();
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
            AppExit("Czy na pewno chcesz \n zamknąć aplikację?");
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
                ShowErrorMsg(warnLabel1, warningTimer);
            }
            else
            {
                string pass = ComputeSha256Hash(passwordLogin.Text);
                var user = context.Users.Where(x => x.email == emailLogin.Text && x.password == pass).FirstOrDefault();
                if (user == null)
                {
                    warningTimer.Start();
                    ShowErrorMsg(warnLabel2, warningTimer);
                }
                else
                {
                    logged_user_value = user;
                    this.Close();
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
            this.context.Dispose();
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
            ShowPassword(passwordLogin, showPassword);
        }

        private void showPassword_MouseUp(object sender, MouseEventArgs e)
        {
            HidePassword(passwordLogin, showPassword);
        }
    }
}
