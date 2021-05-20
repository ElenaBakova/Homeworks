using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// Clock form class
    /// </summary>
    public partial class ClockForm : Form
    {
        /// <summary>
        /// Initializes components, sets timer
        /// </summary>
        public ClockForm()
        {
            InitializeComponent();
            timer.Interval = 500;
            timer.Tick += TimerTick;
            timer.Start();
        }

        private const int clockWidth = 500;
        private const int clockHeight = 500;
        private readonly Point center = new (290, 280);
        private readonly Point clockFaceStartPoint = new (265, 45);
        private readonly Rectangle clockFaceFrame = new (40, 30, clockWidth, clockHeight);
        private const int secondHandLength = 165;
        private const int minuteHandLength = 140;
        private const int hourHandLength = 110;
        private readonly Font font = new Font("Arial", 28);
        private Graphics graphics;
        private Bitmap bitmap;

        private void ClockFormLoad(object sender, EventArgs e)
            => ClockBox.Paint += new PaintEventHandler(ClockPaint);

        /// <summary>
        /// Draws clock face
        /// </summary>
        private void ClockPaint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            graphics.DrawEllipse(new Pen(Brushes.Black, 10), clockFaceFrame);
            graphics.DrawEllipse(new Pen(Brushes.Black, 10), center.X - 3, center.Y - 3, 10, 10);

            graphics.TranslateTransform(clockFaceStartPoint.X, clockFaceStartPoint.Y);
            for (int i = 1; i <= 12; i++)
            {
                graphics.RotateTransform(30 * i);
                graphics.TranslateTransform(107, -30);
                graphics.RotateTransform(-30 * i);
                graphics.DrawString(i.ToString(), font, Brushes.Black, 0, 0);
            }
        }

        /// <summary>
        /// Draw clock hands
        /// </summary>
        private void TimerTick(object sender, EventArgs e)
        {
            bitmap = new Bitmap(clockWidth, clockHeight);
            graphics = Graphics.FromImage(bitmap);
            DateTime time = DateTime.Now;

            Point handEndPoint = MinuteSecondHandCoordinates(time.Second, secondHandLength);
            graphics.DrawLine(new Pen(Color.Red, 5), center, handEndPoint);

            handEndPoint = MinuteSecondHandCoordinates(time.Minute, minuteHandLength);
            graphics.DrawLine(new Pen(Color.Black, 7), center, handEndPoint);

            handEndPoint = HourHandCoordinates(time.Hour % 12, time.Minute, hourHandLength);
            graphics.DrawLine(new Pen(Color.Gray, 10), center, handEndPoint);

            ClockBox.Image = bitmap;
        }

        /// <summary>
        /// Counts minute or second hand end point coordinate
        /// </summary>
        private Point MinuteSecondHandCoordinates(int time, int handLength)
            => CountHandCoordinates(time * 6, handLength);

        /// <summary>
        /// Counts hour hand end point coordinate
        /// </summary>
        private Point HourHandCoordinates(int hour, int minute, int handLength)
            => CountHandCoordinates((int)((hour * 30) + (minute * 0.5)), handLength);

        private Point CountHandCoordinates(int temp, int handLength)
        {
            var coordinates = new Point();
            if (temp >= 0 && temp <= 180)
            {
                coordinates.X = center.X + (int)(handLength * Math.Sin(Math.PI * temp / 180));
                coordinates.Y = center.Y - (int)(handLength * Math.Cos(Math.PI * temp / 180));
            }
            else
            {
                coordinates.X = center.X - (int)(handLength * (-Math.Sin(Math.PI * temp / 180)));
                coordinates.Y = center.Y - (int)(handLength * Math.Cos(Math.PI * temp / 180));
            }
            return coordinates;
        }
    }
}
