
namespace SBBD
{
    partial class CustomMessageBoxForm
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonYes = new SBBD.RoundedButton();
            this.buttonNo = new SBBD.RoundedButton();
            this.iconPic = new System.Windows.Forms.PictureBox();
            this.customMSbx_text = new SBBD.CustomTextBox();
            this.messageInfo = new SBBD.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.Color.Transparent;
            this.buttonYes.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.buttonYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonYes.FlatAppearance.BorderSize = 0;
            this.buttonYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonYes.ForeColor = System.Drawing.Color.White;
            this.buttonYes.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.buttonYes.Location = new System.Drawing.Point(20, 100);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.RoundRadius = 30;
            this.buttonYes.Size = new System.Drawing.Size(120, 30);
            this.buttonYes.TabIndex = 0;
            this.buttonYes.Text = "Tak";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Visible = false;
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.Color.Transparent;
            this.buttonNo.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.buttonNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonNo.FlatAppearance.BorderSize = 0;
            this.buttonNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNo.ForeColor = System.Drawing.Color.White;
            this.buttonNo.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.buttonNo.Location = new System.Drawing.Point(160, 100);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.RoundRadius = 30;
            this.buttonNo.Size = new System.Drawing.Size(120, 30);
            this.buttonNo.TabIndex = 1;
            this.buttonNo.Text = "Nie";
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Visible = false;
            // 
            // iconPic
            // 
            this.iconPic.BackColor = System.Drawing.Color.Transparent;
            this.iconPic.Location = new System.Drawing.Point(35, 30);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(35, 35);
            this.iconPic.TabIndex = 3;
            this.iconPic.TabStop = false;
            // 
            // customMSbx_text
            // 
            this.customMSbx_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.customMSbx_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customMSbx_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customMSbx_text.ForeColor = System.Drawing.Color.White;
            this.customMSbx_text.IsPassword = false;
            this.customMSbx_text.Location = new System.Drawing.Point(90, 25);
            this.customMSbx_text.Multiline = true;
            this.customMSbx_text.Name = "customMSbx_text";
            this.customMSbx_text.PlaceHolder = null;
            this.customMSbx_text.Size = new System.Drawing.Size(180, 60);
            this.customMSbx_text.TabIndex = 1;
            this.customMSbx_text.TabStop = false;
            this.customMSbx_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // messageInfo
            // 
            this.messageInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.messageInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.messageInfo.ForeColor = System.Drawing.Color.White;
            this.messageInfo.IsPassword = false;
            this.messageInfo.Location = new System.Drawing.Point(20, 100);
            this.messageInfo.Multiline = true;
            this.messageInfo.Name = "messageInfo";
            this.messageInfo.PlaceHolder = null;
            this.messageInfo.Size = new System.Drawing.Size(260, 30);
            this.messageInfo.TabIndex = 0;
            this.messageInfo.TabStop = false;
            this.messageInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CustomMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SBBD.Properties.Resources.BGcustomMBX2;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.messageInfo);
            this.Controls.Add(this.customMSbx_text);
            this.Controls.Add(this.iconPic);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomMessageBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private RoundedButton buttonYes;
        private RoundedButton buttonNo;
        private System.Windows.Forms.PictureBox iconPic;
        private CustomTextBox customMSbx_text;
        private CustomTextBox messageInfo;
    }
}