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


namespace SBBD
{
    public class NoFocusTrackBar : System.Windows.Forms.TrackBar
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
                this.Cursor = Cursors.Hand;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                _isHovering = false;
                this.Cursor = Cursors.Default;
                Invalidate();
            };
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.Width = 140;
            this.Height = 30;
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
                this.Cursor = Cursors.Hand;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                _isHovering = false;
                this.Cursor = Cursors.Default;
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
}
