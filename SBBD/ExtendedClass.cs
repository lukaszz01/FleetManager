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
using System.Security.Cryptography;

namespace SBBD
{
    public class ExtendedClass
    {
        static Image infoimg = Image.FromFile(@"Resources\info.png");
        static Image editimg = Image.FromFile(@"Resources\edit.png");
        static Image deleteimg = Image.FromFile(@"Resources\delete.png");
        static Image checkVehicle = Image.FromFile(@"Resources\vehicleCheck1.png");
        static Image uncheckVehicle = Image.FromFile(@"Resources\vehicleUncheck1.png");
        static Vehicles_Images vehImage;
        //Main Window - error msg
        public static void ShowErrorMsg(Label warnLabel, Timer warnTimer)
        {
            warnLabel.Visible = true;
            warnTimer.Start();
        }
        // rejestracja - niepoprawne hasło
        public static void ShowMsg(int warnNum, Label warnLabel, Timer warnTimer)
        {
            switch (warnNum)
            {
                case 0:
                    warnLabel.Text = "Hasło niepoprawne!";
                    break;
                case 1:
                    warnLabel.Text = "Wprowadzone hasła różnią się!";
                    break;
                case 2:
                    warnLabel.Text = "Hasło za krótkie!";
                    break;
            }
            warnLabel.Visible = true;
            warnTimer.Start();
        }
        //Main Window - hide panels
        public static void HideOtherPanels(Panel panel, Control.ControlCollection Controls)
        {
            
            foreach (Control control in Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                }
            }
            panel.Visible = true;
            
        }
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static bool RegexD(string reg, TextBox textbox)
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
        public static bool IsEmpty(TextBox textBox, string placeholder)
        {
            return textBox.Text == "" || textBox.Text == placeholder;
        }
        public static bool IsEmpty(TextBox textBox)
        {
            return textBox.Text == "";
        }
        public static bool IsEmpty(ComboBox comboBox)
        {
            return comboBox.Text == "";
        }
        public static Bitmap ByteToImage(byte[] image)
        {
            MemoryStream mStream = new MemoryStream();
            mStream.Write(image, 0, Convert.ToInt32(image.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        public static byte[] ImageToByte(string fileName)
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
        public static void ShowVehicleTile(PictureBox pictureBox, Label label, Vehicles vehicle, TrackBar trackbar, VFEntities context, CheckBox checkBox)
        {
            vehImage = context.Vehicles_Images.Where(v => v.vehicle_id == vehicle.vehicle_id).FirstOrDefault<Vehicles_Images>();
            Bitmap bm = new Bitmap(310, 174);
            Bitmap bm2 = ByteToImage(vehImage.vehicle_image);
            
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(bm2, 0, 0, 310, 174);
            }
            //var trackbar = context.Users.Select(x => x.darken).FirstOrDefault();
            Rectangle r = new Rectangle(0, 0, bm.Width, bm.Height);
            int alpha = trackbar.Value;
            using (Graphics g = Graphics.FromImage(bm))

            {
                using (Brush brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
                {
                    g.FillRectangle(brush, r);
                }
                if (checkBox.Checked)
                {
                    checkBox.Text = "Ukryj niedostępne auta";
                    if (!vehicle.available)
                    {
                        using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
                        {
                            g.FillRectangle(brush, r);
                        }
                    }
                }
                else
                {
                    checkBox.Text = "Pokaż niedostępne auta";
                }
            }

            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(deleteimg, 275, 139, 20, 20);
                g.DrawImage(infoimg, 240, 139, 20, 20);
                g.DrawImage(editimg, 205, 139, 20, 20);
                if (vehicle.available == true)
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
            
        }
        public static void AppExit(string message)
        {
            switch (CustomMessageBox.CustomMsg(message, 1500, true))
            {
                case DialogResult.Yes:
                    CustomMessageBox.CustomMsg("Zamykanie aplikacji...", 1500, false);
                    Application.Exit();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        public static void HidePassword(CustomTextBox pswordTextbox, Button button)
        {
            if (pswordTextbox.Text == pswordTextbox.PlaceHolder)
            {
                pswordTextbox.PasswordChar = '\0';
            }
            else
            {
                pswordTextbox.PasswordChar = '*';
            }
            button.BackgroundImage = Properties.Resources.hidePassword;
        }
        public static void ShowPassword(CustomTextBox pswordTextbox, Button button)
        {
            pswordTextbox.PasswordChar = '\0';
            button.BackgroundImage = Properties.Resources.showPassword;
        }
    }
}
