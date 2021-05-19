
namespace SBBD
{
    partial class RouteReport
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
            this.reportCancel = new SBBD.RoundedButton();
            this.reportOK = new SBBD.RoundedButton();
            this.reportStartDate = new SBBD.CustomDTPicker();
            this.reportEndDate = new SBBD.CustomDTPicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportCancel
            // 
            this.reportCancel.BackColor = System.Drawing.Color.Transparent;
            this.reportCancel.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.reportCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.reportCancel.FlatAppearance.BorderSize = 0;
            this.reportCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.reportCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.reportCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.reportCancel.ForeColor = System.Drawing.Color.White;
            this.reportCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.reportCancel.Location = new System.Drawing.Point(48, 183);
            this.reportCancel.Name = "reportCancel";
            this.reportCancel.RoundRadius = 30;
            this.reportCancel.Size = new System.Drawing.Size(140, 30);
            this.reportCancel.TabIndex = 45;
            this.reportCancel.Text = "Anuluj";
            this.reportCancel.UseVisualStyleBackColor = false;
            // 
            // reportOK
            // 
            this.reportOK.BackColor = System.Drawing.Color.Transparent;
            this.reportOK.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.reportOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.reportOK.FlatAppearance.BorderSize = 0;
            this.reportOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.reportOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.reportOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.reportOK.ForeColor = System.Drawing.Color.White;
            this.reportOK.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.reportOK.Location = new System.Drawing.Point(202, 183);
            this.reportOK.Name = "reportOK";
            this.reportOK.RoundRadius = 30;
            this.reportOK.Size = new System.Drawing.Size(140, 30);
            this.reportOK.TabIndex = 44;
            this.reportOK.Text = "Zatwierdź";
            this.reportOK.UseVisualStyleBackColor = false;
            // 
            // reportStartDate
            // 
            this.reportStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.reportStartDate.BackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.reportStartDate.CalendarForeColor = System.Drawing.Color.White;
            this.reportStartDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.reportStartDate.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.reportStartDate.CustomFormat = "dd MMMM yyyy";
            this.reportStartDate.ForeColor = System.Drawing.Color.White;
            this.reportStartDate.Location = new System.Drawing.Point(173, 45);
            this.reportStartDate.Name = "reportStartDate";
            this.reportStartDate.Size = new System.Drawing.Size(158, 20);
            this.reportStartDate.TabIndex = 46;
            // 
            // reportEndDate
            // 
            this.reportEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.reportEndDate.BackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.reportEndDate.CalendarForeColor = System.Drawing.Color.White;
            this.reportEndDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.reportEndDate.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.reportEndDate.CustomFormat = "dd MMMM yyyy";
            this.reportEndDate.ForeColor = System.Drawing.Color.White;
            this.reportEndDate.Location = new System.Drawing.Point(173, 110);
            this.reportEndDate.Name = "reportEndDate";
            this.reportEndDate.Size = new System.Drawing.Size(158, 20);
            this.reportEndDate.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(45, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "Początek";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Koniec";
            // 
            // RouteReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(400, 236);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportEndDate);
            this.Controls.Add(this.reportStartDate);
            this.Controls.Add(this.reportCancel);
            this.Controls.Add(this.reportOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RouteReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RouteReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton reportCancel;
        private RoundedButton reportOK;
        private CustomDTPicker reportStartDate;
        private CustomDTPicker reportEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}