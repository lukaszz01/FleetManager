
namespace SBBD
{
    partial class Route
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
            this.routeDriver = new System.Windows.Forms.ComboBox();
            this.routeDistance = new System.Windows.Forms.TextBox();
            this.routePanel = new System.Windows.Forms.Panel();
            this.driverPanel = new System.Windows.Forms.Panel();
            this.driverLName = new System.Windows.Forms.TextBox();
            this.driverFName = new System.Windows.Forms.TextBox();
            this.addDriverButton = new SBBD.RoundedButton();
            this.routeOK = new SBBD.RoundedButton();
            this.routeCancel = new SBBD.RoundedButton();
            this.vehiclesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vehiclesRoutesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.driversBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.routePanel.SuspendLayout();
            this.driverPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesRoutesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // routeDriver
            // 
            this.routeDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.routeDriver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.routeDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.routeDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routeDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.routeDriver.ForeColor = System.Drawing.Color.White;
            this.routeDriver.FormattingEnabled = true;
            this.routeDriver.Location = new System.Drawing.Point(104, 27);
            this.routeDriver.Name = "routeDriver";
            this.routeDriver.Size = new System.Drawing.Size(121, 21);
            this.routeDriver.TabIndex = 18;
            this.routeDriver.SelectedIndexChanged += new System.EventHandler(this.routeDriver_SelectedIndexChanged);
            // 
            // routeDistance
            // 
            this.routeDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.routeDistance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.routeDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.routeDistance.ForeColor = System.Drawing.Color.White;
            this.routeDistance.Location = new System.Drawing.Point(104, 98);
            this.routeDistance.Name = "routeDistance";
            this.routeDistance.Size = new System.Drawing.Size(160, 15);
            this.routeDistance.TabIndex = 0;
            this.routeDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.routeDistance.Visible = false;
            this.routeDistance.TextChanged += new System.EventHandler(this.routeDistance_TextChanged);
            // 
            // routePanel
            // 
            this.routePanel.Controls.Add(this.addDriverButton);
            this.routePanel.Controls.Add(this.routeDriver);
            this.routePanel.Controls.Add(this.routeDistance);
            this.routePanel.Location = new System.Drawing.Point(64, 12);
            this.routePanel.Name = "routePanel";
            this.routePanel.Size = new System.Drawing.Size(299, 306);
            this.routePanel.TabIndex = 19;
            // 
            // driverPanel
            // 
            this.driverPanel.Controls.Add(this.driverLName);
            this.driverPanel.Controls.Add(this.driverFName);
            this.driverPanel.Location = new System.Drawing.Point(64, 12);
            this.driverPanel.Name = "driverPanel";
            this.driverPanel.Size = new System.Drawing.Size(299, 306);
            this.driverPanel.TabIndex = 20;
            this.driverPanel.Visible = false;
            // 
            // driverLName
            // 
            this.driverLName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.driverLName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.driverLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverLName.ForeColor = System.Drawing.Color.White;
            this.driverLName.Location = new System.Drawing.Point(89, 98);
            this.driverLName.Name = "driverLName";
            this.driverLName.Size = new System.Drawing.Size(160, 15);
            this.driverLName.TabIndex = 2;
            this.driverLName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.driverLName.TextChanged += new System.EventHandler(this.driverFName_TextChanged);
            // 
            // driverFName
            // 
            this.driverFName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.driverFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.driverFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.driverFName.ForeColor = System.Drawing.Color.White;
            this.driverFName.Location = new System.Drawing.Point(89, 44);
            this.driverFName.Name = "driverFName";
            this.driverFName.Size = new System.Drawing.Size(160, 15);
            this.driverFName.TabIndex = 1;
            this.driverFName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.driverFName.TextChanged += new System.EventHandler(this.driverFName_TextChanged);
            // 
            // addDriverButton
            // 
            this.addDriverButton.BackColor = System.Drawing.Color.Transparent;
            this.addDriverButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.addDriverButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addDriverButton.FlatAppearance.BorderSize = 0;
            this.addDriverButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addDriverButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addDriverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDriverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addDriverButton.ForeColor = System.Drawing.Color.White;
            this.addDriverButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.addDriverButton.Location = new System.Drawing.Point(233, 21);
            this.addDriverButton.Name = "addDriverButton";
            this.addDriverButton.RoundRadius = 30;
            this.addDriverButton.Size = new System.Drawing.Size(31, 30);
            this.addDriverButton.TabIndex = 19;
            this.addDriverButton.Text = "+";
            this.addDriverButton.UseVisualStyleBackColor = false;
            this.addDriverButton.Click += new System.EventHandler(this.addDriverButton_Click);
            // 
            // routeOK
            // 
            this.routeOK.BackColor = System.Drawing.Color.Transparent;
            this.routeOK.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.routeOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.routeOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.routeOK.Enabled = false;
            this.routeOK.FlatAppearance.BorderSize = 0;
            this.routeOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.routeOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.routeOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routeOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.routeOK.ForeColor = System.Drawing.Color.White;
            this.routeOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.routeOK.Location = new System.Drawing.Point(223, 399);
            this.routeOK.Name = "routeOK";
            this.routeOK.RoundRadius = 30;
            this.routeOK.Size = new System.Drawing.Size(140, 30);
            this.routeOK.TabIndex = 1;
            this.routeOK.Text = "OK";
            this.routeOK.UseVisualStyleBackColor = false;
            // 
            // routeCancel
            // 
            this.routeCancel.BackColor = System.Drawing.Color.Transparent;
            this.routeCancel.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.routeCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.routeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.routeCancel.FlatAppearance.BorderSize = 0;
            this.routeCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.routeCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.routeCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routeCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.routeCancel.ForeColor = System.Drawing.Color.White;
            this.routeCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.routeCancel.Location = new System.Drawing.Point(22, 399);
            this.routeCancel.Name = "routeCancel";
            this.routeCancel.RoundRadius = 30;
            this.routeCancel.Size = new System.Drawing.Size(140, 30);
            this.routeCancel.TabIndex = 0;
            this.routeCancel.Text = "Anuluj";
            this.routeCancel.UseVisualStyleBackColor = false;
            // 
            // vehiclesBindingSource
            // 
            this.vehiclesBindingSource.DataSource = typeof(SBBD.Vehicles);
            // 
            // vehiclesRoutesBindingSource
            // 
            this.vehiclesRoutesBindingSource.DataMember = "Vehicles_Routes";
            this.vehiclesRoutesBindingSource.DataSource = this.vehiclesBindingSource;
            // 
            // driversBindingSource
            // 
            this.driversBindingSource.DataSource = typeof(SBBD.Drivers);
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 450);
            this.Controls.Add(this.routePanel);
            this.Controls.Add(this.driverPanel);
            this.Controls.Add(this.routeOK);
            this.Controls.Add(this.routeCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Route";
            this.Text = "Route";
            this.routePanel.ResumeLayout(false);
            this.routePanel.PerformLayout();
            this.driverPanel.ResumeLayout(false);
            this.driverPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesRoutesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton routeCancel;
        private RoundedButton routeOK;
        private System.Windows.Forms.ComboBox routeDriver;
        private System.Windows.Forms.TextBox routeDistance;
        private System.Windows.Forms.Panel routePanel;
        private RoundedButton addDriverButton;
        private System.Windows.Forms.Panel driverPanel;
        private System.Windows.Forms.TextBox driverLName;
        private System.Windows.Forms.TextBox driverFName;
        private System.Windows.Forms.BindingSource vehiclesBindingSource;
        private System.Windows.Forms.BindingSource vehiclesRoutesBindingSource;
        private System.Windows.Forms.BindingSource driversBindingSource;
    }
}