using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace SBBD
{
    public partial class CustomMessageBoxForm : Form
    {
        PrivateFontCollection pfc;
        
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"Resources\fontBold.ttf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], c.Font.Size, FontStyle.Bold);
                foreach (Control c2 in c.Controls)
                {
                    c2.Font = new Font(pfc.Families[0], c2.Font.Size, FontStyle.Bold);
                }
            }
            messageInfo.Text = "Automatyczne zamykanie komunikatu...";
        }

        public CustomMessageBoxForm()
        {
            InitializeComponent();
        }

        public static void imageChange(int switchNum, PictureBox pb)
        {
            switch (switchNum)
            {
                case 1:
                    pb.Load(@"Resources\CMSBX_info.png");
                    break;
                case 2:
                    pb.Load(@"Resources\CMSBX_question.png");
                    break;
                case 3:
                    // trzeci jakiś obrazek xD
                    break;
            }
        }

        public CustomMessageBoxForm(string text, int miliseconds)
        {
            InitializeComponent();
            this.customMSbx_text.Text = text;
            this.timer.Interval = miliseconds;
            this.messageInfo.Visible = true;
            this.timer.Start();
            imageChange(1, iconPic);
            //this.iconPic.Image = Properties.Resources.   // info
        }

        public CustomMessageBoxForm(string text, bool YesNo)
        {
            InitializeComponent();
            this.customMSbx_text.Text = text;
            this.timer.Enabled = false;
            this.buttonNo.Visible = true;
            this.buttonYes.Visible = true;
            this.messageInfo.Visible = false;
            //this.buttonOK.Visible = false;
            imageChange(2, iconPic);
           //this.iconPic.Image = Properties.Resources.   // pytajnik
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
