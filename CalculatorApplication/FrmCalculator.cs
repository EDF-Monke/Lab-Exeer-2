using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class FrmCalculator : Form
    {
        // Step 8 1/2
        CalculatorClass cal;

        public FrmCalculator()
        {
            InitializeComponent();
            // Step 8 2/2
            cal = new CalculatorClass();
        }

        // Property -> Event -> Click
        private void btnEqual_Click(object sender, EventArgs e)
        {
            double num1;
            double num2;

            try
            {
                //TextBoxes to double
                num1 = Convert.ToDouble(txtBoxInput1.Text);
                num2 = Convert.ToDouble(txtBoxInput2.Text);

                double result = 0;
                Func<double, double, double> calculationMethod = null;

                //  calculation on selected operator
                switch (cbOperator.SelectedItem.ToString())
                {
                    case "+":
                        calculationMethod = cal.GetSum;
                        break;

                    case "-":
                        calculationMethod = cal.GetDifference;
                        break;

                    case "*":
                        calculationMethod = cal.GetProduct;
                        break;

                    case "/":
                        calculationMethod = cal.GetQuotient;
                        break;

                    default:
                        lblDisplayTotal.Text = "Select an operator";
                        return;
                }

                try
                {
                    // delegate to  calculation
                    result = calculationMethod(num1, num2);
                }
                catch (DivideByZeroException ex)
                {
                    lblDisplayTotal.Text = ex.Message;
                    return;
                }

                lblDisplayTotal.Text = result.ToString();
            }
            catch (FormatException)
            {
                lblDisplayTotal.Text = "Enter valid numbers";
            }
        }
    }
}
