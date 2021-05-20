using System;
using System.Windows.Forms;

namespace ProgressIndicator
{
    /// <summary>
    /// Progress indicator class
    /// </summary>
    public partial class ProgressIndicatorForm : Form
    {
        /// <summary>
        /// Initializes all components
        /// </summary>
        public ProgressIndicatorForm()
        {
            InitializeComponent();
            textBox.Hide();
        }

        /// <summary>
        /// Button click handler
        /// </summary>
        private void ButtonClick(object sender, EventArgs e)
        {
            if (progressBar.Value == 100)
            {
                Close();
            }

            timer.Interval = 500;
            timer.Tick += new EventHandler(timerTick);
            controlButton.Hide();
            textBox.Show();
            textBox.Text = "Processing...";
            timer.Start();
        }
        
        /// <summary>
        /// Performs timer tick
        /// </summary>
        private void timerTick(object sender, EventArgs e)
        {
            if (progressBar.Value == 100)
            {
                textBox.Hide();
                controlButton.Show();
                controlButton.Text = "Close";
                return;
            }

            progressBar.PerformStep();
        }
    }
}
