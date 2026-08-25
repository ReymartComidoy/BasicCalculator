using System;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }
        // Handles clicks for all Number buttons (0-9)
        private void btnNum_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            txtDisplay.Text += button.Text;
        }

        // Handles clicks for Operators (+, -, X, /)
        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0 && !isOperationPerformed)
            {
                btnEquals_Click(this, new EventArgs());
                operationPerformed = button.Text;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
        }

        // CE (Clear Entry): Clears only the current display number
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        // C (Clear All): Resets the calculator completely
        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // Handles Equals (=) button
        private void btnEquals_Click(object sender, EventArgs e)
        {
            double secondValue = double.Parse(txtDisplay.Text);

            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + secondValue).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - secondValue).ToString();
                    break;
                case "X":
                case "*":
                    txtDisplay.Text = (resultValue * secondValue).ToString();
                    break;
                case "/":
                    if (secondValue != 0)
                        txtDisplay.Text = (resultValue / secondValue).ToString();
                    else
                        MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }

            double.TryParse(txtDisplay.Text, out resultValue);
            operationPerformed = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
