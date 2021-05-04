
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
            this.routeDriver = new System.Windows.Forms.ComboBox();
            this.routeDistance = new System.Windows.Forms.TextBox();
            this.roundedButton2 = new SBBD.RoundedButton();
            this.roundedButton1 = new SBBD.RoundedButton();
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
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.Transparent;
            this.roundedButton2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.roundedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.roundedButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.roundedButton2.ForeColor = System.Drawing.Color.White;
            this.roundedButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.roundedButton2.Location = new System.Drawing.Point(223, 399);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.RoundRadius = 30;
            this.roundedButton2.Size = new System.Drawing.Size(140, 30);
            this.roundedButton2.TabIndex = 1;
            this.roundedButton2.Text = "OK";
            this.roundedButton2.UseVisualStyleBackColor = false;
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.Transparent;
            this.roundedButton1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.roundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.roundedButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.roundedButton1.Location = new System.Drawing.Point(22, 399);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.RoundRadius = 30;
            this.roundedButton1.Size = new System.Drawing.Size(140, 30);
            this.roundedButton1.TabIndex = 0;
            this.roundedButton1.Text = "Anuluj";
            this.roundedButton1.UseVisualStyleBackColor = false;
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 450);
            this.Controls.Add(this.routeDistance);
            this.Controls.Add(this.routeDriver);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Route";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roude";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private System.Windows.Forms.ComboBox routeDriver;
        private System.Windows.Forms.TextBox routeDistance;
    }
}