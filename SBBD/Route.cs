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
        public static Drivers driver { get; set; }
        public static int distance { get; set; }
        public static string firstName { get; set; }
        public static string lastName { get; set; }

        PrivateFontCollection pfc;
        VFEntities context;
        List<Drivers> allDrivers;
        bool addingDriver = false;
        
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
            
            context = new VFEntities();
            context.Drivers.Load();
            context.Vehicles_Routes.Load();
            routeDistance.Visible = false;
            
            DriversLoad();
        }

        public Route(bool addDriver)
        {
            InitializeComponent();
            addingDriver = true;
            context = new VFEntities();
            context.Drivers.Load();
            addingDriver = addDriver;
            routePanel.Visible = false;
            driverPanel.Visible = true;
            DriversLoad();
        }
        public Route(Drivers driver)
        {
            InitializeComponent();
            context = new VFEntities();
            context.Vehicles_Routes.Load();
            context.Drivers.Load();
            routeDistance.Visible = true;
            addDriverButton.Visible = false;
            routeDriver.Items.Clear();
            routeDriver.Items.Add(driver.driver_id.ToString() + " " + driver.first_name + " " + driver.last_name);
            routeDriver.SelectedIndex = 0;
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!addingDriver)
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    if (routeDistance.Text != "")
                        distance = Int32.Parse(routeDistance.Text);

                    int driver_id = Int32.Parse(routeDriver.Text.Split(' ')[0]);
                    driver = context.Drivers.Where(d => d.driver_id == driver_id).FirstOrDefault();
                    driver.available = routeDistance.Visible;
                    context.SaveChanges();
                }
            }
            else
            {

                if (this.DialogResult == DialogResult.OK)
                {
                    firstName = driverFName.Text;
                    lastName = driverLName.Text;
                }
            }
            context.Dispose();
        }
        private void DriversLoad()
        {
            string driver_text;
            allDrivers = context.Drivers.Select(d=>d).ToList();
            foreach (Drivers driver in allDrivers)
            {
                if (driver.available)
                {
                    driver_text = driver.driver_id.ToString() + " " + driver.first_name + " " + driver.last_name;
                    routeDriver.Items.Add(driver_text);
                }
            }
        }

        private void addDriverButton_Click(object sender, EventArgs e)
        {

            var editRoute = EditRoute.ShowEdit(true);
            if (editRoute == DialogResult.OK)
            {
                Drivers driver = new Drivers()
                {
                    first_name = firstName,
                    last_name = lastName,
                    available = true
                };
                context.Drivers.Add(driver);
                context.SaveChanges();
            }
        }

        private void driverFName_TextChanged(object sender, EventArgs e)
        {
            routeOK.Enabled = driverFName.Text != "" && driverLName.Text != "";
        }

        private void routeDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (routeDistance.Visible)
            {
                routeOK.Enabled = routeDriver.SelectedIndex != -1 && routeDistance.Text != "";
            }
            else
            {
                routeOK.Enabled = routeDriver.SelectedIndex != -1;
            }
        }

        private void routeDistance_TextChanged(object sender, EventArgs e)
        {
            routeOK.Enabled = routeDriver.SelectedIndex != -1 && routeDistance.Text != "";
        }
    }
}
