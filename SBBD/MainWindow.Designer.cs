
namespace SBBD
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.addVehicle = new System.Windows.Forms.PictureBox();
            this.allVehicles = new System.Windows.Forms.PictureBox();
            this.userInfo = new System.Windows.Forms.PictureBox();
            this.settings = new System.Windows.Forms.PictureBox();
            this.appInfo = new System.Windows.Forms.PictureBox();
            this.mainExit = new System.Windows.Forms.PictureBox();
            this.mainMinimize = new System.Windows.Forms.PictureBox();
            this.mainTitleBar = new System.Windows.Forms.PictureBox();
            this.vehiclesPanel = new System.Windows.Forms.Panel();
            this.addVehiclePanel = new System.Windows.Forms.Panel();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.prodYear = new System.Windows.Forms.TextBox();
            this.vehicleColor = new System.Windows.Forms.TextBox();
            this.vinNumber = new System.Windows.Forms.TextBox();
            this.regNumber = new System.Windows.Forms.TextBox();
            this.engineCapacity = new System.Windows.Forms.TextBox();
            this.enginePower = new System.Windows.Forms.TextBox();
            this.fuelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.bodyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.vehiclesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addVehicleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.addVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTitleBar)).BeginInit();
            this.addVehiclePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addVehicle
            // 
            this.addVehicle.BackColor = System.Drawing.Color.Transparent;
            this.addVehicle.BackgroundImage = global::SBBD.Properties.Resources.MWB1off;
            this.addVehicle.Location = new System.Drawing.Point(0, 110);
            this.addVehicle.Name = "addVehicle";
            this.addVehicle.Size = new System.Drawing.Size(200, 50);
            this.addVehicle.TabIndex = 0;
            this.addVehicle.TabStop = false;
            this.addVehicle.Click += new System.EventHandler(this.addVehicle_Click);
            this.addVehicle.MouseEnter += new System.EventHandler(this.addVehicle_MouseEnter);
            this.addVehicle.MouseLeave += new System.EventHandler(this.addVehicle_MouseLeave);
            // 
            // allVehicles
            // 
            this.allVehicles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.allVehicles.BackgroundImage = global::SBBD.Properties.Resources.MWB2off;
            this.allVehicles.Location = new System.Drawing.Point(0, 160);
            this.allVehicles.Name = "allVehicles";
            this.allVehicles.Size = new System.Drawing.Size(200, 50);
            this.allVehicles.TabIndex = 1;
            this.allVehicles.TabStop = false;
            this.allVehicles.Click += new System.EventHandler(this.allVehicles_Click);
            this.allVehicles.MouseEnter += new System.EventHandler(this.allVehicles_MouseEnter);
            this.allVehicles.MouseLeave += new System.EventHandler(this.allVehicles_MouseLeave);
            // 
            // userInfo
            // 
            this.userInfo.BackColor = System.Drawing.Color.Transparent;
            this.userInfo.BackgroundImage = global::SBBD.Properties.Resources.MWB3off;
            this.userInfo.Location = new System.Drawing.Point(0, 210);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(200, 50);
            this.userInfo.TabIndex = 2;
            this.userInfo.TabStop = false;
            this.userInfo.Click += new System.EventHandler(this.userInfo_Click);
            this.userInfo.MouseEnter += new System.EventHandler(this.userInfo_MouseEnter);
            this.userInfo.MouseLeave += new System.EventHandler(this.userInfo_MouseLeave);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Transparent;
            this.settings.BackgroundImage = global::SBBD.Properties.Resources.MWB4off;
            this.settings.Location = new System.Drawing.Point(0, 260);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(200, 50);
            this.settings.TabIndex = 3;
            this.settings.TabStop = false;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            this.settings.MouseEnter += new System.EventHandler(this.settings_MouseEnter);
            this.settings.MouseLeave += new System.EventHandler(this.settings_MouseLeave);
            // 
            // appInfo
            // 
            this.appInfo.BackColor = System.Drawing.Color.Transparent;
            this.appInfo.BackgroundImage = global::SBBD.Properties.Resources.MWB5off;
            this.appInfo.Location = new System.Drawing.Point(0, 310);
            this.appInfo.Name = "appInfo";
            this.appInfo.Size = new System.Drawing.Size(200, 50);
            this.appInfo.TabIndex = 4;
            this.appInfo.TabStop = false;
            this.appInfo.Click += new System.EventHandler(this.appInfo_Click);
            this.appInfo.MouseEnter += new System.EventHandler(this.appInfo_MouseEnter);
            this.appInfo.MouseLeave += new System.EventHandler(this.appInfo_MouseLeave);
            // 
            // mainExit
            // 
            this.mainExit.BackColor = System.Drawing.Color.Transparent;
            this.mainExit.BackgroundImage = global::SBBD.Properties.Resources.MWB6off;
            this.mainExit.Location = new System.Drawing.Point(1240, 0);
            this.mainExit.Name = "mainExit";
            this.mainExit.Size = new System.Drawing.Size(40, 26);
            this.mainExit.TabIndex = 5;
            this.mainExit.TabStop = false;
            this.mainExit.Click += new System.EventHandler(this.mainExit_Click);
            this.mainExit.MouseEnter += new System.EventHandler(this.mainExit_MouseEnter);
            this.mainExit.MouseLeave += new System.EventHandler(this.mainExit_MouseLeave);
            // 
            // mainMinimize
            // 
            this.mainMinimize.BackColor = System.Drawing.Color.Transparent;
            this.mainMinimize.BackgroundImage = global::SBBD.Properties.Resources.MWB7off;
            this.mainMinimize.Location = new System.Drawing.Point(1200, 0);
            this.mainMinimize.Name = "mainMinimize";
            this.mainMinimize.Size = new System.Drawing.Size(40, 26);
            this.mainMinimize.TabIndex = 6;
            this.mainMinimize.TabStop = false;
            this.mainMinimize.Click += new System.EventHandler(this.mainMinimize_Click);
            this.mainMinimize.MouseEnter += new System.EventHandler(this.mainMinimize_MouseEnter);
            this.mainMinimize.MouseLeave += new System.EventHandler(this.mainMinimize_MouseLeave);
            // 
            // mainTitleBar
            // 
            this.mainTitleBar.BackColor = System.Drawing.Color.Transparent;
            this.mainTitleBar.Location = new System.Drawing.Point(200, 0);
            this.mainTitleBar.Name = "mainTitleBar";
            this.mainTitleBar.Size = new System.Drawing.Size(760, 26);
            this.mainTitleBar.TabIndex = 7;
            this.mainTitleBar.TabStop = false;
            this.mainTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainTitleBar_MouseDown);
            this.mainTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainTitleBar_MouseMove);
            this.mainTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainTitleBar_MouseUp);
            // 
            // vehiclesPanel
            // 
            this.vehiclesPanel.BackColor = System.Drawing.Color.Transparent;
            this.vehiclesPanel.Location = new System.Drawing.Point(240, 60);
            this.vehiclesPanel.Name = "vehiclesPanel";
            this.vehiclesPanel.Size = new System.Drawing.Size(1000, 520);
            this.vehiclesPanel.TabIndex = 8;
            // 
            // addVehiclePanel
            // 
            this.addVehiclePanel.BackColor = System.Drawing.Color.Transparent;
            this.addVehiclePanel.Controls.Add(this.addVehicleBtn);
            this.addVehiclePanel.Controls.Add(this.bodyTypeComboBox);
            this.addVehiclePanel.Controls.Add(this.fuelTypeComboBox);
            this.addVehiclePanel.Controls.Add(this.enginePower);
            this.addVehiclePanel.Controls.Add(this.engineCapacity);
            this.addVehiclePanel.Controls.Add(this.regNumber);
            this.addVehiclePanel.Controls.Add(this.vinNumber);
            this.addVehiclePanel.Controls.Add(this.vehicleColor);
            this.addVehiclePanel.Controls.Add(this.prodYear);
            this.addVehiclePanel.Controls.Add(this.label10);
            this.addVehiclePanel.Controls.Add(this.label9);
            this.addVehiclePanel.Controls.Add(this.label8);
            this.addVehiclePanel.Controls.Add(this.label7);
            this.addVehiclePanel.Controls.Add(this.label6);
            this.addVehiclePanel.Controls.Add(this.label5);
            this.addVehiclePanel.Controls.Add(this.label4);
            this.addVehiclePanel.Controls.Add(this.label3);
            this.addVehiclePanel.Controls.Add(this.label2);
            this.addVehiclePanel.Controls.Add(this.modelComboBox);
            this.addVehiclePanel.Controls.Add(this.label1);
            this.addVehiclePanel.Controls.Add(this.manufacturerComboBox);
            this.addVehiclePanel.Location = new System.Drawing.Point(240, 60);
            this.addVehiclePanel.Name = "addVehiclePanel";
            this.addVehiclePanel.Size = new System.Drawing.Size(1000, 520);
            this.addVehiclePanel.TabIndex = 9;
            this.addVehiclePanel.Visible = false;
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(171, 44);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(121, 21);
            this.manufacturerComboBox.TabIndex = 0;
            this.manufacturerComboBox.SelectedIndexChanged += new System.EventHandler(this.ManufacturerComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Marka";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // modelComboBox
            // 
            this.modelComboBox.Enabled = false;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(171, 78);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(121, 21);
            this.modelComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label2.Location = new System.Drawing.Point(33, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(34, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rok produkcji";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label4.Location = new System.Drawing.Point(33, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Typ paliwa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label5.Location = new System.Drawing.Point(38, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Kolor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label6.Location = new System.Drawing.Point(38, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Typ nadwozia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label7.Location = new System.Drawing.Point(38, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Numer VIN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label8.Location = new System.Drawing.Point(38, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Numer rejestracyjny";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label9.Location = new System.Drawing.Point(38, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Poj. silnika";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.label10.Location = new System.Drawing.Point(38, 318);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Moc silnika (KM)";
            // 
            // prodYear
            // 
            this.prodYear.Location = new System.Drawing.Point(171, 110);
            this.prodYear.Name = "prodYear";
            this.prodYear.Size = new System.Drawing.Size(121, 20);
            this.prodYear.TabIndex = 12;
            // 
            // vehicleColor
            // 
            this.vehicleColor.Location = new System.Drawing.Point(171, 172);
            this.vehicleColor.Name = "vehicleColor";
            this.vehicleColor.Size = new System.Drawing.Size(121, 20);
            this.vehicleColor.TabIndex = 13;
            // 
            // vinNumber
            // 
            this.vinNumber.Location = new System.Drawing.Point(171, 224);
            this.vinNumber.Name = "vinNumber";
            this.vinNumber.Size = new System.Drawing.Size(121, 20);
            this.vinNumber.TabIndex = 14;
            // 
            // regNumber
            // 
            this.regNumber.Location = new System.Drawing.Point(171, 260);
            this.regNumber.Name = "regNumber";
            this.regNumber.Size = new System.Drawing.Size(121, 20);
            this.regNumber.TabIndex = 15;
            // 
            // engineCapacity
            // 
            this.engineCapacity.Location = new System.Drawing.Point(171, 287);
            this.engineCapacity.Name = "engineCapacity";
            this.engineCapacity.Size = new System.Drawing.Size(121, 20);
            this.engineCapacity.TabIndex = 16;
            // 
            // enginePower
            // 
            this.enginePower.Location = new System.Drawing.Point(171, 311);
            this.enginePower.Name = "enginePower";
            this.enginePower.Size = new System.Drawing.Size(121, 20);
            this.enginePower.TabIndex = 17;
            // 
            // fuelTypeComboBox
            // 
            this.fuelTypeComboBox.FormattingEnabled = true;
            this.fuelTypeComboBox.Items.AddRange(new object[] {
            "Benzyna",
            "Benzyna + LPG",
            "Benzyna + CNG",
            "Diesel",
            "Elektryczny",
            "Hybryda"});
            this.fuelTypeComboBox.Location = new System.Drawing.Point(171, 141);
            this.fuelTypeComboBox.Name = "fuelTypeComboBox";
            this.fuelTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.fuelTypeComboBox.TabIndex = 18;
            // 
            // bodyTypeComboBox
            // 
            this.bodyTypeComboBox.FormattingEnabled = true;
            this.bodyTypeComboBox.Items.AddRange(new object[] {
            "Cabrio",
            "Coupe",
            "Hatchback",
            "Kombi",
            "Liftback",
            "Limuzyna",
            "Minivan",
            "Pickup",
            "Sedan",
            "SUV",
            "VAN"});
            this.bodyTypeComboBox.Location = new System.Drawing.Point(171, 197);
            this.bodyTypeComboBox.Name = "bodyTypeComboBox";
            this.bodyTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.bodyTypeComboBox.TabIndex = 19;
            // 
            // vehiclesBindingSource
            // 
            this.vehiclesBindingSource.DataSource = typeof(SBBD.Vehicles);
            // 
            // addVehicleBtn
            // 
            this.addVehicleBtn.Location = new System.Drawing.Point(58, 375);
            this.addVehicleBtn.Name = "addVehicleBtn";
            this.addVehicleBtn.Size = new System.Drawing.Size(113, 23);
            this.addVehicleBtn.TabIndex = 20;
            this.addVehicleBtn.Text = "Dodaj Pojazd";
            this.addVehicleBtn.UseVisualStyleBackColor = true;
            this.addVehicleBtn.Click += new System.EventHandler(this.addVehicleBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SBBD.Properties.Resources.MW3;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.addVehiclePanel);
            this.Controls.Add(this.vehiclesPanel);
            this.Controls.Add(this.mainTitleBar);
            this.Controls.Add(this.mainMinimize);
            this.Controls.Add(this.mainExit);
            this.Controls.Add(this.appInfo);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.userInfo);
            this.Controls.Add(this.allVehicles);
            this.Controls.Add(this.addVehicle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Fleet Manager";
            ((System.ComponentModel.ISupportInitialize)(this.addVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTitleBar)).EndInit();
            this.addVehiclePanel.ResumeLayout(false);
            this.addVehiclePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox addVehicle;
        private System.Windows.Forms.PictureBox allVehicles;
        private System.Windows.Forms.PictureBox userInfo;
        private System.Windows.Forms.PictureBox settings;
        private System.Windows.Forms.PictureBox appInfo;
        private System.Windows.Forms.PictureBox mainExit;
        private System.Windows.Forms.PictureBox mainMinimize;
        private System.Windows.Forms.PictureBox mainTitleBar;
        private System.Windows.Forms.Panel vehiclesPanel;
        private System.Windows.Forms.BindingSource vehiclesBindingSource;
        private System.Windows.Forms.Panel addVehiclePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.ComboBox bodyTypeComboBox;
        private System.Windows.Forms.ComboBox fuelTypeComboBox;
        private System.Windows.Forms.TextBox enginePower;
        private System.Windows.Forms.TextBox engineCapacity;
        private System.Windows.Forms.TextBox regNumber;
        private System.Windows.Forms.TextBox vinNumber;
        private System.Windows.Forms.TextBox vehicleColor;
        private System.Windows.Forms.TextBox prodYear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addVehicleBtn;
    }
}