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
using System.Windows.Forms.VisualStyles;

namespace SBBD
{
    public class MoveBar : PictureBox
    {
        private int moveX, moveY;
        private bool moving = false;
        private Form _targetForm;
        private int _xOffset;
        public Form TargetForm
        {
            get => _targetForm;
            set
            {
                _targetForm = value;
                Invalidate();
            }
        }

        public int XOffset
        {
            get => _xOffset;
            set
            {
                _xOffset = value;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (moving)
            {
                _targetForm.SetDesktopLocation(MousePosition.X - _xOffset - moveX, MousePosition.Y - moveY);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            moving = false;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            moving = true;
            moveX = e.X;
            moveY = e.Y;
        }


    }

    public class NoFocusTrackBar : TrackBar
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private static int MakeParam(int loWord, int hiWord)
        {
            return (hiWord << 16) | (loWord & 0xffff);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SendMessage(this.Handle, 0x0128, MakeParam(1, 0x1), 0);
        }
    }

    public class CustomButton : Button
    {
        private Image _imageActive;
        private Image _imageInactive;

        private bool _isHovering;
        private Color _selectedColor;
        private bool _selectedMenuItem;

        public CustomButton()
        {
            MouseEnter += (sender, e) =>
            {
                _isHovering = true;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                _isHovering = false;
                Invalidate();
            };
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.Width = 140;
            this.Height = 30;
            this.Cursor = Cursors.Hand;
            this.BackColor = Color.Transparent;
        }

        public Image ImageActive
        {
            get => _imageActive;
            set
            {
                _imageActive = value;
                Invalidate();
            }
        }

        public Image ImageInactive
        {
            get => _imageInactive;
            set
            {
                _imageInactive = value;
                Invalidate();
            }
        }

        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            if (_imageActive != null && _imageInactive != null)
            {
                if (!_selectedMenuItem)
                {
                    TextureBrush tBrush = new TextureBrush(_isHovering ? _imageActive : _imageInactive);
                    e.Graphics.FillRectangle(tBrush, Rect);
                    tBrush.Dispose();
                }
                else
                {
                    TextureBrush tBrush = new TextureBrush(_imageInactive);
                    Brush brush = new SolidBrush(_selectedColor);
                    e.Graphics.FillRectangle(brush, Rect);
                    e.Graphics.FillRectangle(tBrush, Rect);
                }
            }
        }
    }

    public class RoundedButton : Button
    {
        private int _roundRadius = 30;
        private Color _buttonColor = Color.FromArgb(0, 110, 255);
        private Color _hoverColor = Color.FromArgb(72, 150, 253);
        private bool _isHovering;

        public RoundedButton()
        {
            MouseEnter += (sender, e) =>
            {
                _isHovering = true;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                _isHovering = false;
                Invalidate();
            };
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.Width = 140;
            this.Height = 30;
            this.ForeColor = Color.White;
            this.Font = new Font(this.Font.FontFamily, 10, FontStyle.Bold);
            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.Hand;
        }

        GraphicsPath GetRoundPath(RectangleF rectangle, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            GraphPath.AddLine(rectangle.X + r2, rectangle.Y, rectangle.Width - r2, rectangle.Y);
            GraphPath.AddArc(rectangle.X + rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            GraphPath.AddLine(rectangle.Width, rectangle.Y + r2, rectangle.Width, rectangle.Height - r2);
            GraphPath.AddArc(rectangle.X + rectangle.Width - radius, rectangle.Y + rectangle.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(rectangle.Width - r2, rectangle.Height, rectangle.X + r2, rectangle.Height);
            GraphPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(rectangle.X, rectangle.Height - r2, rectangle.X, rectangle.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, _roundRadius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                using (SolidBrush solidBrush = new SolidBrush(_isHovering ? _hoverColor : _buttonColor))
                {
                    e.Graphics.FillPath(solidBrush, GraphPath);
                    SizeF stringSize = e.Graphics.MeasureString(Text, Font);
                    Brush textColor = new SolidBrush(ForeColor);
                    e.Graphics.DrawString(Text, Font, textColor, (Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);
                    textColor.Dispose();
                }
            }
        }

        public int RoundRadius
        {
            get => _roundRadius;
            set
            {
                _roundRadius = value;
                Invalidate();
            }
        }

        public Color ButtonColor
        {
            get => _buttonColor;
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        public Color HoverColor
        {
            get => _hoverColor;
            set
            {
                _hoverColor = value;
                Invalidate();
            }
        }
    }
    public class CustomTextBox : TextBox
    {
        private string _placeHolder;
        private bool _isPassword = false;

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.Text == _placeHolder)
            {
                if (_isPassword)
                {
                    this.PasswordChar = '*';
                    this.ForeColor = Color.White;
                }
                this.Text = "";
                this.ForeColor = Color.White;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.Text == "")
            {
                if (_isPassword)
                {
                    this.PasswordChar = '\0';
                    this.ForeColor = Color.FromArgb(77, 77, 77);
                }
                this.Text = _placeHolder;
                this.ForeColor = Color.FromArgb(77, 77, 77);
            }

        }

        public void ClearText()
        {
            this.Text = _placeHolder;
            this.ForeColor = Color.FromArgb(77, 77, 77);
        }

        public string PlaceHolder
        {
            get => _placeHolder;
            set
            {
                _placeHolder = value;
                Invalidate();
            }
        }

        public bool IsPassword
        {
            get => _isPassword;
            set
            {
                _isPassword = value;
                Invalidate();
            }
        }
    }

    public static class CustomMessageBox
    {
        public static DialogResult CustomMsg(string text, int miliseconds, bool YesNo)
        {
            DialogResult dialogResult = DialogResult.No;
            if (!YesNo)
            {
                using (CustomMessageBoxForm msg = new CustomMessageBoxForm(text, miliseconds))
                {
                    dialogResult = msg.ShowDialog();
                }
            }
            else
            {
                using (CustomMessageBoxForm msg = new CustomMessageBoxForm(text, YesNo))
                {
                    dialogResult = msg.ShowDialog();
                }
            }
            return dialogResult;
        }

        public static DialogResult CustomMsg(string text, float fontSize, bool YesNo)
        {
            DialogResult dialogResult = DialogResult.No;
            using(CustomMessageBoxForm msg = new CustomMessageBoxForm(text, fontSize, YesNo))
            {
                dialogResult = msg.ShowDialog();
            }
            return dialogResult;
        }
    }

    public class CustomDTPicker : DateTimePicker
    {

        private Color _backDisabledColor;
        //private Color _foreColor;
        /*private Color _backColor;

        const int WM_ERASEBKGND = 0x14;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ERASEBKGND)
            {
                using (var g = Graphics.FromHdc(m.WParam))
                {
                    using (var b = new SolidBrush(_backColor))
                    {
                        g.FillRectangle(b, ClientRectangle);
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }

        public Color BakcColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                Invalidate();
            }
        }*/
        public CustomDTPicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            //The dropDownRectangle defines position and size of dropdownbutton block, 
            //the width is fixed to 17 and height to 16. 
            //The dropdownbutton is aligned to right
            Rectangle dropDownRectangle =
               new Rectangle(ClientRectangle.Width - 17, 0, 17, 20);
            Brush bkgBrush;
            ComboBoxState visualState;

            //When the control is enabled the brush is set to Backcolor, 
            //otherwise to color stored in _backDisabledColor
            if (this.Enabled)
            {
                bkgBrush = new SolidBrush(this.BackColor);
                visualState = ComboBoxState.Normal;
                
            }
            else
            {
                bkgBrush = new SolidBrush(this._backDisabledColor);
                visualState = ComboBoxState.Disabled;
            }

            /*VisualStyleRenderer vsr = new VisualStyleRenderer("EDIT", 1, 1);
            vsr.DrawBackground(e.Graphics, controlRectangle);
            vsr.SetParameters("COMBOBOX", 7, 1);
            vsr.DrawBackground(e.Graphics, arrowRectangle);*/
            

            // Painting...in action

            //Filling the background
            g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            Brush foreColorBrush = new SolidBrush(this.ForeColor);
            //Drawing the datetime text
            g.DrawString(this.Text, this.Font, foreColorBrush, 0, 2);

            //Drawing the dropdownbutton using ComboBoxRenderer
            ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, visualState);

            g.Dispose();
            bkgBrush.Dispose();
        }
        [Browsable(true)]
        public override Color BackColor
        {
            get => base.BackColor;
            set 
            { 
                base.BackColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"),
        Description("The background color of the component when disabled")]
        [Browsable(true)]
        public Color BackDisabledColor
        {
            get => _backDisabledColor;
            set 
            { 
                _backDisabledColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set 
            { 
                base.ForeColor = value;
                Invalidate();
            }
        }
    }
}
