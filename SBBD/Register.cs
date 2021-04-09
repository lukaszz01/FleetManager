﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace SBBD
{
    public partial class Register : Form
    {
        VFEntities context;
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
            context.Users.Load();
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
            //register.Close();
            this.Hide();
            Login.ShowLogin();
            this.Close();
        }

        private bool emailIsRepeat(string email)
        {
            var allUsers = context.Users.Select(x => x).ToList();
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
    }
}
