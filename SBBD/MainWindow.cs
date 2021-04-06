using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace SBBD
{
    
    public partial class MainWindow : Form
    {
        VFEntities context;
        bool moving;
        int moveX;
        int moveY;
        Vehicles vehicle1, vehicle2;
        List<Models> allModels;
        int maxVehicleId;

        int selected;
        public MainWindow()
        {
            InitializeComponent();
            selected = 1;
            
        }

        protected override void OnLoad(EventArgs e)
        {           
            base.OnLoad(e);

            Login.ShowLogin();
            context = new VFEntities();
            context.Vehicles.Load();
            context.Manufacturers.Load();
            this.vehiclesBindingSource.DataSource = context.Vehicles.Local.ToBindingList();
            populatePanel();

        }

            private void addVehicle_MouseEnter(object sender, EventArgs e)
        {
            if(selected != 0)
                addVehicle.BackgroundImage = SBBD.Properties.Resources.MWB1on;
        }

        private void addVehicle_MouseLeave(object sender, EventArgs e)
        {
            if (selected != 0)
                addVehicle.BackgroundImage = SBBD.Properties.Resources.MWB1off;
        }

        private void allVehicles_MouseEnter(object sender, EventArgs e)
        {
            if (selected != 1)
                allVehicles.BackgroundImage = SBBD.Properties.Resources.MWB2on;
        }

        private void allVehicles_MouseLeave(object sender, EventArgs e)
        {
            if (selected != 1)
                allVehicles.BackgroundImage = SBBD.Properties.Resources.MWB2off;
        }

        private void userInfo_MouseEnter(object sender, EventArgs e)
        {
            if (selected != 2)
                userInfo.BackgroundImage = SBBD.Properties.Resources.MWB3on;
        }

        private void userInfo_MouseLeave(object sender, EventArgs e)
        {
            if (selected != 2)
                userInfo.BackgroundImage = SBBD.Properties.Resources.MWB3off;
        }

        private void settings_MouseEnter(object sender, EventArgs e)
        {
            if (selected != 3)
                settings.BackgroundImage = SBBD.Properties.Resources.MWB4on;
        }

        private void settings_MouseLeave(object sender, EventArgs e)
        {
            if (selected != 3)
                settings.BackgroundImage = SBBD.Properties.Resources.MWB4off;
        }

        private void appInfo_MouseEnter(object sender, EventArgs e)
        {
            if (selected != 4)
                appInfo.BackgroundImage = SBBD.Properties.Resources.MWB5on;
        }

        private void appInfo_MouseLeave(object sender, EventArgs e)
        {
            if (selected != 4)
                appInfo.BackgroundImage = SBBD.Properties.Resources.MWB5off;
        }

        private void addVehicle_Click(object sender, EventArgs e)
        {
            if (selected != 0)
            {
                changeBtnTransparent(selected);
                selected = 0;
                addVehicle.BackColor = Color.FromArgb(30, 35, 40);
                addVehicle.BackgroundImage = SBBD.Properties.Resources.MWB1off;
                vehiclesPanel.Visible = false;
                addVehiclePanel.Visible = true;
                if(manufacturerComboBox.Items.Count == 0)
                    addVehicleLoad();
            }
        }

        private void allVehicles_Click(object sender, EventArgs e)
        {
            if (selected != 1)
            {
                changeBtnTransparent(selected);
                selected = 1;
                allVehicles.BackColor = Color.FromArgb(30, 35, 40);
                allVehicles.BackgroundImage = SBBD.Properties.Resources.MWB2off;
                vehiclesPanel.Visible = true;
                addVehiclePanel.Visible = false;
            }
        }

        private void userInfo_Click(object sender, EventArgs e)
        {
            if (selected != 2)
            {
                changeBtnTransparent(selected);
                selected = 2;
                userInfo.BackColor = Color.FromArgb(30, 35, 40);
                userInfo.BackgroundImage = SBBD.Properties.Resources.MWB3off;
                vehiclesPanel.Visible = false;
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {
            if (selected != 3)
            {
                changeBtnTransparent(selected);
                selected = 3;
                settings.BackColor = Color.FromArgb(30, 35, 40);
                settings.BackgroundImage = SBBD.Properties.Resources.MWB4off;
                vehiclesPanel.Visible = false;
            }
        }

        private void appInfo_Click(object sender, EventArgs e)
        {
            if (selected != 4)
            {
                changeBtnTransparent(selected);
                selected = 4;
                appInfo.BackColor = Color.FromArgb(30, 35, 40);
                appInfo.BackgroundImage = SBBD.Properties.Resources.MWB5off;
                vehiclesPanel.Visible = false;
            }
        }

        private void changeBtnTransparent(int num)
        {
            switch (num)
            {
                case 0:
                    addVehicle.BackColor = Color.Transparent;
                    break;
                case 1:
                    allVehicles.BackColor = Color.Transparent;
                    break;
                case 2:
                    userInfo.BackColor = Color.Transparent;
                    break;
                case 3:
                    settings.BackColor = Color.Transparent;
                    break;
                case 4:
                    appInfo.BackColor = Color.Transparent;
                    break;
            }
        }

        private void mainExit_MouseEnter(object sender, EventArgs e)
        {
            mainExit.BackgroundImage = Properties.Resources.MWB6on;
        }

        private void mainExit_MouseLeave(object sender, EventArgs e)
        {
            mainExit.BackgroundImage = Properties.Resources.MWB6off;
        }

        private void mainMinimize_MouseEnter(object sender, EventArgs e)
        {
            mainMinimize.BackgroundImage = SBBD.Properties.Resources.MWB7on;
        }

        private void mainMinimize_MouseLeave(object sender, EventArgs e)
        {
            mainMinimize.BackgroundImage = SBBD.Properties.Resources.MWB7off;
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mainTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            moveX = e.X;
            moveY = e.Y;
        }

        private void mainTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void mainTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                this.SetDesktopLocation(MousePosition.X - 200 - moveX, MousePosition.Y - moveY);
            }
        }

        private PictureBox createTile(Point location)
        {
            PictureBox picBox = new PictureBox();
            picBox.Location = location;
            picBox.Size = new Size(320, 160);
            picBox.BackColor = Color.Gray;
            picBox.Visible = true;
            picBox.MouseClick += new MouseEventHandler(tile_MouseClick);
            return picBox;
        }

        private Label createTileLabel(string content)
        {
            Label lbl = new Label();
            lbl.Location = new Point(0,40);
            lbl.Text = content;
            lbl.Size = new Size(320, 80);
            lbl.ForeColor = Color.White;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Visible = true;
            lbl.Font = new Font("Poppins", 12);
            return lbl;
        }

        private void populatePanel()
        {
            var allveh =  context.Vehicles.Select(x => x).ToList();
            maxVehicleId = allveh.Count;
            vehicle1 = context.Vehicles.Where(v => v.vehicle_id == 1).FirstOrDefault<Vehicles>();
            //vehicle2 = context.Vehicles.Where(v => v.vehicle_id == 2).FirstOrDefault<Vehicles>();
            PictureBox tile1, tile2, tile3, tile4, tile5, tile6, tile7, tile8, tile9;
            tile1 = createTile(new Point(0, 0));
            tile2 = createTile(new Point(340, 0));
            tile3 = createTile(new Point(680, 0));
            tile4 = createTile(new Point(0, 180));
            tile5 = createTile(new Point(340, 180));
            tile6 = createTile(new Point(680, 180));
            tile7 = createTile(new Point(0, 360));
            tile8 = createTile(new Point(340, 360));
            tile9 = createTile(new Point(680, 360));
            

            Label lbl1 = createTileLabel(allveh[0].manufacturer + " " + allveh[0].model + " \n" +allveh[0].registration_num);
            //Label lbl2 = createTileLabel(vehicle2.manufacturer + " " + vehicle2.model);

            vehiclesPanel.Controls.Add(tile1);
            vehiclesPanel.Controls.Add(tile2);
            vehiclesPanel.Controls.Add(tile3);
            vehiclesPanel.Controls.Add(tile4);
            vehiclesPanel.Controls.Add(tile5);
            vehiclesPanel.Controls.Add(tile6);
            vehiclesPanel.Controls.Add(tile7);
            vehiclesPanel.Controls.Add(tile8);
            vehiclesPanel.Controls.Add(tile9);

            tile1.Controls.Add(lbl1);
            //tile2.Controls.Add(lbl2);
        }

        private void addVehicleLoad()
        {
            var allManufacturers = context.Manufacturers.Select(x => x).ToList();
            allModels = context.Models.Select(x => x).ToList();
            foreach (Manufacturers manufacturers in allManufacturers)
            {
                manufacturerComboBox.Items.Add(manufacturers.manufacturer_name);
            }
        }

        private void tile_MouseClick(Object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            MessageBox.Show(pb.Name);
            /*if (pb.Location == new Point(0, 0))
            {
                MessageBox.Show(vehicle1.color);
            }
            else if (pb.Location == new Point(340, 0))
            {
                MessageBox.Show(vehicle2.color);
            }*/
        }

        private void ManufacturerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            modelComboBox.Enabled = true;
            modelComboBox.Items.Clear();
            modelComboBox.Text = "";
            foreach (Models models in allModels)
            {
                if(manufacturerComboBox.Text == models.manufacturer_name)
                {
                    modelComboBox.Items.Add(models.model_name);
                }
            }
        }

        private void addVehicleBtn_Click(object sender, EventArgs e)
        {
            Vehicles vehicle = new Vehicles()
            {
                manufacturer = manufacturerComboBox.Text,
                model = modelComboBox.Text,
                prod_year = Int32.Parse(prodYear.Text),
                fuel_type = fuelTypeComboBox.Text,
                color = vehicleColor.Text,
                body_type = bodyTypeComboBox.Text,
                VIN = vinNumber.Text,
                registration_num = regNumber.Text,
                engine_capacity = Int32.Parse(engineCapacity.Text),
                engine_power = Int32.Parse(enginePower.Text),
                vehicle_id = ++maxVehicleId,
                user_email = "user@email.com",
                available = true
            };
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
            allVehicles_Click(null, null);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.context.Dispose();
        }
    }
}
