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

        CalculatingClass calculator = new();

        /// <summary>
        /// Number button click handler 
        /// </summary>
        private void NumberButtonClick(object sender, EventArgs e)
        {
            richTextBox1.Text += (sender as Button).Text;
            calculator.NewNumber((sender as Button).Text);
        }

        /// <summary>
        /// CE button click handler 
        /// </summary>
        private void ClearEntryButtonClick(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            calculator.ClearEntry();
        }

        /// <summary>
        /// Operation button click handler
        /// </summary>
        private void OperationButtonClick(object sender, EventArgs e)
        {
            calculator.NewOperation((sender as Button).Text);
            if (calculator.Value != null)
            {
                richTextBox1.Text = calculator.Value.ToString();
            }
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
