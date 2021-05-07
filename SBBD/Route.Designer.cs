
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
            this.driverLName = new System.Windows.Forms.TextBox();
            this.driverFName = new System.Windows.Forms.TextBox();
            this.addDriverButton = new SBBD.RoundedButton();
            this.routeDeparturePanel = new System.Windows.Forms.Panel();
            this.routeDriver = new System.Windows.Forms.ComboBox();
            this.routeCancel = new SBBD.RoundedButton();
            this.routeOK = new SBBD.RoundedButton();
            this.routeReturnPanel = new System.Windows.Forms.Panel();
            this.routeDistance = new System.Windows.Forms.TextBox();
            this.routeDeparturePanel.SuspendLayout();
            this.routeReturnPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.driverLName.Visible = false;
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
            this.driverFName.Visible = false;
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
            this.addDriverButton.Location = new System.Drawing.Point(0, 0);
            this.addDriverButton.Name = "addDriverButton";
            this.addDriverButton.RoundRadius = 30;
            this.addDriverButton.Size = new System.Drawing.Size(31, 30);
            this.addDriverButton.TabIndex = 19;
            this.addDriverButton.Text = "+";
            this.addDriverButton.UseVisualStyleBackColor = false;
            this.addDriverButton.Visible = false;
            // 
            // routeDeparturePanel
            // 
            this.routeDeparturePanel.BackColor = System.Drawing.Color.Transparent;
            this.routeDeparturePanel.BackgroundImage = global::SBBD.Properties.Resources.AvaliableBG12;
            this.routeDeparturePanel.Controls.Add(this.routeDriver);
            this.routeDeparturePanel.Location = new System.Drawing.Point(0, 0);
            this.routeDeparturePanel.Name = "routeDeparturePanel";
            this.routeDeparturePanel.Size = new System.Drawing.Size(400, 110);
            this.routeDeparturePanel.TabIndex = 19;
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
            this.routeDriver.Location = new System.Drawing.Point(223, 70);
            this.routeDriver.Name = "routeDriver";
            this.routeDriver.Size = new System.Drawing.Size(121, 21);
            this.routeDriver.TabIndex = 18;
            this.routeDriver.SelectedIndexChanged += new System.EventHandler(this.routeDriver_SelectedIndexChanged);
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
            this.routeCancel.Location = new System.Drawing.Point(46, 125);
            this.routeCancel.Name = "routeCancel";
            this.routeCancel.RoundRadius = 30;
            this.routeCancel.Size = new System.Drawing.Size(130, 27);
            this.routeCancel.TabIndex = 0;
            this.routeCancel.Text = "Anuluj";
            this.routeCancel.UseVisualStyleBackColor = false;
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
            this.routeOK.Location = new System.Drawing.Point(222, 125);
            this.routeOK.Name = "routeOK";
            this.routeOK.RoundRadius = 30;
            this.routeOK.Size = new System.Drawing.Size(130, 27);
            this.routeOK.TabIndex = 1;
            this.routeOK.Text = "Potwierdź";
            this.routeOK.UseVisualStyleBackColor = false;
            // 
            // routeReturnPanel
            // 
            this.routeReturnPanel.BackColor = System.Drawing.Color.Transparent;
            this.routeReturnPanel.BackgroundImage = global::SBBD.Properties.Resources.AvaliableBG21;
            this.routeReturnPanel.Controls.Add(this.routeDistance);
            this.routeReturnPanel.Location = new System.Drawing.Point(0, 0);
            this.routeReturnPanel.Name = "routeReturnPanel";
            this.routeReturnPanel.Size = new System.Drawing.Size(400, 110);
            this.routeReturnPanel.TabIndex = 20;
            // 
            // routeDistance
            // 
            this.routeDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.routeDistance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.routeDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.routeDistance.ForeColor = System.Drawing.Color.White;
            this.routeDistance.Location = new System.Drawing.Point(228, 75);
            this.routeDistance.Name = "routeDistance";
            this.routeDistance.Size = new System.Drawing.Size(110, 15);
            this.routeDistance.TabIndex = 20;
            this.routeDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.routeDistance.Visible = false;
            this.routeDistance.TextChanged += new System.EventHandler(this.routeDistance_TextChanged);
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.routeCancel);
            this.Controls.Add(this.routeOK);
            this.Controls.Add(this.routeDeparturePanel);
            this.Controls.Add(this.routeReturnPanel);
            this.Controls.Add(this.driverLName);
            this.Controls.Add(this.addDriverButton);
            this.Controls.Add(this.driverFName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Route";
            this.Text = "Route";
            this.routeDeparturePanel.ResumeLayout(false);
            this.routeReturnPanel.ResumeLayout(false);
            this.routeReturnPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton routeCancel;
        private RoundedButton routeOK;
        private System.Windows.Forms.ComboBox routeDriver;
        private System.Windows.Forms.Panel routeDeparturePanel;
        private RoundedButton addDriverButton;
        private System.Windows.Forms.Panel routeReturnPanel;
        private System.Windows.Forms.TextBox driverLName;
        private System.Windows.Forms.TextBox driverFName;
        private System.Windows.Forms.TextBox routeDistance;
    }
}