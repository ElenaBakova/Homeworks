﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
        private Font font = new Font("Arial", 28);

        private void ClockFormLoad(object sender, EventArgs e)
        {
            ClockBox.Paint += new PaintEventHandler(ClockPaint);
            //Controls.Add(ClockBox);
        }

        private void ClockPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawEllipse(new Pen(Brushes.Black, 10), 40, 30, clockWidth, clockHeight);
            graphics.DrawEllipse(new Pen(Brushes.Black, 5), 287, 277, 5, 5);

            graphics.TranslateTransform(263, 42);
            for (int i = 1; i <= 12; i++)
            {
                graphics.RotateTransform(30 * i);
                graphics.TranslateTransform(107, -30);
                graphics.RotateTransform(-30 * i);
                graphics.DrawString(i.ToString(), font, Brushes.Black, 0, 0);
            }
        }
    }
}
