﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBBD
{
    public partial class Login : Form
    {

        bool moving;
        int moveX;
        int moveY;

        static Login login;
        static DialogResult dialogResult = DialogResult.No;
        public Login()
        {
            InitializeComponent();
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
            this.Close();
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
                emailLogin.ForeColor = Color.FromArgb(165, 166, 167);
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
                passwordLogin.ForeColor = Color.FromArgb(165, 166, 167);
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
    }
}
