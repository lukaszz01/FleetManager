using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace SBBD
{
    public partial class Route : Form
    {
        public static Drivers driver
        {
            get; set;
        }
        public static int distance
        {
            get; set;
        }

        PrivateFontCollection pfc;
        VFEntities context;
        List<Drivers> allDrivers;
        
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
            base.OnLoad(e);
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
        }

        public Route()
        {
            InitializeComponent();
            routeDistance.Visible = false;
            context = new VFEntities();
            context.Vehicles_Routes.Load();
            context.Drivers.Load();
            DriversLoad();
        }
        /*public Route(bool zmienna)
        {
            InitializeComponent();
            if (zmienna)
            {
                routeDistance.Visible = false;

            }
            else
            {
                routeDistance.Visible = true;
            }

        }*/
        public Route(Drivers driver)
        {
            InitializeComponent();
            context = new VFEntities();
            context.Vehicles_Routes.Load();
            context.Drivers.Load();
            routeDistance.Visible = true;
            routeDriver.Items.Clear();
            routeDriver.Items.Add(driver.driver_id.ToString() + " " + driver.first_name + " " + driver.last_name);
            routeDriver.SelectedIndex = 0;
            //routeDriver.Enabled = false;
        }
        /*protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            distance = Int32.Parse(routeDistance.Text);
            int driver_id = Int32.Parse(routeDriver.Text.Split(' ')[0]);
            driver = context.Drivers.Where(d => d.driver_id == driver_id).FirstOrDefault();
            context.Dispose();
        }*/

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (this.DialogResult == DialogResult.OK)
            {
                if (routeDistance.Text != "")
                distance = Int32.Parse(routeDistance.Text);
            
                int driver_id = Int32.Parse(routeDriver.Text.Split(' ')[0]);
                driver = context.Drivers.Where(d => d.driver_id == driver_id).FirstOrDefault();
            }
            context.Dispose();
        }
        private void DriversLoad()
        {
            string driver_text;
            allDrivers = context.Drivers.Select(d=>d).ToList();
            foreach (Drivers driver in allDrivers)
            {
                driver_text = driver.driver_id.ToString() + " " + driver.first_name + " " + driver.last_name;
                routeDriver.Items.Add(driver_text);
            }
        }
    }
}
