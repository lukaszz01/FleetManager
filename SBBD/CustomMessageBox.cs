using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBBD
{
    public partial class CustomMessageBoxForm : Form
    {
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
        public CustomMessageBoxForm()
        {
            InitializeComponent();
        }

        public CustomMessageBoxForm(string text, int miliseconds)
        {
            InitializeComponent();
            this.messageText.Text = text;
            this.timer.Interval = miliseconds;
            this.timer.Start();
            //this.iconPic.Image = Properties.Resources.   // info

        }

        public CustomMessageBoxForm(string text, bool YesNo)
        {
            InitializeComponent();
            this.messageText.Text = text;
            this.timer.Enabled = false;
            this.buttonNo.Visible = true;
            this.buttonYes.Visible = true;
            //this.iconPic.Image = Properties.Resources.   // pytajnik
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
