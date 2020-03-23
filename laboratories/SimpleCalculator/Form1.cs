using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class SimpleCalculator : Form
    {
        private char operation;
        private String firstNumber;
        public SimpleCalculator()
        {
            operation = '\0';
            InitializeComponent();
            firstNumber = this.textDisplay.Text = "0";
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            this.firstNumber = this.textDisplay.Text;
            this.textDisplay.Text = "0";
            this.operation = '+';  
        }

        private void btnSubstraction_Click(object sender, EventArgs e)
        {
            if(this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "-";
                return;
            }
            if(this.textDisplay.Text == "-")
            {
                return;
            }
            this.firstNumber = this.textDisplay.Text;
            this.textDisplay.Text = "0";
            this.operation = '-';
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            this.firstNumber = this.textDisplay.Text;
            this.textDisplay.Text = "0";
            this.operation = '*';
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            this.firstNumber = this.textDisplay.Text;
            this.textDisplay.Text = "0";
            this.operation = '/';
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            if(this.textDisplay.Text == "0")
            {
                return;
            }
            this.textDisplay.Text += "0";
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0") {
                this.textDisplay.Text = "1";
                return;
            }
            this.textDisplay.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "2";
                return;
            }
            this.textDisplay.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "3";
                return;
            }
            this.textDisplay.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "4";
                return;
            }
            this.textDisplay.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "5";
                return;
            }
            this.textDisplay.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "6";
                return;
            }
            this.textDisplay.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "7";
                return;
            }
            this.textDisplay.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "8";
                return;
            }
            this.textDisplay.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text == "0")
            {
                this.textDisplay.Text = "9";
                return;
            }
            this.textDisplay.Text += "9";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (this.textDisplay.Text.Contains("."))
            {
                return;
            }
            this.textDisplay.Text += ".";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            double x1, x2, result = 0.0;
            if(!Double.TryParse(this.firstNumber, out x1))
            {
                this.textDisplay.Text = "Failed to parse first operand";
                return;
            }
            if(!Double.TryParse(this.textDisplay.Text, out x2)){
                this.textDisplay.Text = "Failed to parse second operand";
                return;
            }
            switch (this.operation)
            {
                case '+':
                    result = x1 + x2;
                    break;
                case '-':
                    result = x1 - x2;
                    break;
                case '*':
                    result = x1 * x2;
                    break;
                case '/':
                    if(x2 == 0.0)
                    {
                        this.textDisplay.Text = "Division by 0 not allowed";
                        return;
                    }
                    result = x1 / x2;
                    break;
                default:
                    this.textDisplay.Text = "No operation specified";
                    return;

            }
            this.firstNumber = this.textDisplay.Text = result.ToString();
        }
        private void form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                    btn0_Click(sender, e);
                    break;
                case Keys.D1:
                    btn1_Click(sender, e);
                    break;
                case Keys.D2:
                    btn2_Click(sender, e);
                    break;
                case Keys.D3:
                    btn3_Click(sender, e);
                    break;
                case Keys.D4:
                    btn4_Click(sender, e);
                    break;
                case Keys.D5:
                    btn5_Click(sender, e);
                    break;
                case Keys.D6:
                    btn6_Click(sender, e);
                    break;
                case Keys.D7:
                    btn7_Click(sender, e);
                    break;
                case Keys.D8:
                    btn8_Click(sender, e);
                    break;
                case Keys.D9:
                    btn9_Click(sender, e);
                    break;
                case Keys.Subtract:
                    btnSubstraction_Click(sender, e);
                    break;
                
                case Keys.Add:
                    btnAddition_Click(sender, e);
                    break;
                case Keys.Multiply:
                    btnMultiply_Click(sender, e);
                    break;
                case Keys.Divide:
                    btnDivision_Click(sender, e);
                    break;
                case Keys.Oemplus:
                    btnSubmit_Click(sender, e);
                    break;
                case Keys.Escape:
                    btnClear_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.firstNumber = "0";
            this.textDisplay.Text = "0";
            this.operation = '\0';
        }
    }
}
