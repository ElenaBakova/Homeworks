using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressIndicator
{
    public partial class ProgressIndicatorForm : Form
    {
        public ProgressIndicatorForm()
        {
            InitializeComponent();
        }

        private void startButtonClick(object sender, EventArgs e)
        {
            if (progressBar.Value == 100)
            {
                Close();
            }

            timer.Interval = 500;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timerTick);
            controlButton.Text = "Processing...";
            timer.Start();
        }
        
        private void timerTick(object sender, EventArgs e)
        {
            if (progressBar.Value == 100)
            {
                controlButton.Text = "Close";
                return;
            }
            progressBar.PerformStep();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
