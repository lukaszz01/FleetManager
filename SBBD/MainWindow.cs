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
using System.Drawing.Text;

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
        byte[] image;
        Users user;
        PrivateFontCollection pfc;

        int selected;
        public MainWindow()
        {          
            InitializeComponent();
            selected = 1;
            currentPage = 1;
            siteCounter.Text = currentPage.ToString();

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
            user = Login.logged_user_value;
            if (user != null)
            {
                pfc = new PrivateFontCollection();
                pfc.AddFontFile(@"Resources\fontBold.ttf");
                foreach (Control c in this.Controls)
                {
                    foreach (Control c2 in c.Controls)
                    {
                        c2.Font = new Font(pfc.Families[0], c2.Font.Size, FontStyle.Bold);
                        foreach (Control c3 in c2.Controls)
                        {
                            c3.Font = new Font(pfc.Families[0], c3.Font.Size, FontStyle.Bold);
                        }
                    }
                }
                context = new VFEntities();
                context.Vehicles.Load();
                context.Manufacturers.Load();
                vehiclePages = 0;
            
                populatePanel();

                toolTip.SetToolTip(infoBox1, "Poprawny format 6-8 znaków (a-z, A-Z, 0-9)");
                toolTip.SetToolTip(infoBox2, "Poprawny format A-Z, bez spacji");
                toolTip.SetToolTip(infoBox3, "Poprawny format 4 znaki (0-9)");
                toolTip.SetToolTip(infoBox4, "Poprawny format 17 znaków - 11 znaków (A-Z, 0-9), 6 znaków (0-9)");
                toolTip.SetToolTip(infoBox5, "Poprawny format 3-5 znaków (0-9)");
                toolTip.SetToolTip(infoBox6, "Poprawny format 2-4 znaki (0-9)");

                userNameInfo.Text = user.email;
            }
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

        private void appInfo_MouseEnter(object sender, EventArgs e)
        {
            if (selected != 3)
                appInfo.BackgroundImage = SBBD.Properties.Resources.MWB5on;
        }

        private void appInfo_MouseLeave(object sender, EventArgs e)
        {
            if (selected != 3)
                appInfo.BackgroundImage = SBBD.Properties.Resources.MWB5off;
        }

        private void logout_MouseEnter(object sender, EventArgs e)
        {
            if (selected != 4)
                logout.BackgroundImage = SBBD.Properties.Resources.OffBTN_active;
        }

        private void logout_MouseLeave(object sender, EventArgs e)
        {
            if (selected != 4)
                logout.BackgroundImage = SBBD.Properties.Resources.OffBTN_inactive;
        }

        private void addVehicle_Click(object sender, EventArgs e)
        {
            if (selected != 0)
            {
                changeBtnTransparent(selected);
                selected = 0;
                addVehicle.BackColor = Color.FromArgb(30, 35, 40);
                addVehicle.BackgroundImage = SBBD.Properties.Resources.MWB1off;
                HideOtherPanels(addVehiclePanel);
                //vehiclesPanel.Visible = false;
                //addVehiclePanel.Visible = true;
                //editVehiclePanel.Visible = false;
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
                HideOtherPanels(vehiclesPanel);
                //vehiclesPanel.Visible = true;
                //addVehiclePanel.Visible = false;
                //editVehiclePanel.Visible = false;
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

        private void appInfo_Click(object sender, EventArgs e)
        {
            if (selected != 3)
            {
                changeBtnTransparent(selected);
                selected = 3;
                appInfo.BackColor = Color.FromArgb(30, 35, 40);
                appInfo.BackgroundImage = SBBD.Properties.Resources.MWB5off;
                vehiclesPanel.Visible = false;
            }
        }

        private void HideOtherPanels(Panel panel)
        {
            Panel toHide;
            panel.Visible = true;
            foreach(Control control in this.Controls)
            {
                try
                {
                    toHide = (Panel)control;
                    if(toHide != panel)
                    {
                        toHide.Visible = false;
                    }
                } catch
                {

                }
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (selected != 4)
            {
                changeBtnTransparent(selected);
                selected = 4;
                logout.BackColor = Color.FromArgb(30, 35, 40);
                logout.BackgroundImage = SBBD.Properties.Resources.OffBTN_inactive;
           
            }
            switch (MessageBox.Show("Czy na pewno chcesz się wylogować?", "Informacja", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    AutoClosingMessageBox.Show("Pomyślnie wylogowano!", "Informacja", 1500);
                    this.Hide();
                    this.OnLoad(null);
                    this.Refresh();
                    this.Show();
                    break;
                case DialogResult.No:
                    break;
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
                    appInfo.BackColor = Color.Transparent;
                    break;
                case 4:
                    logout.BackColor = Color.Transparent;
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
            switch (MessageBox.Show("Czy na pewno chcesz zamknąć aplikację?",
                        "Informacja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    AutoClosingMessageBox.Show("Pomyślnie wylogowano!", "Informacja", 1500);
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
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

        private void populatePanel()
        {
            foreach (Label l in vLabelList)
            {
                l.Text = "";
            }
            foreach (PictureBox p in tileList)
            {
                p.Image = null;
            }

            if (user.admin == true)
            {
                var allVehicles = context.Vehicles.Select(x => x).ToList();     

                vehicleCount = allVehicles.Count;

                if (vehiclePages == 0)
                    vehiclePages = (vehicleCount / 9) + 1;

                for (int i = 0; i < (currentPage == vehiclePages ? (vehicleCount % 9) : 9); i++)
                {
                    ShowVehicleTile(tileList[i], vLabelList[i], allVehicles[i + ((currentPage - 1) * 9)]);
                }

                allVehicles = null;
            }

            else
            {
                var userVehicles = context.Vehicles.Where(x => x.user_email == user.email).ToList();

                vehicleCount = userVehicles.Count;
                if (vehiclePages == 0)
                    vehiclePages = (vehicleCount / 9) + 1;


                for (int i = 0; i < (currentPage == vehiclePages ? (vehicleCount % 9) : 9); i++)
                {
                    ShowVehicleTile(tileList[i], vLabelList[i], userVehicles[i + ((currentPage - 1) * 9)]);
                }

                userVehicles = null;
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
            allManufacturers = null;
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
            if (IsEmpty(manufacturerComboBox) ||
                IsEmpty(modelComboBox) ||
                IsEmpty(prodYear, "np. 2021") ||
                IsEmpty(fuelTypeComboBox) ||
                IsEmpty(vehicleColor, "np. Czarny") ||
                IsEmpty(bodyTypeComboBox) ||
                IsEmpty(vinNumber, "17 - znakowy VIN") ||
                IsEmpty(regNumber, "np. LHR12345") ||
                IsEmpty(engineCapacity, "np. 3000") ||
                IsEmpty(enginePower, "np. 240")               
                )
            {
                //MessageBox.Show("Pola nie mogą być puste!");
                
                warningTimer.Start();
                warnLabel7.Visible = true;
            }
            else if(selectedImage.Image == null)
            {
                warningTimer.Start();
                warnLabel8.Visible = true;
            }
            else if (
                !RegexD(@"^[0-9]{4}$", prodYear) ||
                !RegexD(@"^[a-zA-Z]+$", vehicleColor) ||
                !RegexD(@"^[A-HJ-NPR-Z0-9]{11}[0-9]{6}$", vinNumber) ||
                !RegexD(@"^[a-zA-Z0-9]+$", regNumber) ||
                !RegexD(@"^[0-9]{3,5}$", engineCapacity) ||
                !RegexD(@"^[0-9]{2,4}$", enginePower)
                ) 
            {
                if (!RegexD(@"^[0-9]{4}$", prodYear)) ShowErrorMsg(warnLabel3);
                if (!RegexD(@"^[a-zA-Z]+$", vehicleColor)) ShowErrorMsg(warnLabel2);
                if (!RegexD(@"^[A-HJ-NPR-Z0-9]{11}[0-9]{6}$", vinNumber)) ShowErrorMsg(warnLabel4);
                //if (!RegexD(@" ^[A-HJ-NPR-Za-hj-npr-z\d]{8}[\dX][A-HJ-NPR-Za-hj-npr-z\d]{2}\d{6}$", vinNumber)) ShowErrorMsg(warnLabel4);
                if (!RegexD(@"^[a-zA-Z0-9]+$", regNumber)) ShowErrorMsg(warnLabel1);
                if (!RegexD(@"^[0-9]{3,5}$", engineCapacity)) ShowErrorMsg(warnLabel5);
                if (!RegexD(@"^[0-9]{2,4}$", enginePower)) ShowErrorMsg(warnLabel6);
            }
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
                    user_email = user.email,
                    available = true
                };
                Vehicles_Images vehicleImage = new Vehicles_Images()
                {
                    vehicle_id = vehicle.vehicle_id,
                    vehicle_image = image,
                };
                AutoClosingMessageBox.Show("Pomyślnie dodano pojazd!", "Informacja", 1500);
                context.Vehicles.Add(vehicle);
                context.Vehicles_Images.Add(vehicleImage);
                context.SaveChanges();
                allVehicles_Click(null, null);
                populatePanel();

                vehicle = null;
                vehicleImage = null;
            }
        }

        private void ShowErrorMsg(Label warnLabel)
        {
            warnLabel.Visible = true;
            warningTimer.Start();
        }
        private bool RegexD(string reg, TextBox textbox)
        {
            Regex regex = new Regex(reg);
            if (!regex.IsMatch(textbox.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsEmpty(TextBox textBox, string placeholder)
        {
            return textBox.Text == "" || textBox.Text == placeholder;
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
            Vehicles_Images vehImage = context.Vehicles_Images.Where(v => v.vehicle_id == vehicle.vehicle_id).FirstOrDefault<Vehicles_Images>();
            Bitmap bm = new Bitmap(310, 174);
            Bitmap bm2 = ByteToImage(vehImage.vehicle_image);
            Image infoimg = Image.FromFile(@"Resources\info.png");
            Image editimg = Image.FromFile(@"Resources\edit.png");
            Image deleteimg = Image.FromFile(@"Resources\delete.png");
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(bm2, 0, 0, 310, 174);
            }

            Rectangle r = new Rectangle(0, 0, bm.Width, bm.Height);
            int alpha = trackBar1.Value;
            using (Graphics g = Graphics.FromImage(bm))

            {
                using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
                {
                    g.FillRectangle(cloud_brush, r);
                }
            }

            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(deleteimg, 275, 139, 20, 20);
                g.DrawImage(infoimg, 240, 139, 20, 20);
                g.DrawImage(editimg, 205, 139, 20, 20);
            }


            pictureBox.Image = bm;
            label.Text = vehicle.manufacturer + " " + vehicle.model + "\n " + vehicle.registration_num;

            vehImage = null;
            bm2.Dispose();
            infoimg.Dispose();
            editimg.Dispose();
            deleteimg.Dispose();
        }

        private Bitmap ByteToImage(byte[] image)
        {
            MemoryStream mStream = new MemoryStream();
            mStream.Write(image, 0, Convert.ToInt32(image.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private byte[] ImageToByte(string fileName)
        {
            Image img = Image.FromFile(@fileName);
            byte[] image;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                image = ms.ToArray();
            }
            return image;
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
            //SiteCounter();
            siteCounter.Text = currentPage.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
                currentPage--;
            populatePanel();
            //SiteCounter();
            siteCounter.Text = currentPage.ToString();
        }

        private void tile_Click(object sender, EventArgs e)
        {
                PictureBox pb = (PictureBox)sender;
                editSelecetedId = tileList.IndexOf(pb);
            if (vLabelList[editSelecetedId].Text != "")
            {
                Point mouseCoordinates = ((MouseEventArgs)e).Location;

                if (mouseCoordinates.X >= 205 && mouseCoordinates.X <= 225 && mouseCoordinates.Y >= 139 && mouseCoordinates.Y <= 159)
                    editVehicleFill();
                if (mouseCoordinates.X >= 240 && mouseCoordinates.X <= 260 && mouseCoordinates.Y >= 139 && mouseCoordinates.Y <= 159)
                    infoVehicleFill();
                if (mouseCoordinates.X >= 275 && mouseCoordinates.X <= 295 && mouseCoordinates.Y >= 139 && mouseCoordinates.Y <= 159)
                    deleteVehicle();
            }
        }

        private void editVehicleFill()
        {
            HideOtherPanels(editVehiclePanel);
            string regNumStr = (vLabelList[editSelecetedId].Text.Split(' '))[2];
            Vehicles selectedVehicle = context.Vehicles.Where(v => v.registration_num == regNumStr).FirstOrDefault<Vehicles>();
            Vehicles_Images selectedVehicleImage = context.Vehicles_Images.Where(x => x.vehicle_id == selectedVehicle.vehicle_id).FirstOrDefault<Vehicles_Images>();
            editManufacturer.Text = selectedVehicle.manufacturer;
            editVehicleImage.Image = ByteToImage(selectedVehicleImage.vehicle_image);
            editModel.Text = selectedVehicle.model;
            editRegNum.Text = selectedVehicle.registration_num;
            editVehicleColor.Text = selectedVehicle.color;
            editFuelType.Text = selectedVehicle.fuel_type;
            editBodyType.Text = selectedVehicle.body_type;
            editProdYear.Text = Convert.ToString(selectedVehicle.prod_year);
            editVinNum.Text = selectedVehicle.VIN;
            editEngineCapacity.Text = Convert.ToString(selectedVehicle.engine_capacity);
            editEnginePower.Text = Convert.ToString(selectedVehicle.engine_power);

            if (user.admin == true)
            {
                userLabel.Text = selectedVehicle.user_email;
                userLabel.Visible = true;
                userLabel1.Visible = true;
            }

            if (selectedVehicle.available == false)
                editAvailable.Text = "Nie";
            else
                editAvailable.Text = "Tak";

            selectedVehicle = null;
            selectedVehicleImage = null;
        }

        private void infoVehicleFill()
        {
            HideOtherPanels(infoVehiclePanel);
        }

        private void deleteVehicle()
        {

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
                string regNumStr = (vLabelList[editSelecetedId].Text.Split(' '))[2];
                Vehicles selectedVehicle = context.Vehicles.Where(v => v.registration_num == regNumStr).FirstOrDefault<Vehicles>();
                selectedVehicle.registration_num = editRegNum.Text;
                selectedVehicle.color = editVehicleColor.Text;
                selectedVehicle.available = editAvailable.Text == "Tak" ? true : false;
                context.SaveChanges();
                vehiclesPanel.Visible = true;
                editVehiclePanel.Visible = false;
                populatePanel();

                selectedVehicle = null;
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
            if (vinNumber.Text == "17 - znakowy VIN")
            {
                vinNumber.Text = "";
                vinNumber.ForeColor = Color.White;
            }
        }

        private void vinNumber_Leave(object sender, EventArgs e)
        {
            if (vinNumber.Text == "")
            {
                vinNumber.Text = "17 - znakowy VIN";
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

        private void addPhotoBtn_MouseEnter(object sender, EventArgs e)
        {
            addPhotoBtn.BackgroundImage = SBBD.Properties.Resources.PhotoBTN_active;
        }

        private void addPhotoBtn_MouseLeave(object sender, EventArgs e)
        {
            addPhotoBtn.BackgroundImage = SBBD.Properties.Resources.PhotoBTN_inactive;
        }

        private void warningTimer_Tick(object sender, EventArgs e)
        {
            warningTimer.Stop();
            warnLabel1.Visible = false;
            warnLabel2.Visible = false;
            warnLabel3.Visible = false;
            warnLabel4.Visible = false;
            warnLabel5.Visible = false;
            warnLabel6.Visible = false;
            warnLabel7.Visible = false;
            warnLabel8.Visible = false;
        }

        private void clearVehicleBtn_Click(object sender, EventArgs e)
        {
            bodyTypeComboBox.SelectedIndex = -1;
            fuelTypeComboBox.SelectedIndex = -1;
            enginePower.Text = "";
            enginePower_Leave(null, null);
            engineCapacity.Text = "";
            engineCapacity_Leave(null, null);
            regNumber.Text = "";
            regNumber_Leave(null, null);
            vinNumber.Text = "";
            vinNumber_Leave(null, null);
            vehicleColor.Text = "";
            vehicleColor_Leave(null, null);
            prodYear.Text = "";
            prodYear_Leave(null, null);
            modelComboBox.SelectedIndex = -1;
            manufacturerComboBox.SelectedIndex = -1;
            modelComboBox.Enabled = false;
            selectedImage.Image = null;
        }

        private void addPhotoBtn_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Wybierz zdjęcie";
                openFileDialog.Filter = "Plik JPEG (*.jpg)|*.jpg|Plik PNG (*.png)|*.png";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImage.Image = new Bitmap(openFileDialog.FileName);
                    image = ImageToByte(openFileDialog.FileName);
                }
            }
        }


        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            DialogResult _result;
            DialogResult _timerResult;
            AutoClosingMessageBox(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                _timerResult = timerResult;
                using (_timeoutTimer)
                    _result = MessageBox.Show(text, caption, buttons);
            }
            public static DialogResult Show(string text, string caption, int timeout, MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
            {
                return new AutoClosingMessageBox(text, caption, timeout, buttons, timerResult)._result;
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
                _result = _timerResult;
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            populatePanel();
        }
    }
}