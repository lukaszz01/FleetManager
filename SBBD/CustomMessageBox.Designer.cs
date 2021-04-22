
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
            this.messageText = new System.Windows.Forms.Label();
            this.iconPic = new System.Windows.Forms.PictureBox();
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
            this.buttonYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonYes.FlatAppearance.BorderSize = 0;
            this.buttonYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonYes.ForeColor = System.Drawing.Color.White;
            this.buttonYes.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.buttonYes.Location = new System.Drawing.Point(34, 199);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.RoundRadius = 30;
            this.buttonYes.Size = new System.Drawing.Size(140, 30);
            this.buttonYes.TabIndex = 0;
            this.buttonYes.Text = "Tak";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Visible = false;
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.Color.Transparent;
            this.buttonNo.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.buttonNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonNo.FlatAppearance.BorderSize = 0;
            this.buttonNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNo.ForeColor = System.Drawing.Color.White;
            this.buttonNo.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(150)))), ((int)(((byte)(253)))));
            this.buttonNo.Location = new System.Drawing.Point(216, 199);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.RoundRadius = 30;
            this.buttonNo.Size = new System.Drawing.Size(140, 30);
            this.buttonNo.TabIndex = 1;
            this.buttonNo.Text = "Nie";
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Visible = false;
            // 
            // messageText
            // 
            this.messageText.AutoSize = true;
            this.messageText.BackColor = System.Drawing.Color.Transparent;
            this.messageText.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.messageText.ForeColor = System.Drawing.Color.White;
            this.messageText.Location = new System.Drawing.Point(268, 85);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(49, 23);
            this.messageText.TabIndex = 2;
            this.messageText.Text = "label1";
            // 
            // iconPic
            // 
            this.iconPic.Location = new System.Drawing.Point(57, 57);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(100, 50);
            this.iconPic.TabIndex = 3;
            this.iconPic.TabStop = false;
            // 
            // CustomMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SBBD.Properties.Resources.ConfirmBG;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.iconPic);
            this.Controls.Add(this.messageText);
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
        private System.Windows.Forms.Label messageText;
        private System.Windows.Forms.PictureBox iconPic;
    }
}