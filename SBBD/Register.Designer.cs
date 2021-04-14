
namespace SBBD
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.closeRegister = new System.Windows.Forms.PictureBox();
            this.registerRegister = new System.Windows.Forms.PictureBox();
            this.loginRegister = new System.Windows.Forms.PictureBox();
            this.titleBarRegister = new System.Windows.Forms.PictureBox();
            this.emailRegister = new System.Windows.Forms.TextBox();
            this.firstNameRegister = new System.Windows.Forms.TextBox();
            this.lastNameRegister = new System.Windows.Forms.TextBox();
            this.passwordRegister = new System.Windows.Forms.TextBox();
            this.warnLabel1 = new System.Windows.Forms.Label();
            this.warningTimer = new System.Windows.Forms.Timer(this.components);
            this.warnLabel2 = new System.Windows.Forms.Label();
            this.warnLabel3 = new System.Windows.Forms.Label();
            this.warnLabel4 = new System.Windows.Forms.Label();
            this.passwordInfo = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.vehiclesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.closeRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // closeRegister
            // 
            this.closeRegister.BackColor = System.Drawing.Color.Transparent;
            this.closeRegister.BackgroundImage = global::SBBD.Properties.Resources.CloseBTN;
            this.closeRegister.Location = new System.Drawing.Point(394, 0);
            this.closeRegister.Name = "closeRegister";
            this.closeRegister.Size = new System.Drawing.Size(27, 16);
            this.closeRegister.TabIndex = 0;
            this.closeRegister.TabStop = false;
            this.closeRegister.Click += new System.EventHandler(this.closeRegister_Click);
            this.closeRegister.MouseEnter += new System.EventHandler(this.closeRegister_MouseEnter);
            this.closeRegister.MouseLeave += new System.EventHandler(this.closeRegister_MouseLeave);
            // 
            // registerRegister
            // 
            this.registerRegister.BackColor = System.Drawing.Color.Transparent;
            this.registerRegister.BackgroundImage = global::SBBD.Properties.Resources.BR1;
            this.registerRegister.Location = new System.Drawing.Point(120, 393);
            this.registerRegister.Name = "registerRegister";
            this.registerRegister.Size = new System.Drawing.Size(182, 39);
            this.registerRegister.TabIndex = 1;
            this.registerRegister.TabStop = false;
            this.registerRegister.Click += new System.EventHandler(this.registerRegister_Click);
            this.registerRegister.MouseEnter += new System.EventHandler(this.registerRegister_MouseEnter);
            this.registerRegister.MouseLeave += new System.EventHandler(this.registerRegister_MouseLeave);
            // 
            // loginRegister
            // 
            this.loginRegister.BackColor = System.Drawing.Color.Transparent;
            this.loginRegister.BackgroundImage = global::SBBD.Properties.Resources.BR2;
            this.loginRegister.Location = new System.Drawing.Point(150, 523);
            this.loginRegister.Name = "loginRegister";
            this.loginRegister.Size = new System.Drawing.Size(120, 26);
            this.loginRegister.TabIndex = 2;
            this.loginRegister.TabStop = false;
            this.loginRegister.Click += new System.EventHandler(this.loginRegister_Click);
            this.loginRegister.MouseEnter += new System.EventHandler(this.loginRegister_MouseEnter);
            this.loginRegister.MouseLeave += new System.EventHandler(this.loginRegister_MouseLeave);
            // 
            // titleBarRegister
            // 
            this.titleBarRegister.BackColor = System.Drawing.Color.Transparent;
            this.titleBarRegister.Location = new System.Drawing.Point(0, 0);
            this.titleBarRegister.Name = "titleBarRegister";
            this.titleBarRegister.Size = new System.Drawing.Size(393, 16);
            this.titleBarRegister.TabIndex = 3;
            this.titleBarRegister.TabStop = false;
            this.titleBarRegister.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBarRegister_MouseDown);
            this.titleBarRegister.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBarRegister_MouseMove);
            this.titleBarRegister.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBarRegister_MouseUp);
            // 
            // emailRegister
            // 
            this.emailRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.emailRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.emailRegister.Location = new System.Drawing.Point(60, 210);
            this.emailRegister.Name = "emailRegister";
            this.emailRegister.Size = new System.Drawing.Size(300, 13);
            this.emailRegister.TabIndex = 1;
            this.emailRegister.Text = "Login (adres e-mail)";
            this.emailRegister.Enter += new System.EventHandler(this.emailRegister_Enter);
            this.emailRegister.Leave += new System.EventHandler(this.emailRegister_Leave);
            // 
            // firstNameRegister
            // 
            this.firstNameRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.firstNameRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstNameRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.firstNameRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.firstNameRegister.Location = new System.Drawing.Point(60, 253);
            this.firstNameRegister.Name = "firstNameRegister";
            this.firstNameRegister.Size = new System.Drawing.Size(300, 13);
            this.firstNameRegister.TabIndex = 2;
            this.firstNameRegister.Text = "Imię";
            this.firstNameRegister.Enter += new System.EventHandler(this.firstNameRegister_Enter);
            this.firstNameRegister.Leave += new System.EventHandler(this.firstNameRegister_Leave);
            // 
            // lastNameRegister
            // 
            this.lastNameRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.lastNameRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastNameRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lastNameRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lastNameRegister.Location = new System.Drawing.Point(60, 292);
            this.lastNameRegister.Name = "lastNameRegister";
            this.lastNameRegister.Size = new System.Drawing.Size(300, 13);
            this.lastNameRegister.TabIndex = 3;
            this.lastNameRegister.Text = "Nazwisko";
            this.lastNameRegister.Enter += new System.EventHandler(this.lastNameRegister_Enter);
            this.lastNameRegister.Leave += new System.EventHandler(this.lastNameRegister_Leave);
            // 
            // passwordRegister
            // 
            this.passwordRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.passwordRegister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.passwordRegister.Location = new System.Drawing.Point(60, 333);
            this.passwordRegister.Name = "passwordRegister";
            this.passwordRegister.Size = new System.Drawing.Size(300, 13);
            this.passwordRegister.TabIndex = 4;
            this.passwordRegister.Text = "Hasło";
            this.passwordRegister.Enter += new System.EventHandler(this.passwordRegister_Enter);
            this.passwordRegister.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordRegister_KeyDown);
            this.passwordRegister.Leave += new System.EventHandler(this.passwordRegister_Leave);
            // 
            // warnLabel1
            // 
            this.warnLabel1.AutoSize = true;
            this.warnLabel1.BackColor = System.Drawing.Color.Transparent;
            this.warnLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warnLabel1.ForeColor = System.Drawing.Color.Red;
            this.warnLabel1.Location = new System.Drawing.Point(60, 232);
            this.warnLabel1.Name = "warnLabel1";
            this.warnLabel1.Size = new System.Drawing.Size(94, 9);
            this.warnLabel1.TabIndex = 32;
            this.warnLabel1.Text = "E-mail niepoprawny!";
            this.warnLabel1.Visible = false;
            // 
            // warningTimer
            // 
            this.warningTimer.Interval = 4000;
            this.warningTimer.Tick += new System.EventHandler(this.warningTimer_Tick);
            // 
            // warnLabel2
            // 
            this.warnLabel2.AutoSize = true;
            this.warnLabel2.BackColor = System.Drawing.Color.Transparent;
            this.warnLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warnLabel2.ForeColor = System.Drawing.Color.Red;
            this.warnLabel2.Location = new System.Drawing.Point(60, 357);
            this.warnLabel2.Name = "warnLabel2";
            this.warnLabel2.Size = new System.Drawing.Size(90, 9);
            this.warnLabel2.TabIndex = 33;
            this.warnLabel2.Text = "Hasło niepoprawne!";
            this.warnLabel2.Visible = false;
            // 
            // warnLabel3
            // 
            this.warnLabel3.AutoSize = true;
            this.warnLabel3.BackColor = System.Drawing.Color.Transparent;
            this.warnLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warnLabel3.ForeColor = System.Drawing.Color.Red;
            this.warnLabel3.Location = new System.Drawing.Point(152, 444);
            this.warnLabel3.Name = "warnLabel3";
            this.warnLabel3.Size = new System.Drawing.Size(116, 9);
            this.warnLabel3.TabIndex = 34;
            this.warnLabel3.Text = "Uzupelnij wszystkie pola!";
            this.warnLabel3.Visible = false;
            // 
            // warnLabel4
            // 
            this.warnLabel4.AutoSize = true;
            this.warnLabel4.BackColor = System.Drawing.Color.Transparent;
            this.warnLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warnLabel4.ForeColor = System.Drawing.Color.Red;
            this.warnLabel4.Location = new System.Drawing.Point(152, 156);
            this.warnLabel4.Name = "warnLabel4";
            this.warnLabel4.Size = new System.Drawing.Size(116, 9);
            this.warnLabel4.TabIndex = 35;
            this.warnLabel4.Text = "Podane konto już istnieje!";
            this.warnLabel4.Visible = false;
            // 
            // passwordInfo
            // 
            this.passwordInfo.BackColor = System.Drawing.Color.Transparent;
            this.passwordInfo.BackgroundImage = global::SBBD.Properties.Resources.question;
            this.passwordInfo.Location = new System.Drawing.Point(366, 336);
            this.passwordInfo.Name = "passwordInfo";
            this.passwordInfo.Size = new System.Drawing.Size(10, 10);
            this.passwordInfo.TabIndex = 42;
            this.passwordInfo.TabStop = false;
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.White;
            this.toolTip.ForeColor = System.Drawing.Color.Black;
            this.toolTip.IsBalloon = true;
            // 
            // vehiclesBindingSource
            // 
            this.vehiclesBindingSource.DataSource = typeof(SBBD.Vehicles);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SBBD.Properties.Resources.Reg;
            this.ClientSize = new System.Drawing.Size(420, 600);
            this.Controls.Add(this.passwordInfo);
            this.Controls.Add(this.warnLabel4);
            this.Controls.Add(this.warnLabel3);
            this.Controls.Add(this.warnLabel2);
            this.Controls.Add(this.warnLabel1);
            this.Controls.Add(this.passwordRegister);
            this.Controls.Add(this.lastNameRegister);
            this.Controls.Add(this.firstNameRegister);
            this.Controls.Add(this.emailRegister);
            this.Controls.Add(this.titleBarRegister);
            this.Controls.Add(this.loginRegister);
            this.Controls.Add(this.registerRegister);
            this.Controls.Add(this.closeRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.closeRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeRegister;
        private System.Windows.Forms.PictureBox registerRegister;
        private System.Windows.Forms.PictureBox loginRegister;
        private System.Windows.Forms.PictureBox titleBarRegister;
        private System.Windows.Forms.TextBox emailRegister;
        private System.Windows.Forms.TextBox firstNameRegister;
        private System.Windows.Forms.TextBox lastNameRegister;
        private System.Windows.Forms.TextBox passwordRegister;
        private System.Windows.Forms.BindingSource vehiclesBindingSource;
        private System.Windows.Forms.Label warnLabel1;
        private System.Windows.Forms.Timer warningTimer;
        private System.Windows.Forms.Label warnLabel2;
        private System.Windows.Forms.Label warnLabel3;
        private System.Windows.Forms.Label warnLabel4;
        private System.Windows.Forms.PictureBox passwordInfo;
        private System.Windows.Forms.ToolTip toolTip;
    }
}