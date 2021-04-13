
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginLogin = new System.Windows.Forms.PictureBox();
            this.registerLogin = new System.Windows.Forms.PictureBox();
            this.closeLogin = new System.Windows.Forms.PictureBox();
            this.titleBarLogin = new System.Windows.Forms.PictureBox();
            this.emailLogin = new System.Windows.Forms.TextBox();
            this.passwordLogin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.loginLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLogin
            // 
            this.loginLogin.BackColor = System.Drawing.Color.Transparent;
            this.loginLogin.BackgroundImage = global::SBBD.Properties.Resources.B1;
            this.loginLogin.Location = new System.Drawing.Point(120, 312);
            this.loginLogin.Name = "loginLogin";
            this.loginLogin.Size = new System.Drawing.Size(181, 39);
            this.loginLogin.TabIndex = 0;
            this.loginLogin.TabStop = false;
            this.loginLogin.Click += new System.EventHandler(this.loginLogin_Click);
            this.loginLogin.MouseEnter += new System.EventHandler(this.loginLogin_MouseEnter);
            this.loginLogin.MouseLeave += new System.EventHandler(this.loginLogin_MouseLeave);
            // 
            // registerLogin
            // 
            this.registerLogin.BackColor = System.Drawing.Color.Transparent;
            this.registerLogin.BackgroundImage = global::SBBD.Properties.Resources.B2;
            this.registerLogin.Location = new System.Drawing.Point(150, 453);
            this.registerLogin.Name = "registerLogin";
            this.registerLogin.Size = new System.Drawing.Size(120, 26);
            this.registerLogin.TabIndex = 1;
            this.registerLogin.TabStop = false;
            this.registerLogin.Click += new System.EventHandler(this.registerLogin_Click);
            this.registerLogin.MouseEnter += new System.EventHandler(this.registerLogin_MouseEnter);
            this.registerLogin.MouseLeave += new System.EventHandler(this.registerLogin_MouseLeave);
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
            // titleBarLogin
            // 
            this.titleBarLogin.BackColor = System.Drawing.Color.Transparent;
            this.titleBarLogin.Location = new System.Drawing.Point(0, 0);
            this.titleBarLogin.Name = "titleBarLogin";
            this.titleBarLogin.Size = new System.Drawing.Size(393, 16);
            this.titleBarLogin.TabIndex = 3;
            this.titleBarLogin.TabStop = false;
            this.titleBarLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBarLogin_MouseDown);
            this.titleBarLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBarLogin_MouseMove);
            this.titleBarLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBarLogin_MouseUp);
            // 
            // emailLogin
            // 
            this.emailLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.emailLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailLogin.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.emailLogin.Location = new System.Drawing.Point(60, 210);
            this.emailLogin.Name = "emailLogin";
            this.emailLogin.Size = new System.Drawing.Size(300, 17);
            this.emailLogin.TabIndex = 1;
            this.emailLogin.Text = "Login (adres e-mail)";
            this.emailLogin.Enter += new System.EventHandler(this.emailLogin_Enter);
            this.emailLogin.Leave += new System.EventHandler(this.emailLogin_Leave);
            // 
            // passwordLogin
            // 
            this.passwordLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.passwordLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordLogin.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.passwordLogin.Location = new System.Drawing.Point(60, 253);
            this.passwordLogin.Name = "passwordLogin";
            this.passwordLogin.Size = new System.Drawing.Size(300, 17);
            this.passwordLogin.TabIndex = 2;
            this.passwordLogin.Text = "Hasło";
            this.passwordLogin.Enter += new System.EventHandler(this.passwordLogin_Enter);
            this.passwordLogin.Leave += new System.EventHandler(this.passwordLogin_Leave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SBBD.Properties.Resources.Log2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(420, 525);
            this.Controls.Add(this.passwordLogin);
            this.Controls.Add(this.emailLogin);
            this.Controls.Add(this.titleBarLogin);
            this.Controls.Add(this.closeLogin);
            this.Controls.Add(this.registerLogin);
            this.Controls.Add(this.loginLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.loginLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loginLogin;
        private System.Windows.Forms.PictureBox registerLogin;
        private System.Windows.Forms.PictureBox closeLogin;
        private System.Windows.Forms.PictureBox titleBarLogin;
        private System.Windows.Forms.TextBox emailLogin;
        private System.Windows.Forms.TextBox passwordLogin;
    }
}

