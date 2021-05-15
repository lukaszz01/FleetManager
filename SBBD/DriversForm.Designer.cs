
namespace SBBD
{
    partial class DriversForm
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
            this.warningTimer = new System.Windows.Forms.Timer(this.components);
            this.addEditDriversPanel = new System.Windows.Forms.Panel();
            this.driverAvailable = new System.Windows.Forms.ComboBox();
            this.driverWarnLabel6 = new System.Windows.Forms.Label();
            this.driverWarnLabel5 = new System.Windows.Forms.Label();
            this.driverWarnLabel4 = new System.Windows.Forms.Label();
            this.driverWarnLabel3 = new System.Windows.Forms.Label();
            this.driverWarnLabel2 = new System.Windows.Forms.Label();
            this.driverWarnLabel1 = new System.Windows.Forms.Label();
            this.medicalExaminationDate = new SBBD.CustomDTPicker();
            this.driversLicenceDate = new SBBD.CustomDTPicker();
            this.driverCancel = new SBBD.RoundedButton();
            this.driverOK = new SBBD.RoundedButton();
            this.licenceNum = new SBBD.CustomTextBox();
            this.lastNameDriver = new SBBD.CustomTextBox();
            this.firstNameDriver = new SBBD.CustomTextBox();
            this.addEditDriversPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // warningTimer
            // 
            this.warningTimer.Interval = 4000;
            // 
            // addEditDriversPanel
            // 
            this.addEditDriversPanel.BackColor = System.Drawing.Color.Transparent;
            this.addEditDriversPanel.BackgroundImage = global::SBBD.Resources.addDriverBG1;
            this.addEditDriversPanel.Controls.Add(this.driverAvailable);
            this.addEditDriversPanel.Controls.Add(this.medicalExaminationDate);
            this.addEditDriversPanel.Controls.Add(this.driversLicenceDate);
            this.addEditDriversPanel.Controls.Add(this.driverCancel);
            this.addEditDriversPanel.Controls.Add(this.driverWarnLabel6);
            this.addEditDriversPanel.Controls.Add(this.driverWarnLabel5);
            this.addEditDriversPanel.Controls.Add(this.driverWarnLabel4);
            this.addEditDriversPanel.Controls.Add(this.driverWarnLabel3);
            this.addEditDriversPanel.Controls.Add(this.driverWarnLabel2);
            this.addEditDriversPanel.Controls.Add(this.driverOK);
            this.addEditDriversPanel.Controls.Add(this.driverWarnLabel1);
            this.addEditDriversPanel.Controls.Add(this.licenceNum);
            this.addEditDriversPanel.Controls.Add(this.lastNameDriver);
            this.addEditDriversPanel.Controls.Add(this.firstNameDriver);
            this.addEditDriversPanel.Location = new System.Drawing.Point(0, 0);
            this.addEditDriversPanel.Name = "addEditDriversPanel";
            this.addEditDriversPanel.Size = new System.Drawing.Size(400, 450);
            this.addEditDriversPanel.TabIndex = 20;
            // 
            // driverAvailable
            // 
            this.driverAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.driverAvailable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.driverAvailable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driverAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.driverAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverAvailable.ForeColor = System.Drawing.Color.White;
            this.driverAvailable.FormattingEnabled = true;
            this.driverAvailable.Items.AddRange(new object[] {
            "Tak",
            "Nie"});
            this.driverAvailable.Location = new System.Drawing.Point(192, 332);
            this.driverAvailable.Name = "driverAvailable";
            this.driverAvailable.Size = new System.Drawing.Size(158, 21);
            this.driverAvailable.TabIndex = 46;
            this.driverAvailable.Visible = false;
            // 
            // driverWarnLabel6
            // 
            this.driverWarnLabel6.AutoSize = true;
            this.driverWarnLabel6.BackColor = System.Drawing.Color.Transparent;
            this.driverWarnLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverWarnLabel6.ForeColor = System.Drawing.Color.Red;
            this.driverWarnLabel6.Location = new System.Drawing.Point(215, 310);
            this.driverWarnLabel6.Name = "driverWarnLabel6";
            this.driverWarnLabel6.Size = new System.Drawing.Size(113, 9);
            this.driverWarnLabel6.TabIndex = 41;
            this.driverWarnLabel6.Text = "Uzupełnij wszystkie pola";
            this.driverWarnLabel6.Visible = false;
            // 
            // driverWarnLabel5
            // 
            this.driverWarnLabel5.AutoSize = true;
            this.driverWarnLabel5.BackColor = System.Drawing.Color.Transparent;
            this.driverWarnLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverWarnLabel5.ForeColor = System.Drawing.Color.Red;
            this.driverWarnLabel5.Location = new System.Drawing.Point(215, 260);
            this.driverWarnLabel5.Name = "driverWarnLabel5";
            this.driverWarnLabel5.Size = new System.Drawing.Size(113, 9);
            this.driverWarnLabel5.TabIndex = 40;
            this.driverWarnLabel5.Text = "Uzupełnij wszystkie pola";
            this.driverWarnLabel5.Visible = false;
            // 
            // driverWarnLabel4
            // 
            this.driverWarnLabel4.AutoSize = true;
            this.driverWarnLabel4.BackColor = System.Drawing.Color.Transparent;
            this.driverWarnLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverWarnLabel4.ForeColor = System.Drawing.Color.Red;
            this.driverWarnLabel4.Location = new System.Drawing.Point(215, 210);
            this.driverWarnLabel4.Name = "driverWarnLabel4";
            this.driverWarnLabel4.Size = new System.Drawing.Size(113, 9);
            this.driverWarnLabel4.TabIndex = 39;
            this.driverWarnLabel4.Text = "Uzupełnij wszystkie pola";
            this.driverWarnLabel4.Visible = false;
            // 
            // driverWarnLabel3
            // 
            this.driverWarnLabel3.AutoSize = true;
            this.driverWarnLabel3.BackColor = System.Drawing.Color.Transparent;
            this.driverWarnLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverWarnLabel3.ForeColor = System.Drawing.Color.Red;
            this.driverWarnLabel3.Location = new System.Drawing.Point(215, 160);
            this.driverWarnLabel3.Name = "driverWarnLabel3";
            this.driverWarnLabel3.Size = new System.Drawing.Size(113, 9);
            this.driverWarnLabel3.TabIndex = 38;
            this.driverWarnLabel3.Text = "Uzupełnij wszystkie pola";
            this.driverWarnLabel3.Visible = false;
            // 
            // driverWarnLabel2
            // 
            this.driverWarnLabel2.AutoSize = true;
            this.driverWarnLabel2.BackColor = System.Drawing.Color.Transparent;
            this.driverWarnLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverWarnLabel2.ForeColor = System.Drawing.Color.Red;
            this.driverWarnLabel2.Location = new System.Drawing.Point(215, 110);
            this.driverWarnLabel2.Name = "driverWarnLabel2";
            this.driverWarnLabel2.Size = new System.Drawing.Size(113, 9);
            this.driverWarnLabel2.TabIndex = 37;
            this.driverWarnLabel2.Text = "Uzupełnij wszystkie pola";
            this.driverWarnLabel2.Visible = false;
            // 
            // driverWarnLabel1
            // 
            this.driverWarnLabel1.AutoSize = true;
            this.driverWarnLabel1.BackColor = System.Drawing.Color.Transparent;
            this.driverWarnLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverWarnLabel1.ForeColor = System.Drawing.Color.Red;
            this.driverWarnLabel1.Location = new System.Drawing.Point(144, 57);
            this.driverWarnLabel1.Name = "driverWarnLabel1";
            this.driverWarnLabel1.Size = new System.Drawing.Size(113, 9);
            this.driverWarnLabel1.TabIndex = 36;
            this.driverWarnLabel1.Text = "Uzupełnij wszystkie pola";
            this.driverWarnLabel1.Visible = false;
            // 
            // medicalExaminationDate
            // 
            this.medicalExaminationDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.medicalExaminationDate.BackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.medicalExaminationDate.CalendarForeColor = System.Drawing.Color.White;
            this.medicalExaminationDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.medicalExaminationDate.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.medicalExaminationDate.CustomFormat = "dd MMMM yyyy";
            this.medicalExaminationDate.ForeColor = System.Drawing.Color.White;
            this.medicalExaminationDate.Location = new System.Drawing.Point(192, 232);
            this.medicalExaminationDate.Name = "medicalExaminationDate";
            this.medicalExaminationDate.Size = new System.Drawing.Size(158, 20);
            this.medicalExaminationDate.TabIndex = 45;
            // 
            // driversLicenceDate
            // 
            this.driversLicenceDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.driversLicenceDate.BackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.driversLicenceDate.CalendarForeColor = System.Drawing.Color.White;
            this.driversLicenceDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.driversLicenceDate.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.driversLicenceDate.CustomFormat = "dd MMMM yyyy";
            this.driversLicenceDate.ForeColor = System.Drawing.Color.White;
            this.driversLicenceDate.Location = new System.Drawing.Point(192, 282);
            this.driversLicenceDate.Name = "driversLicenceDate";
            this.driversLicenceDate.Size = new System.Drawing.Size(160, 20);
            this.driversLicenceDate.TabIndex = 44;
            // 
            // driverCancel
            // 
            this.driverCancel.BackColor = System.Drawing.Color.Transparent;
            this.driverCancel.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.driverCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.driverCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.driverCancel.FlatAppearance.BorderSize = 0;
            this.driverCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.driverCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.driverCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.driverCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.driverCancel.ForeColor = System.Drawing.Color.White;
            this.driverCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.driverCancel.Location = new System.Drawing.Point(51, 390);
            this.driverCancel.Name = "driverCancel";
            this.driverCancel.RoundRadius = 30;
            this.driverCancel.Size = new System.Drawing.Size(140, 30);
            this.driverCancel.TabIndex = 43;
            this.driverCancel.Text = "Anuluj";
            this.driverCancel.UseVisualStyleBackColor = false;
            // 
            // driverOK
            // 
            this.driverOK.BackColor = System.Drawing.Color.Transparent;
            this.driverOK.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.driverOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.driverOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.driverOK.Enabled = false;
            this.driverOK.FlatAppearance.BorderSize = 0;
            this.driverOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.driverOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.driverOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.driverOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.driverOK.ForeColor = System.Drawing.Color.White;
            this.driverOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.driverOK.Location = new System.Drawing.Point(205, 390);
            this.driverOK.Name = "driverOK";
            this.driverOK.RoundRadius = 30;
            this.driverOK.Size = new System.Drawing.Size(140, 30);
            this.driverOK.TabIndex = 14;
            this.driverOK.Text = "Zatwierdź";
            this.driverOK.UseVisualStyleBackColor = false;
            // 
            // licenceNum
            // 
            this.licenceNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.licenceNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.licenceNum.Enabled = false;
            this.licenceNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.licenceNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.licenceNum.IsPassword = false;
            this.licenceNum.Location = new System.Drawing.Point(192, 182);
            this.licenceNum.Name = "licenceNum";
            this.licenceNum.PlaceHolder = "Numer PJ";
            this.licenceNum.Size = new System.Drawing.Size(160, 15);
            this.licenceNum.TabIndex = 11;
            this.licenceNum.Text = "Numer PJ";
            this.licenceNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.licenceNum.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // lastNameDriver
            // 
            this.lastNameDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lastNameDriver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastNameDriver.Enabled = false;
            this.lastNameDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lastNameDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lastNameDriver.IsPassword = false;
            this.lastNameDriver.Location = new System.Drawing.Point(192, 132);
            this.lastNameDriver.Name = "lastNameDriver";
            this.lastNameDriver.PlaceHolder = "Nazwisko";
            this.lastNameDriver.Size = new System.Drawing.Size(160, 15);
            this.lastNameDriver.TabIndex = 10;
            this.lastNameDriver.Text = "Nazwisko";
            this.lastNameDriver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lastNameDriver.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // firstNameDriver
            // 
            this.firstNameDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.firstNameDriver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstNameDriver.Enabled = false;
            this.firstNameDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.firstNameDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.firstNameDriver.IsPassword = false;
            this.firstNameDriver.Location = new System.Drawing.Point(192, 82);
            this.firstNameDriver.Name = "firstNameDriver";
            this.firstNameDriver.PlaceHolder = "Imie";
            this.firstNameDriver.Size = new System.Drawing.Size(160, 15);
            this.firstNameDriver.TabIndex = 9;
            this.firstNameDriver.Text = "Imie";
            this.firstNameDriver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.firstNameDriver.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // DriversForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.addEditDriversPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DriversForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditDriver";
            this.addEditDriversPanel.ResumeLayout(false);
            this.addEditDriversPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel addEditDriversPanel;
        private System.Windows.Forms.Label driverWarnLabel6;
        private System.Windows.Forms.Label driverWarnLabel5;
        private System.Windows.Forms.Label driverWarnLabel4;
        private System.Windows.Forms.Label driverWarnLabel3;
        private System.Windows.Forms.Label driverWarnLabel2;
        private RoundedButton driverOK;
        private System.Windows.Forms.Label driverWarnLabel1;
        private CustomTextBox licenceNum;
        private CustomTextBox lastNameDriver;
        private CustomTextBox firstNameDriver;
        private RoundedButton driverCancel;
        private CustomDTPicker driversLicenceDate;
        private CustomDTPicker medicalExaminationDate;
        private System.Windows.Forms.ComboBox driverAvailable;
        private System.Windows.Forms.Timer warningTimer;
    }
}