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
    public partial class EditDriver : Form
    {

        PrivateFontCollection pfc;
        int selectedDriverId;
        bool editing = false;
        VFEntities context;
        public static Drivers outputDriver { get; set; }

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
            driversLicenceDate.Format = DateTimePickerFormat.Custom;
            medicalExaminationDate.Format = DateTimePickerFormat.Custom;
        }



        public EditDriver(int driverId)
        {
            InitializeComponent();
            context = new VFEntities();
            context.Drivers.Load();
            selectedDriverId = driverId;
            driverAvailable.Visible = true;
            editing = true;
            driverOK.Enabled = true;
            addEditDriversPanel.BackgroundImage = Resources.editDriverBG;
            fillEditDriver();
        }

        public EditDriver()
        {
            InitializeComponent();
            firstNameDriver.Enabled = true;
            lastNameDriver.Enabled = true;
            licenceNum.Enabled = true;
            medicalExaminationDate.Value = DateTime.Now;
            driversLicenceDate.Value = DateTime.Now;
        }

        private void fillEditDriver()
        {
            Drivers driver = context.Drivers.Where(d => d.driver_id == selectedDriverId).FirstOrDefault();
            firstNameDriver.Text = driver.first_name;
            lastNameDriver.Text = driver.last_name;
            licenceNum.Text = driver.drivers_licence_num;
            medicalExaminationDate.Value = driver.med_examination_date;
            driversLicenceDate.Value = driver.drivers_licence_exp_date;
            driverAvailable.SelectedIndex = driver.available ? 0 : 1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if(this.DialogResult == DialogResult.OK)
            {
                if(editing)
                {
                    outputDriver = new Drivers
                    {
                        driver_id = selectedDriverId,
                        med_examination_date = medicalExaminationDate.Value,
                        drivers_licence_exp_date = driversLicenceDate.Value,
                        available = driverAvailable.SelectedIndex == 0 ? true : false 
                    };
                }
                else
                {
                    outputDriver = new Drivers
                    {
                        first_name = firstNameDriver.Text,
                        last_name = lastNameDriver.Text,
                        drivers_licence_num = licenceNum.Text,
                        med_examination_date = medicalExaminationDate.Value,
                        drivers_licence_exp_date = driversLicenceDate.Value,
                        available = true
                    };
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if(!editing)
            {
                driverOK.Enabled = firstNameDriver.Text != "" && firstNameDriver.Text != firstNameDriver.PlaceHolder &&
                    lastNameDriver.Text != "" && lastNameDriver.Text != lastNameDriver.PlaceHolder &&
                    licenceNum.Text != "" && licenceNum.Text != licenceNum.PlaceHolder;
            }
        }
    }
}
