﻿using System;
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
using System.Drawing.Drawing2D;

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
                if (manufacturerComboBox.Items.Count == 0)
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
            switch (MessageBox.Show("Czy na pewno chcesz się wylogować?", "Informacja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                case DialogResult.Yes:
                    AutoClosingMessageBox.Show(text: "Pomyślnie wylogowano! Zamykanie aplikacji...", caption: "Informacja", timeout: 2000);
                    this.Hide();
                    this.OnLoad(null);
                    this.Refresh();
                    this.Show();
                    break;
                case DialogResult.No:
                    changeBtnTransparent(selected);
                    selected = 1;
                    allVehicles.BackColor = Color.FromArgb(30, 35, 40);
                    allVehicles.BackgroundImage = SBBD.Properties.Resources.MWB2off;
                    HideOtherPanels(vehiclesPanel);
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

        private void mainExit_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Czy na pewno chcesz zamknąć aplikację?",
                        "Informacja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                case DialogResult.Yes:
                    AutoClosingMessageBox.Show(text: "Pomyślnie wylogowano! Zamykanie aplikacji...", caption: "Informacja", timeout: 2000);
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
                if (!RegexD(@"^[a-zA-Z0-9]+$", regNumber)) ShowErrorMsg(warnLabel1);
                if (!RegexD(@"^[0-9]{3,5}$", engineCapacity)) ShowErrorMsg(warnLabel5);
                if (!RegexD(@"^[0-9]{2,4}$", enginePower)) ShowErrorMsg(warnLabel6);
            }
            else
            {
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
                AutoClosingMessageBox.Show(text: "Pomyślnie dodano pojazd!", caption: "Informacja", timeout: 1500);
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
            Image checkVehicle = Image.FromFile(@"Resources\vehicleCheck1.png");
            Image uncheckVehicle = Image.FromFile(@"Resources\vehicleUncheck1.png");
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
                if(vehicle.available == true)
                {
                    g.DrawImage(checkVehicle, 10, 10, 20, 20);
                }
                else
                {
                    g.DrawImage(uncheckVehicle, 10, 10, 20, 20);
                }
                
            }

            pictureBox.Image = bm;
            label.Text = vehicle.manufacturer + " " + vehicle.model + "\n " + vehicle.registration_num;

            vehImage = null;
            bm2.Dispose();
            infoimg.Dispose();
            editimg.Dispose();
            deleteimg.Dispose();

            checkVehicle.Dispose();
            uncheckVehicle.Dispose();
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
            siteCounter.Text = currentPage.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
                currentPage--;
            populatePanel();
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
            var question = MessageBox.Show("Czy na pewno chcesz edytować dane pojazdu?", "Informacja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(question == DialogResult.Yes)
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
            else { }
        }

        private void infoVehicleFill()
        {
            HideOtherPanels(infoVehiclePanel);
            string regNumStr = (vLabelList[editSelecetedId].Text.Split(' '))[2];
            Vehicles selectedVehicle = context.Vehicles.Where(v => v.registration_num == regNumStr).FirstOrDefault<Vehicles>();
            Vehicles_Images selectedVehicleImage = context.Vehicles_Images.Where(x => x.vehicle_id == selectedVehicle.vehicle_id).FirstOrDefault<Vehicles_Images>();
            infoManufacturer.Text = selectedVehicle.manufacturer;
            infoVehicleImage.Image = ByteToImage(selectedVehicleImage.vehicle_image);
            infoModel.Text = selectedVehicle.model;
            infoRegNum.Text = selectedVehicle.registration_num;
            infoVehicleColor.Text = selectedVehicle.color;
            infoFuelType.Text = selectedVehicle.fuel_type;
            infoBodyType.Text = selectedVehicle.body_type;
            infoProdYear.Text = Convert.ToString(selectedVehicle.prod_year);
            infoVinNum.Text = selectedVehicle.VIN;
            infoEngineCapacity.Text = Convert.ToString(selectedVehicle.engine_capacity);
            infoEnginePower.Text = Convert.ToString(selectedVehicle.engine_power);
           
            if (selectedVehicle.available == false)
                infoAvaliable.Text = "Nie";
            else
                infoAvaliable.Text = "Tak";

            selectedVehicle = null;
            selectedVehicleImage = null;
        }

        private void deleteVehicle()
        {
            var warn = MessageBox.Show("Czy na pewno chcesz usunąć ten pojazd?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (warn == DialogResult.Yes)
            {
                string regNumStr = (vLabelList[editSelecetedId].Text.Split(' '))[2];
                Vehicles selectedVehicle = context.Vehicles.Where(v => v.registration_num == regNumStr).FirstOrDefault<Vehicles>();
                Vehicles_Images selectedVehicleImage = context.Vehicles_Images.Where(x => x.vehicle_id == selectedVehicle.vehicle_id).FirstOrDefault<Vehicles_Images>();
                this.context.Vehicles.Remove(selectedVehicle);
                this.context.Vehicles_Images.Remove(selectedVehicleImage);
                this.context.SaveChanges();
                allVehicles_Click(null, null);
                populatePanel();
            }
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

            var quest = MessageBox.Show("Usunąć wprowadzone dane?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(quest == DialogResult.Yes)
            {
                bodyTypeComboBox.SelectedIndex = -1;
                fuelTypeComboBox.SelectedIndex = -1;
                enginePower.ClearText();
                engineCapacity.ClearText();
                regNumber.ClearText();
                vinNumber.ClearText();
                vehicleColor.ClearText();
                prodYear.ClearText();
                modelComboBox.SelectedIndex = -1;
                manufacturerComboBox.SelectedIndex = -1;
                modelComboBox.Enabled = false;
                selectedImage.Image = null;
            }
            else { }
           
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

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            populatePanel();
        }

        private void infoReturnBtn_Click(object sender, EventArgs e)
        {
            HideOtherPanels(vehiclesPanel);
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            customButton1.SelectedMenuItem = !customButton1.SelectedMenuItem;
        }
    }
}