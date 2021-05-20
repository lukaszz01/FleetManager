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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SBBD
{
    public partial class RouteReport : Form
    {
        PrivateFontCollection pfc;
        VFEntities context;
        bool oneVeicle = true;
        int selectedVehicleId;

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
                c.Font = new System.Drawing.Font(pfc.Families[0], c.Font.Size, FontStyle.Bold);
                foreach (Control c2 in c.Controls)
                {
                    c2.Font = new System.Drawing.Font(pfc.Families[0], c2.Font.Size, FontStyle.Bold);
                }
            }
            reportStartDate.Format = DateTimePickerFormat.Custom;
            reportEndDate.Format = DateTimePickerFormat.Custom;
        }

        public RouteReport()
        {
            InitializeComponent();
            oneVeicle = false;
            context = new VFEntities();
            context.Vehicles.Load();
        }

        public RouteReport(int vehicleId)
        {
            InitializeComponent();
            selectedVehicleId = vehicleId;
            context = new VFEntities();
            context.Vehicles.Load();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if(countRoutes(oneVeicle ? selectedVehicleId : -1, reportStartDate.Value, reportEndDate.Value) == 0 && this.DialogResult != DialogResult.Cancel)
            {
                e.Cancel = true;
                CustomMessageBox.CustomMsg("Nie ma tras w tym przedziale czasu", 2000, false);
            }
            else if(this.DialogResult != DialogResult.Cancel)
            {
                generateReport(oneVeicle ? selectedVehicleId : -1, reportStartDate.Value, reportEndDate.Value);
                
            }

        }

        private int countRoutes(int vehicleId, DateTime startDate, DateTime endDate)
        {
            List<Vehicles_Routes> routes = vehicleId != -1
                ? context.Vehicles_Routes.Where(r => r.vehicle_id == vehicleId && r.start_date > startDate && r.end_date < endDate).ToList()
                : context.Vehicles_Routes.Where(r => r.start_date > startDate && r.end_date < endDate).ToList();
            return routes.Count();
        }

        private void generateReport(int vehicleId, DateTime startDate, DateTime endDate)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();
                //tutaj kod na tabele
                
                doc.Close();
            }
        }
    }
}
