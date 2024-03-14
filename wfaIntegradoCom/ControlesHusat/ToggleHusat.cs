using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaIntegradoCom.Funciones
{
    internal class ToggleHusat : CheckBox
    {
        //Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;
        private int toggleSize = 16; // Tamaño predeterminado del círculo de toggle
        private Color onBorderColor = Color.MediumSlateBlue;
        private Color offBorderColor = Color.Gray;
        private int borderThickness = 2;

        //Properties
        [Category("Propiedad Personalizada")]
        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        [Category("Propiedad Personalizada")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }

        [Category("Propiedad Personalizada")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        [Category("Propiedad Personalizada")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { }
        }

        [Category("Propiedad Personalizada")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        [Category("Propiedad Personalizada")]
        [DefaultValue(16)]
        public int ToggleSize
        {
            get { return toggleSize; }
            set
            {
                toggleSize = value;
                this.Invalidate();
            }
        }

        [Category("Propiedad Personalizada")]
        public Color OnBorderColor
        {
            get { return onBorderColor; }
            set
            {
                onBorderColor = value;
                this.Invalidate();
            }
        }

        [Category("Propiedad Personalizada")]
        public Color OffBorderColor
        {
            get { return offBorderColor; }
            set
            {
                offBorderColor = value;
                this.Invalidate();
            }
        }

        [Category("Propiedad Personalizada")]
        [DefaultValue(2)] // Grosor predeterminado del borde
        public int BorderThickness
        {
            get { return borderThickness; }
            set
            {
                borderThickness = value;
                this.Invalidate();
            }
        }

        //Constructor
        public ToggleHusat()
        {
            this.MinimumSize = new Size(45, 22);
        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.ToggleSize;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Establecer el color de fondo deseado
            Color backgroundColor = Color.White; // Puedes cambiar este color al que desees

            // Dibujar el fondo con el color deseado
            pevent.Graphics.Clear(backgroundColor);
            if (this.Checked) //ON
            {
                // Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(onBackColor, BorderThickness), GetFigurePath());

                // Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                    new Rectangle(this.Width - this.Height + 1, (this.Height - toggleSize) / 2, toggleSize, toggleSize));

                // Draw the border for the toggle
                pevent.Graphics.DrawEllipse(new Pen(onBorderColor, BorderThickness),
                    new Rectangle(this.Width - this.Height + 1, (this.Height - toggleSize) / 2, toggleSize, toggleSize));

                // Draw the border for the entire control
                pevent.Graphics.DrawPath(new Pen(onBorderColor, BorderThickness), GetFigurePath());
            }
            else //OFF
            {
                // Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(offBackColor, BorderThickness), GetFigurePath());

                // Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, (this.Height - toggleSize) / 2, toggleSize, toggleSize));

                // Draw the border for the toggle
                pevent.Graphics.DrawEllipse(new Pen(offBorderColor, BorderThickness),
                    new Rectangle(2, (this.Height - toggleSize) / 2, toggleSize, toggleSize));

                // Draw the border for the entire control
                pevent.Graphics.DrawPath(new Pen(offBorderColor, BorderThickness), GetFigurePath());
            }
        }
    }

}

