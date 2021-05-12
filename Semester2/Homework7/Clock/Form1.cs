using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
        }

        private int clockWidth = 500;
        private int clockHeight = 500;
        //private PictureBox ClockBox = new PictureBox();
        private Font font = new Font("Arial", 14);

        private void ClockForm_Load(object sender, EventArgs e)
        {
            ClockBox.Paint += new PaintEventHandler(ClockPaint);

            //Controls.Add(ClockBox);
        }

        private void ClockPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawEllipse(new Pen(Brushes.Black, 10), 0, 0, clockWidth, clockHeight);
        }
    }
}
