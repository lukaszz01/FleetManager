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
using System.Drawing.Drawing2D;
using static SBBD.ExtendedClass;

namespace SBBD
{
    public partial class MainWindow : Form
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

        VFEntities context;
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
        List<Manufacturers> allManufacturers;

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
                context.Vehicles_Routes.Load();
                context.Drivers.Load();
                vehiclePages = 0;
                populatePanel();

                toolTip.SetToolTip(infoBox1, "Poprawny format 6-8 znaków (a-z, A-Z, 0-9)");
                toolTip.SetToolTip(infoBox2, "Poprawny format A-Z, bez spacji");
                toolTip.SetToolTip(infoBox3, "Poprawny format 4 znaki (0-9)");
                toolTip.SetToolTip(infoBox4, "Poprawny format 17 znaków - 11 znaków (A-Z, 0-9), 6 znaków (0-9)");
                toolTip.SetToolTip(infoBox5, "Poprawny format 3-5 znaków (0-9)");
                toolTip.SetToolTip(infoBox6, "Poprawny format 2-4 znaki (0-9)");
                userNameInfo.Text = user.email;
                allManufacturers = context.Manufacturers.Select(x => x).ToList();
                allModels = context.Models.Select(x => x).ToList();
                filterManufacturer.Items.Add("Wszystkie");
                filterModel.Items.Add("Wszystkie");
                if(filterManufacturer.Items.Count == 1)
                    ManufacturersLoad(filterManufacturer);
                trackBar1.Value = user.darken;
                comboBox1.SelectedIndex = 0;
                filterManufacturer.SelectedIndex = 0;
                filterAvailable.SelectedIndex = 2;
            }
        }

        private void addVehicle_Click(object sender, EventArgs e)
        {
            if (selected != 0)
            {
                changeBtnTransparent(selected, addVehicle);
                selected = 0;
                HideOtherPanels(addVehiclePanel, this.Controls);
                if(manufacturerComboBox.Items.Count == 0)
                    ManufacturersLoad(manufacturerComboBox);
            }
        }

        private void allVehicles_Click(object sender, EventArgs e)
        {
            if (selected != 1)
            {
                changeBtnTransparent(selected, allVehicles);
                selected = 1;
                HideOtherPanels(vehiclesPanel, this.Controls);
            }
        }

        private void userInfo_Click(object sender, EventArgs e)
        {
            if (selected != 2)
            {
                changeBtnTransparent(selected, userInfo);
                selected = 2;
                HideOtherPanels(userInfoPanel, this.Controls);
            }
        }

        private void appInfo_Click(object sender, EventArgs e)
        {
            if (selected != 3)
            {
                changeBtnTransparent(selected, appInfo);
                selected = 3;
                HideOtherPanels(appInfoPanel, this.Controls);
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (selected != 4)
            {
                HideOtherPanels(vehiclesPanel, this.Controls);
                changeBtnTransparent(selected, logout);
                selected = 4;
                switch (CustomMessageBox.CustomMsg("Czy na pewno chcesz\n się wylogować?", 1500, true))
                {
                    case DialogResult.Yes:
                        CustomMessageBox.CustomMsg("Pomyślnie wylogowano!\n Zamykanie aplikacji...", 2000, false);
                        this.Hide();
                        this.Refresh();
                        this.OnLoad(null);
                        this.Invalidate();
                        FormCollection fc = Application.OpenForms;
                        foreach (Form form in fc)
                        {
                            if (form.Name == "MainWindow")
                            {
                                this.Show();
                                break;
                            }
                        }
                        break;
                    case DialogResult.No:
                        allVehicles_Click(null, null);
                        break;
                }
            }
        }
        private void changeBtnTransparent(int num, CustomButton button)
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
            button.BackColor = Color.FromArgb(30, 35, 40);
        }

        private void mainExit_Click(object sender, EventArgs e) => AppExit("Czy na pewno chcesz \n zamknąć aplikację?");

        private void mainMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

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

            List<Vehicles> vehFilter, vehList;

            if (!user.admin)
            {
                vehFilter = context.Vehicles.Where(v => v.user_email == user.email).ToList();
            }
            else
            {
                vehFilter = context.Vehicles.Select(v => v).ToList();
            }

            if (filterManufacturer.SelectedIndex == -1 || filterManufacturer.SelectedIndex == 0)
            {
                vehFilter = vehFilter.Select(v => v).ToList();
            }
            else
            {
                vehFilter = vehFilter.Where(v => v.manufacturer == filterManufacturer.Text).ToList();
            }

            if (filterModel.SelectedIndex == -1 || filterModel.SelectedIndex == 0)
            {
                vehFilter = vehFilter.Select(v => v).ToList();
            }
            else
            {
                vehFilter = vehFilter.Where(v => v.model == filterModel.Text).ToList();
            }

            if (filterAvailable.SelectedIndex == -1 || filterAvailable.SelectedIndex == 2)
            {
                vehFilter = vehFilter.Select(v => v).ToList();
            }
            else if (filterAvailable.SelectedIndex == 0)
            {
                vehFilter = vehFilter.Where(v => v.available).ToList();
            }
            else
            {
                vehFilter = vehFilter.Where(v => !v.available).ToList();
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    vehList = vehFilter.Select(v => v).ToList();
                    break;
                case 1:
                    vehList = vehFilter.Select(v => v).OrderByDescending(v => v.available).ToList();
                    break;
                case 2:
                    vehList = vehFilter.Select(v => v).OrderBy(v => v.available).ToList();
                    break;
                case 3:
                    vehList = vehFilter.Select(v => v).OrderBy(v => v.manufacturer).ToList();
                    break;
                case 4:
                    vehList = vehFilter.Select(v => v).OrderByDescending(v => v.manufacturer).ToList();
                    break;
                default:
                    vehList = vehFilter.Select(v => v).ToList();
                    break;
            }

            if (user.admin)
            {
                //var allVehicles = context.Vehicles.Select(x => x).ToList();     
                vehicleCount = vehList.Count;

                if (vehiclePages == 0)
                    vehiclePages = (vehicleCount / 9) + 1;
                if (currentPage > vehiclePages)
                {
                    currentPage = vehiclePages;
                    siteCounter.Text = currentPage.ToString();
                }

                for (int i = 0; i < (currentPage == vehiclePages ? (vehicleCount % 9) : 9); i++)
                {
                    ShowVehicleTile(tileList[i], vLabelList[i], vehList[i + ((currentPage - 1) * 9)], trackBar1, context, checkBox1);
                }
                //vehList = null;
            }

            else
            {
                //var userVehicles = context.Vehicles.Where(x => x.user_email == user.email).ToList();
                vehicleCount = vehList.Count;
                if (vehiclePages == 0)
                    vehiclePages = (vehicleCount / 9) + 1;
                if (currentPage > vehiclePages)
                {
                    currentPage = vehiclePages;
                    siteCounter.Text = currentPage.ToString();
                }

                for (int i = 0; i < (currentPage == vehiclePages ? (vehicleCount % 9) : 9); i++)
                {
                    ShowVehicleTile(tileList[i], vLabelList[i], vehList[i + ((currentPage - 1) * 9)], trackBar1, context, checkBox1);
                }
                //vehList = null;
            }
            vehFilter = null;
            vehList = null;
        }

        private void ManufacturersLoad(ComboBox comboBox)
        {
            foreach (Manufacturers manufacturers in allManufacturers)
            {
                comboBox.Items.Add(manufacturers.manufacturer_name);
            }
        }

        private void ManufacturerComboBox_SelectedIndexChanged(object sender, EventArgs e) => ModelsLoad(manufacturerComboBox, modelComboBox);

        private void ModelsLoad(ComboBox manufacturersComboBox, ComboBox modelsComboBox)
        {
            modelsComboBox.Enabled = true;
            modelsComboBox.Items.Clear();
            modelsComboBox.SelectedIndex = -1;
            modelsComboBox.Text = "";
            foreach (Models models in allModels)
            {
                if (manufacturersComboBox.Text == models.manufacturer_name)
                {
                    modelsComboBox.Items.Add(models.model_name);
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
                IsEmpty(enginePower, "np. 240") ||
                IsEmpty(vehMilage, "np. 50 000")
                )
            {
                warningTimer.Start();
                warnLabel7.Visible = true;
            }
            else if (selectedImage.Image == null)
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
                !RegexD(@"^[0-9]{2,4}$", enginePower) ||
                !RegexD(@"^[0-9]{7}$", vehMilage)
                )
            {
                if (!RegexD(@"^[0-9]{4}$", prodYear)) ShowErrorMsg(warnLabel3, warningTimer);
                if (!RegexD(@"^[a-zA-Z]+$", vehicleColor)) ShowErrorMsg(warnLabel2, warningTimer);
                if (!RegexD(@"^[A-HJ-NPR-Z0-9]{11}[0-9]{6}$", vinNumber)) ShowErrorMsg(warnLabel4, warningTimer);
                if (!RegexD(@"^[a-zA-Z0-9]+$", regNumber)) ShowErrorMsg(warnLabel1, warningTimer);
                if (!RegexD(@"^[0-9]{3,5}$", engineCapacity)) ShowErrorMsg(warnLabel5, warningTimer);
                if (!RegexD(@"^[0-9]{2,4}$", enginePower)) ShowErrorMsg(warnLabel6, warningTimer);
                if (!RegexD(@"^[0-9]{7}$", vehMilage)) ShowErrorMsg(warnLabel9, warningTimer);
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
                    available = true,
                    mileage = vehMilage.Text
                };
                Vehicles_Images vehicleImage = new Vehicles_Images()
                {
                    vehicle_id = vehicle.vehicle_id,
                    vehicle_image = image,
                };
                CustomMessageBox.CustomMsg("Pomyślnie dodano \n pojazd do bazy!", 2000, false);
                context.Vehicles.Add(vehicle);
                context.Vehicles_Images.Add(vehicleImage);
                context.SaveChanges();
                allVehicles_Click(null, null);
                populatePanel();

                vehicle = null;
                vehicleImage = null;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.context.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage + 1 <= vehiclePages)
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
                if (mouseCoordinates.X >= 10 && mouseCoordinates.X <= 30 && mouseCoordinates.Y >= 10 && mouseCoordinates.Y <= 30)
                    vehAvaliable();
            }
        }

        private void vehAvaliable()
        {
            var msg = CustomMessageBox.CustomMsg("Zmienić dostępność?", 0, true);
            string regNumStr = (vLabelList[editSelecetedId].Text.Split('\n'))[1].Trim();
            Vehicles selectedVehicle = context.Vehicles.Where(v => v.registration_num == regNumStr).FirstOrDefault<Vehicles>();
            if (msg == DialogResult.Yes)
            {
                /*HideOtherPanels(updateVehiclePanel, this.Controls);*/
                //EditRoute.ShowEdit(true);
                if (selectedVehicle.available) {
                    var editRoute = EditRoute.ShowEdit();
                    if (editRoute == DialogResult.OK)
                    {
                        selectedVehicle.available = false;
                        Vehicles_Routes vehicleRoute = new Vehicles_Routes()
                        {
                            vehicle_id = selectedVehicle.vehicle_id,
                            driver_id = Route.driver.driver_id,
                            start_date = DateTime.Now
                        };
                        context.Vehicles_Routes.Add(vehicleRoute);
                    }
                }
                else
                {
                    var allRoutes = context.Vehicles_Routes.Where(r => r.vehicle_id == selectedVehicle.vehicle_id).ToList();
                    allRoutes.Reverse();
                    Vehicles_Routes vehRoute = allRoutes[0];
                    Drivers driver = context.Drivers.Where(d => d.driver_id == vehRoute.driver_id).FirstOrDefault();
                    var editRoute = EditRoute.ShowEdit(driver);
                    if(editRoute == DialogResult.OK)
                    {
                        selectedVehicle.available = true;
                        vehRoute.distance = Route.distance;
                        vehRoute.end_date = DateTime.Now;
                    }
                }
                
            }
            context.SaveChanges();
            populatePanel();
            selectedVehicle = null;
        } 

        private void editVehicleFill()
        {
            var question = CustomMessageBox.CustomMsg("Czy na pewno chcesz \n edytować dane?", 1500, true);
            if (question == DialogResult.Yes)
            {
                HideOtherPanels(editVehiclePanel, this.Controls);
                string regNumStr = (vLabelList[editSelecetedId].Text.Split('\n'))[1].Trim();
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
            HideOtherPanels(infoVehiclePanel, this.Controls);
            string regNumStr = (vLabelList[editSelecetedId].Text.Split('\n'))[1].Trim();
            Vehicles selectedVehicle = context.Vehicles.Where(v => v.registration_num == regNumStr).FirstOrDefault<Vehicles>();
            CustomMessageBox.CustomMsg(selectedVehicle.registration_num, 0, true);
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
            //infoDistance.Text = Convert.ToString(selectedVehicle.distances);
            infoMilage.Text = selectedVehicle.mileage;

            if (selectedVehicle.available == false)
                infoAvaliable.Text = "Nie";
            else
                infoAvaliable.Text = "Tak";

            selectedVehicle = null;
            selectedVehicleImage = null;
        }

        private void deleteVehicle()
        {
            var warn = CustomMessageBox.CustomMsg("Czy na pewno chcesz \n usunąć ten pojazd?", 1500, true);
            if (warn == DialogResult.Yes)
            {
                string regNumStr = (vLabelList[editSelecetedId].Text.Split('\n'))[1].Trim();
                Vehicles selectedVehicle = context.Vehicles.Where(v => v.registration_num == regNumStr).FirstOrDefault<Vehicles>();
                Vehicles_Images selectedVehicleImage = context.Vehicles_Images.Where(x => x.vehicle_id == selectedVehicle.vehicle_id).FirstOrDefault<Vehicles_Images>();
                this.context.Vehicles.Remove(selectedVehicle);
                this.context.Vehicles_Images.Remove(selectedVehicleImage);
                this.context.SaveChanges();
                allVehicles_Click(null, null);
                populatePanel();
                CustomMessageBox.CustomMsg("Poprawnie usunięto \n wybrany pojazd!", 2000, false);
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
                warningTimer.Start();
                editWarnLabel3.Visible = true;
            }
            else if (
                !RegexD(@"^[a-zA-Z0-9]+$", editRegNum) ||
                !RegexD(@"^[a-zA-Z]+$", editVehicleColor)
            )
            {
                if (!RegexD(@"^[a-zA-Z0-9]+$", editRegNum)) ShowErrorMsg(editWarnLabel1, warningTimer);
                if (!RegexD(@"^[a-zA-Z]+$", editVehicleColor)) ShowErrorMsg(editWarnLabel2, warningTimer);
            }
            else
            {
                string regNumStr = (vLabelList[editSelecetedId].Text.Split('\n'))[1].Trim();
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
            warnLabel9.Visible = false;
        }

        private void clearVehicleBtn_Click(object sender, EventArgs e)
        {
            var quest = CustomMessageBox.CustomMsg("Czy na pewno chcesz \n usunąć wprowadzone dane?", 1500, true);
            if (quest == DialogResult.Yes)
            {
                bodyTypeComboBox.SelectedIndex = -1;
                fuelTypeComboBox.SelectedIndex = -1;
                enginePower.ClearText();
                engineCapacity.ClearText();
                regNumber.ClearText();
                vinNumber.ClearText();
                vehicleColor.ClearText();
                prodYear.ClearText();
                vehMilage.ClearText();
               // distance.ClearText();
                modelComboBox.SelectedIndex = -1;
                manufacturerComboBox.SelectedIndex = -1;
                modelComboBox.Enabled = false;
                selectedImage.Image = null;
            }
            else { }
        }

        private void addPhotoBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Wybierz zdjęcie";
                openFileDialog.Filter = "Plik JPEG (*.jpg)|*.jpg|Plik PNG (*.png)|*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImage.Image = new Bitmap(openFileDialog.FileName);
                    image = ImageToByte(openFileDialog.FileName);
                }
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e) => populatePanel();

        private void infoReturnBtn_Click(object sender, EventArgs e) => HideOtherPanels(vehiclesPanel, this.Controls);

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => populatePanel();

        private void filterManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelsLoad(filterManufacturer, filterModel);
            if (filterManufacturer.SelectedIndex == 0)
                filterModel.Enabled = false;
        }

        private void filterButton_Click(object sender, EventArgs e) => filterPanel.Visible = !filterPanel.Visible;

        private void filterAccept_Click(object sender, EventArgs e)
        {
            vehiclePages = 0;
            populatePanel();
            filterPanel.Visible = false;
            
        }

        private void filterPanel_MouseLeave(object sender, EventArgs e)
        {
            
            if (filterPanel.Visible)
            {
                var mea = this.PointToClient(MousePosition);
                if (mea.X < 590 || mea.X > 1030 || mea.Y < 120 || mea.Y > 320)
                {
                    filterPanel.Visible = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => populatePanel();
    }
}