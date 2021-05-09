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
            if (calculator.Error)
            {
                calculatorEntryBox.Text = calculator.OldExpression;
            }
            calculatorEntryBox.Text += (sender as Button).Text;
            calculator.NewNumber((sender as Button).Text);
        }

        /// <summary>
        /// CE button click handler 
        /// </summary>
        private void ClearEntryButtonClick(object sender, EventArgs e)
        {
            calculatorEntryBox.Text = "";
            calculator.ClearEntry();
        }

        /// <summary>
        /// Operation button click handler
        /// </summary>
        private void OperationButtonClick(object sender, EventArgs e)
        {
            try
            {
                calculator.NewOperation((sender as Button).Text);
            }
            catch (DivideByZeroException)
            {
                calculatorEntryBox.Text = "Error";
                return;
            }
            catch (MissingOperandException)
            {
                calculatorEntryBox.Text = "Invalid expression";
                Environment.Exit(1);
            }

            if (calculator.Value != null)
            {
                calculatorEntryBox.Text = calculator.Value.ToString();
            }
            calculatorEntryBox.Text += $" {(sender as Button).Text} ";
        }

        /// <summary>
        /// Equal button click handler 
        /// </summary>
        private void EqualButtonClick(object sender, EventArgs e)
        {
            try
            {
                calculator.EqualSign();
                calculatorEntryBox.Text = (calculator.Value ?? 0).ToString();
            }
            catch (DivideByZeroException)
            {
                calculatorEntryBox.Text = "Error";
                calculator.Error = true;
            }
        }
    }
}
