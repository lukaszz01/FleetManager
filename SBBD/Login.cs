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
            switch(MessageBox.Show("Czy na pewno chcesz zamknąć aplikację?", 
                        "Informacja", 
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question))
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

        //public class AutoClosingMessageBox
        //{
        //    System.Threading.Timer _timeoutTimer;
        //    string _caption;
        //    DialogResult _result;
        //    DialogResult _timerResult;
        //    AutoClosingMessageBox(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
        //    {
        //        _caption = caption;
        //        _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
        //            null, timeout, System.Threading.Timeout.Infinite);
        //        _timerResult = timerResult;
        //        using (_timeoutTimer)
        //            _result = MessageBox.Show(text, caption/*, buttons*/);
        //    }
        //    public static DialogResult Show(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
        //    {
        //        return new AutoClosingMessageBox(text, caption, timeout, buttons, timerResult)._result;
        //    }
        //    void OnTimerElapsed(object state)
        //    {
        //        IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
        //        if (mbWnd != IntPtr.Zero)
        //            SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        //        _timeoutTimer.Dispose();
        //        _result = _timerResult;
        //    }
        //    const int WM_CLOSE = 0x0010;
        //    [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        //    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        //    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        //}

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
                if (user == null)
                {
                    warningTimer.Start();
                    ShowErrorMsg(warnLabel2);
                }
                else
                {
                    logged_user_value = user;
                    AutoClosingMessageBox.Show(text: "Pomyślnie zalogowano. Witamy!", caption: "Informacja", timeout: 1500);
                    this.Close();
                }


                //switch (MessageBox.Show("Pomyślnie zalogowano. Witamy!",
                //        "Informacja",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information))
                //{
                //    case DialogResult.OK:
                //        break;
                //}
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
            if (passwordLogin.Text == "Hasło" && passwordLogin.PlaceHolder == "Hasło")
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
