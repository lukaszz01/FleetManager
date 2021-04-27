
namespace SBBD
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.closeLogin = new System.Windows.Forms.PictureBox();
            this.warningTimer = new System.Windows.Forms.Timer(this.components);
            this.warnLabel1 = new System.Windows.Forms.Label();
            this.warnLabel2 = new System.Windows.Forms.Label();
            this.showPassword = new System.Windows.Forms.Button();
            this.registerLogin = new SBBD.RoundedButton();
            this.loginLogin = new SBBD.RoundedButton();
            this.emailLogin = new SBBD.CustomTextBox();
            this.passwordLogin = new SBBD.CustomTextBox();
            this.titleBarLogin1 = new SBBD.MoveBar();
            ((System.ComponentModel.ISupportInitialize)(this.closeLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarLogin1)).BeginInit();
            this.SuspendLayout();
            // 
            // closeLogin
            // 
            this.closeLogin.BackColor = System.Drawing.Color.Transparent;
            this.closeLogin.BackgroundImage = global::SBBD.Properties.Resources.CloseBTN;
            this.closeLogin.Location = new System.Drawing.Point(394, 0);
            this.closeLogin.Name = "closeLogin";
            this.closeLogin.Size = new System.Drawing.Size(27, 16);
            this.closeLogin.TabIndex = 2;
            this.closeLogin.TabStop = false;
            this.closeLogin.Click += new System.EventHandler(this.closeLogin_Click);
            this.closeLogin.MouseEnter += new System.EventHandler(this.closeLogin_MouseEnter);
            this.closeLogin.MouseLeave += new System.EventHandler(this.closeLogin_MouseLeave);
            // 
            // warningTimer
            // 
            this.warningTimer.Interval = 4000;
            this.warningTimer.Tick += new System.EventHandler(this.warningTimer_Tick);
            // 
            // warnLabel1
            // 
            this.warnLabel1.AutoSize = true;
            this.warnLabel1.BackColor = System.Drawing.Color.Transparent;
            this.warnLabel1.Font = new System.Drawing.Font("Poppins SemiBold", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warnLabel1.ForeColor = System.Drawing.Color.Red;
            this.warnLabel1.Location = new System.Drawing.Point(157, 365);
            this.warnLabel1.Name = "warnLabel1";
            this.warnLabel1.Size = new System.Drawing.Size(106, 14);
            this.warnLabel1.TabIndex = 36;
            this.warnLabel1.Text = "Uzupełnij wszystkie pola!";
            this.warnLabel1.Visible = false;
            // 
            // warnLabel2
            // 
            this.warnLabel2.AutoSize = true;
            this.warnLabel2.BackColor = System.Drawing.Color.Transparent;
            this.warnLabel2.Font = new System.Drawing.Font("Poppins SemiBold", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warnLabel2.ForeColor = System.Drawing.Color.Red;
            this.warnLabel2.Location = new System.Drawing.Point(135, 155);
            this.warnLabel2.Name = "warnLabel2";
            this.warnLabel2.Size = new System.Drawing.Size(149, 14);
            this.warnLabel2.TabIndex = 38;
            this.warnLabel2.Text = "E-mail lub hasło jest nieprawidłowe!";
            this.warnLabel2.Visible = false;
            // 
            // showPassword
            // 
            this.showPassword.BackColor = System.Drawing.Color.Transparent;
            this.showPassword.BackgroundImage = global::SBBD.Properties.Resources.showPassword;
            this.showPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showPassword.FlatAppearance.BorderSize = 0;
            this.showPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.showPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.showPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassword.ForeColor = System.Drawing.Color.Transparent;
            this.showPassword.Location = new System.Drawing.Point(340, 280);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(18, 13);
            this.showPassword.TabIndex = 45;
            this.showPassword.UseVisualStyleBackColor = false;
            this.showPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPassword_MouseDown);
            this.showPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPassword_MouseUp);
            // 
            // registerLogin
            // 
            this.registerLogin.BackColor = System.Drawing.Color.Transparent;
            this.registerLogin.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.registerLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerLogin.FlatAppearance.BorderSize = 0;
            this.registerLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.registerLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.registerLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerLogin.ForeColor = System.Drawing.Color.White;
            this.registerLogin.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.registerLogin.Location = new System.Drawing.Point(150, 453);
            this.registerLogin.Name = "registerLogin";
            this.registerLogin.RoundRadius = 30;
            this.registerLogin.Size = new System.Drawing.Size(120, 26);
            this.registerLogin.TabIndex = 46;
            this.registerLogin.TabStop = false;
            this.registerLogin.Text = "Zarejestruj się!";
            this.registerLogin.UseVisualStyleBackColor = false;
            this.registerLogin.Click += new System.EventHandler(this.registerLogin_Click);
            // 
            // loginLogin
            // 
            this.loginLogin.BackColor = System.Drawing.Color.Transparent;
            this.loginLogin.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.loginLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLogin.FlatAppearance.BorderSize = 0;
            this.loginLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.loginLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loginLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginLogin.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loginLogin.ForeColor = System.Drawing.Color.White;
            this.loginLogin.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.loginLogin.Location = new System.Drawing.Point(120, 312);
            this.loginLogin.Name = "loginLogin";
            this.loginLogin.RoundRadius = 30;
            this.loginLogin.Size = new System.Drawing.Size(180, 38);
            this.loginLogin.TabIndex = 47;
            this.loginLogin.TabStop = false;
            this.loginLogin.Text = "Zaloguj";
            this.loginLogin.UseVisualStyleBackColor = false;
            this.loginLogin.Click += new System.EventHandler(this.loginLogin_Click);
            // 
            // emailLogin
            // 
            this.emailLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.emailLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.emailLogin.IsPassword = false;
            this.emailLogin.Location = new System.Drawing.Point(60, 209);
            this.emailLogin.Name = "emailLogin";
            this.emailLogin.PlaceHolder = "Login (adres e-mail)";
            this.emailLogin.Size = new System.Drawing.Size(300, 13);
            this.emailLogin.TabIndex = 1;
            this.emailLogin.Text = "Login (adres e-mail)";
            // 
            // passwordLogin
            // 
            this.passwordLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.passwordLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.passwordLogin.IsPassword = true;
            this.passwordLogin.Location = new System.Drawing.Point(60, 252);
            this.passwordLogin.Name = "passwordLogin";
            this.passwordLogin.PlaceHolder = "Hasło";
            this.passwordLogin.Size = new System.Drawing.Size(300, 13);
            this.passwordLogin.TabIndex = 2;
            this.passwordLogin.Text = "Hasło";
            this.passwordLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordLogin_KeyDown);
            // 
            // titleBarLogin1
            // 
            this.titleBarLogin1.BackColor = System.Drawing.Color.Transparent;
            this.titleBarLogin1.Location = new System.Drawing.Point(0, 0);
            this.titleBarLogin1.Name = "titleBarLogin1";
            this.titleBarLogin1.Size = new System.Drawing.Size(393, 16);
            this.titleBarLogin1.TabIndex = 56;
            this.titleBarLogin1.TabStop = false;
            this.titleBarLogin1.TargetForm = this;
            this.titleBarLogin1.XOffset = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SBBD.Properties.Resources.Log2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(420, 525);
            this.Controls.Add(this.titleBarLogin1);
            this.Controls.Add(this.passwordLogin);
            this.Controls.Add(this.emailLogin);
            this.Controls.Add(this.loginLogin);
            this.Controls.Add(this.registerLogin);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.warnLabel2);
            this.Controls.Add(this.warnLabel1);
            this.Controls.Add(this.closeLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.closeLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarLogin1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox closeLogin;
        private System.Windows.Forms.Timer warningTimer;
        private System.Windows.Forms.Label warnLabel1;
        private System.Windows.Forms.Label warnLabel2;
        private System.Windows.Forms.Button showPassword;
        private RoundedButton registerLogin;
        private RoundedButton loginLogin;
        private CustomTextBox emailLogin;
        private CustomTextBox passwordLogin;
        private MoveBar titleBarLogin1;
    }
}

