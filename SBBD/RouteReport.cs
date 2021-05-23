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
                if (vehicleId != -1)
                {
                    var vehicle = context.Vehicles.Where(v => v.vehicle_id == vehicleId).FirstOrDefault();
                    var vehicleRoutes = context.Vehicles_Routes.Where(r => r.vehicle_id == vehicleId).ToList();
                    Drivers routeDriver;
                    int? distanceSum = 0;
                    //int days = 0;
                    int totalDays = 0;
                    PdfPTable table = new PdfPTable(5);
                    PdfPCell cell1 = new PdfPCell(new Phrase($"{vehicle.manufacturer} {vehicle.model} {vehicle.registration_num}"));
                    cell1.Colspan = 5;
                    cell1.HorizontalAlignment = 1;
                    table.AddCell(cell1);
                    PdfPCell cell2 = new PdfPCell(new Phrase("Imie i Nazwisko kierowcy"));
                    cell2.Colspan = 2;
                    cell2.HorizontalAlignment = 1;
                    table.AddCell(cell2);
                    table.AddCell("Przebyty dystans");
                    table.AddCell("Data wyjazdu");
                    table.AddCell("Data Powrotu");
                    foreach (Vehicles_Routes route in vehicleRoutes)
                    {
                        if (route.end_date != null)
                        {
                            distanceSum += route.distance;
                            routeDriver = context.Drivers.Where(d => d.driver_id == route.driver_id).FirstOrDefault();
                            table.AddCell(routeDriver.first_name);
                            table.AddCell(routeDriver.last_name);
                            table.AddCell(route.distance.ToString());
                            table.AddCell(route.start_date.ToString("dd-MM-yyyy"));
                            table.AddCell(route.end_date == null ? "w trasie" : route.end_date?.ToString("dd-MM-yyyy"));
                            //days = Convert.ToInt32(((route.end_date ?? DateTime.Now) - route.start_date).TotalDays);
                            totalDays += Convert.ToInt32(((route.end_date ?? DateTime.Now) - route.start_date).TotalDays) + 1;//days == 0 ? 1 : days;
                        }
                    }
                    PdfPCell cell3 = new PdfPCell(new Phrase("Suma dystansu"));
                    cell3.Colspan = 2;
                    table.AddCell(cell3);
                    table.AddCell(distanceSum.ToString());
                    table.AddCell("Dni w trasie");
                    table.AddCell(totalDays.ToString());
                    doc.Add(table);
                }

                doc.Close();
            }
        }
    }
}
