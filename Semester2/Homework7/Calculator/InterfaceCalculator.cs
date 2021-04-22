using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Win Forms App calculator
    /// </summary>
    public partial class InterfaceCalculator : Form
    {
        public InterfaceCalculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Number button click handler 
        /// </summary>
        private void NumberButtonClick(object sender, EventArgs e)
        {
            richTextBox1.Text += (sender as Button).Text;
        }

        /// <summary>
        /// CE button click handler 
        /// </summary>
        private void ClearEntryButtonClick(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        /// <summary>
        /// Operation button click handler 
        /// </summary>
        private void OperationButtonClick(object sender, EventArgs e)
        {
            richTextBox1.Text += $" {(sender as Button).Text} ";
        }

        /// <summary>
        /// Equal button click handler 
        /// </summary>
        private void EqualButtonClick(object sender, EventArgs e)
        {

        }
    }
}
