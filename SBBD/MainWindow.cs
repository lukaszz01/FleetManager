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
using System.Text.RegularExpressions;
using System.IO;

namespace SBBD
{
    
    public partial class MainWindow : Form
    {
        VFEntities context;
        bool moving;
        int moveX;
        int moveY;
        List<Models> allModels;
        int vehicleCount;
        int vehiclePages;
        int currentPage;
        int editSelecetedId;
        List<PictureBox> tileList;
        List<Label> vLabelList;

        int selected;
        public MainWindow()
        {
            InitializeComponent();
            selected = 1;
            currentPage = 1;

            tileList = new List<PictureBox>()
            {
                pictureBox00,
                pictureBox01,
                pictureBox02,
                pictureBox10,
                pictureBox11,
                pictureBox12,
                pictureBox20,
                pictureBox21,
                pictureBox22
            };
            vLabelList = new List<Label>()
            {
                vLabel00,
                vLabel01,
                vLabel02,
                vLabel10,
                vLabel11,
                vLabel12,
                vLabel20,
                vLabel21,
                vLabel22
            };
            
        }

        protected override void OnLoad(EventArgs e)
        {           
            base.OnLoad(e);

            Login.ShowLogin();
            context = new VFEntities();
            context.Vehicles.Load();
            context.Manufacturers.Load();
            this.vehiclesBindingSource.DataSource = context.Vehicles.Local.ToBindingList();
            vehiclePages = 0;

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

        /*private PictureBox createTile(Point location)
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
        }*/

        private void populatePanel()
        {
            foreach(Label l in vLabelList)
            {
                l.Text = "";
            }
            foreach(PictureBox p in tileList)
            {
                p.Image = null;
            }
            var allVehicles = context.Vehicles.Select(x => x).ToList();
            vehicleCount = allVehicles.Count;
            if(vehiclePages == 0)
                vehiclePages = (vehicleCount / 9) + 1;

            for(int i = 0; i < (currentPage==vehiclePages?(vehicleCount % 9):9); i++)
            {
                ShowVehicleTile(tileList[i], vLabelList[i], allVehicles[i+((currentPage-1)*9)]);
            }
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

        /*private void tile_MouseClick(Object sender, MouseEventArgs e)
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
            }
        }*/

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
            if (IsEmpty(manufacturerComboBox) ||
                IsEmpty(modelComboBox) ||
                IsEmpty(prodYear) ||
                IsEmpty(fuelTypeComboBox) ||
                IsEmpty(vehicleColor) ||
                IsEmpty(bodyTypeComboBox) ||
                IsEmpty(vinNumber) ||
                IsEmpty(regNumber) ||
                IsEmpty(engineCapacity) ||
                IsEmpty(enginePower)
                )
            {
                //MessageBox.Show("Pola nie mogą być puste!");
                warnLabel7.Text = "Uzupełnij wszystkie dostępne pola!";
            }
            else if (
                !RegexD(@"^[0-9]{4}$", prodYear, warnLabel3) ||
                !RegexD(@"^[a-zA-Z]+$", vehicleColor, warnLabel2) ||
                !RegexD(@"^[A-HJ-NPR-Za-hj-npr-z\d]{8}[\dX][A-HJ-NPR-Za-hj-npr-z\d]{2}\d{6}$", vinNumber, warnLabel4) ||
                !RegexD(@"^[a-zA-Z0-9]+$", regNumber, warnLabel1) ||
                !RegexD(@"^[0-9]{3,5}$", engineCapacity, warnLabel5) ||
                !RegexD(@"^[0-9]{2,4}$", enginePower, warnLabel6)
                ) { }
            else
            {
                //RegexD(@"\d{4}", prodYear); //Tylko cyfry
                //RegexD(@"^[0-9]+$", prodYear); //Tylko cyfry
                //RegexD(@"^[a-zA-Z]+$", vehicleColor); //Tylko litery
                //RegexD(@"^[A-HJ-NPR-Za-hj-npr-z\d]{8}[\dX][A-HJ-NPR-Za-hj-npr-z\d]{2}\d{6}$", vinNumber); //17 znaków
                //RegexD(@"^[a-zA-Z0-9]+$", regNumber); //Tylko cyfry i litery

                //RegexD(@"\d{3,5}", engineCapacity);
                //RegexD(@"^[0-9]+$", engineCapacity); //Tylko cyfry

                //RegexD(@"^[0-9]+$", enginePower); //Tylko cyfry

                // Trzeba wyjątek jak pola są puste, inaczej sie krzaczy xD
                warnLabel7.Text = "";
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
                    vehicle_id = ++vehicleCount,
                    user_email = "user@email.com",
                    available = true
                };
                context.Vehicles.Add(vehicle);
                context.SaveChanges();
                allVehicles_Click(null, null);
                populatePanel();
            }
        }

        private bool RegexD(string reg, TextBox textbox, Label labelTest)
        {
            Regex regex = new Regex(reg);
            if (!regex.IsMatch(textbox.Text))
            {
                labelTest.Text = "Wprowadzone wyrażenie jest niepoprawne!";
               // MessageBox.Show(textbox.Name + " wprowadzony źle");
                return false;
            }
            else
            {
                labelTest.Text = "";
                return true;
            }
        }

        private bool IsEmpty(TextBox textBox)
        {
            return textBox.Text == "";
        }
        private bool IsEmpty(ComboBox comboBox)
        {
            return comboBox.Text == "";
        }

        private void ShowVehicleTile(PictureBox pictureBox, Label label, Vehicles vehicle)
        {
            //Vehicles_Images vehImage = context.Vehicles_Images.Where(v => v.vehicle_id == vehicle.vehicle_id).FirstOrDefault<Vehicles_Images>();
            //Bitmap bm = ByteToImage(vehImage.vehicle_image);
            //pictureBox.Image = bm;
            label.Text = vehicle.manufacturer + " " + vehicle.model + "\n" + vehicle.registration_num;
            
        }

        private Bitmap ByteToImage(byte[] image)
        {
            MemoryStream mStream = new MemoryStream();
            mStream.Write(image, 0, Convert.ToInt32(image.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.context.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(currentPage + 1 <= vehiclePages)
            currentPage++;
            populatePanel();
        }

        private void tile_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            editSelecetedId = (tileList.IndexOf(pb) + 1) + ((currentPage - 1) * 9);
            vehiclesPanel.Visible = false;
            editVehiclePanel.Visible = true;
            Vehicles selectedVehicle = context.Vehicles.Where(v => v.vehicle_id == editSelecetedId).FirstOrDefault<Vehicles>();
            editManufacturer.Text = selectedVehicle.manufacturer;
            editModel.Text = selectedVehicle.model;
            editRegNum.Text = selectedVehicle.registration_num;
            editVehicleColor.Text = selectedVehicle.color;
            editFuelType.Text = selectedVehicle.fuel_type;
            editBodyType.Text = selectedVehicle.body_type;
            editProdYear.Text = Convert.ToString(selectedVehicle.prod_year);
            editVinNum.Text = selectedVehicle.VIN;
            editEngineCapacity.Text = Convert.ToString(selectedVehicle.engine_capacity);
            editEnginePower.Text = Convert.ToString(selectedVehicle.engine_power);
            if (selectedVehicle.available == false)
                editAvailable.Text = "Nie";
            else
                editAvailable.Text = "Tak";

        }

        private void editCancel_Click(object sender, EventArgs e)
        {
            vehiclesPanel.Visible = true;
            editVehiclePanel.Visible = false;
        }

        private void editConfirm_Click(object sender, EventArgs e)
        {
            if (IsEmpty(editVehicleColor) ||
                IsEmpty(editRegNum)
                )
            {
                MessageBox.Show("Pola nie mogą być puste!");
            }
            //else if (
            //    !RegexD(@"^[a-zA-Z]+$", editVehicleColor) ||
            //    !RegexD(@"^[a-zA-Z0-9]+$", editRegNum)
            //    ) { }
            else
            {
                Vehicles selectedVehicle = context.Vehicles.Where(v => v.vehicle_id == editSelecetedId).FirstOrDefault<Vehicles>();
                selectedVehicle.registration_num = editRegNum.Text;
                selectedVehicle.color = editVehicleColor.Text;
                selectedVehicle.available = editAvailable.Text == "Tak" ? true : false;
                context.SaveChanges();
                vehiclesPanel.Visible = true;
                editVehiclePanel.Visible = false;
                populatePanel();
            }
        }

        private void regNumber_Enter(object sender, EventArgs e)
        {
            if (regNumber.Text == "np. LHR12345")
            {
                regNumber.Text = "";
                regNumber.ForeColor = Color.White;
            }
        }

        private void regNumber_Leave(object sender, EventArgs e)
        {
            if (regNumber.Text == "")
            {
                regNumber.Text = "np. LHR12345";
                regNumber.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void vehicleColor_Enter(object sender, EventArgs e)
        {
            if (vehicleColor.Text == "np. Czarny")
            {
                vehicleColor.Text = "";
                vehicleColor.ForeColor = Color.White;
            }
        }

        private void vehicleColor_Leave(object sender, EventArgs e)
        {
            if (vehicleColor.Text == "")
            {
                vehicleColor.Text = "np. Czarny";
                vehicleColor.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void prodYear_Enter(object sender, EventArgs e)
        {
            if (prodYear.Text == "np. 2021")
            {
                prodYear.Text = "";
                prodYear.ForeColor = Color.White;
            }
        }

        private void prodYear_Leave(object sender, EventArgs e)
        {
            if (prodYear.Text == "")
            {
                prodYear.Text = "np. 2021";
                prodYear.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void vinNumber_Enter(object sender, EventArgs e)
        {
            if (vinNumber.Text == "17 - cyfrowy VIN")
            {
                vinNumber.Text = "";
                vinNumber.ForeColor = Color.White;
            }
        }

        private void vinNumber_Leave(object sender, EventArgs e)
        {
            if (vinNumber.Text == "")
            {
                vinNumber.Text = "17 - cyfrowy VIN";
                vinNumber.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void engineCapacity_Enter(object sender, EventArgs e)
        {
            if (engineCapacity.Text == "np. 3000")
            {
                engineCapacity.Text = "";
                engineCapacity.ForeColor = Color.White;
            }
        }

        private void engineCapacity_Leave(object sender, EventArgs e)
        {
            if (engineCapacity.Text == "")
            {
                engineCapacity.Text = "np. 3000";
                engineCapacity.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void enginePower_Enter(object sender, EventArgs e)
        {
            if (enginePower.Text == "np. 240")
            {
                enginePower.Text = "";
                enginePower.ForeColor = Color.White;
            }
        }

        private void enginePower_Leave(object sender, EventArgs e)
        {
            if (enginePower.Text == "")
            {
                enginePower.Text = "np. 240";
                enginePower.ForeColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void addVehicleBtn_MouseEnter(object sender, EventArgs e)
        {
            addVehicleBtn.BackgroundImage = SBBD.Properties.Resources.AddBTN_active;
        }

        private void addVehicleBtn_MouseLeave(object sender, EventArgs e)
        {
            addVehicleBtn.BackgroundImage = SBBD.Properties.Resources.AddBTN_inactive;
        }

        private void clearVehicleBtn_MouseEnter(object sender, EventArgs e)
        {
            clearVehicleBtn.BackgroundImage = SBBD.Properties.Resources.ClearBTN_active;
        }

        private void clearVehicleBtn_MouseLeave(object sender, EventArgs e)
        {
            clearVehicleBtn.BackgroundImage = SBBD.Properties.Resources.ClearBTN_inactive;
        }
    }
}


