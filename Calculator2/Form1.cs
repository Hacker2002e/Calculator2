using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

          private string CurrentNumber = "0";

        private string OperationNumber = "0";

        private bool IsCurrentNumberShown = true;

        // 0 - nothing/equals, 1 - add, 2 - subtract, 3 - multiply, 4 - divide,
        // 5 - power, 6 - modulo
        private int CurrentOperation = 0;
        private void EnterNumber(string ValueToAdd)
        {
            if (IsCurrentNumberShown)
            {
                if (CurrentNumber == "0")
                {
                    CurrentNumber = ValueToAdd;
                }
                else
                {
                    CurrentNumber += ValueToAdd;
                }
                TextDisplay.Text = CurrentNumber;
            }
            else
            {
                if (OperationNumber == "0")
                {
                    OperationNumber = ValueToAdd;
                }
                else
                {
                    OperationNumber += ValueToAdd;
                }
                TextDisplay.Text = OperationNumber;
            }
        }

        private void NumberOperation(int NextOperation)
        {
            IsCurrentNumberShown = false;
            if (CurrentOperation != 0)
            {
                switch (CurrentOperation)
                {
                    case 1:
                        CurrentNumber = "" + (double.Parse(CurrentNumber) + double.Parse(OperationNumber));                     
                        break;
                    case 2:
                        CurrentNumber = "" + (double.Parse(CurrentNumber) - double.Parse(OperationNumber));
                        break;
                    case 3:
                        CurrentNumber = "" + (double.Parse(CurrentNumber) * double.Parse(OperationNumber));
                        break;
                    case 4:
                        CurrentNumber = "" + (double.Parse(CurrentNumber) / double.Parse(OperationNumber));
                        break;
                    case 5:
                        CurrentNumber = "" + Math.Pow(double.Parse(CurrentNumber), double.Parse(OperationNumber));
                        break;
                    case 6:
                        CurrentNumber = "" + (double.Parse(CurrentNumber) % double.Parse(OperationNumber));
                        break;
                }
            }

            OperationNumber = "0";
            CurrentOperation = NextOperation;
            if(NextOperation == 0)
            {
                IsCurrentNumberShown = true;
                TextDisplay.Text = CurrentNumber;
                return;
            }
            TextDisplay.Text = OperationNumber;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            EnterNumber("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            EnterNumber("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            EnterNumber("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            EnterNumber("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            EnterNumber("5");
        }
        

        private void btn6_Click(object sender, EventArgs e)
        {
            EnterNumber("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            EnterNumber("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            EnterNumber("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            EnterNumber("9");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (IsCurrentNumberShown)
            {
                if (CurrentNumber.Length == 1)
                {
                    CurrentNumber = "0";
                }
                else
                {
                    CurrentNumber = CurrentNumber.Substring(0, CurrentNumber.Length - 1);
                }
                TextDisplay.Text = CurrentNumber;
            }
            else
            {
                if (OperationNumber.Length == 1)
                {
                    OperationNumber = "0";
                }
                else
                {
                    OperationNumber = OperationNumber.Substring(0, OperationNumber.Length - 1);
                }
                TextDisplay.Text = OperationNumber;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (IsCurrentNumberShown)
            {
                if (CurrentNumber == "0")
                {
                    return;
                }
                CurrentNumber += "0";
                TextDisplay.Text = CurrentNumber;
            }
            else
            {
                if (OperationNumber == "0")
                {
                    return;
                }
                OperationNumber += "0";
                TextDisplay.Text = OperationNumber;
            }
        }

        private void btn_period_Click(object sender, EventArgs e)
        {
            if (IsCurrentNumberShown)
            {
                if (!CurrentNumber.Contains("."))
                {
                    CurrentNumber += ".";
                }

                TextDisplay.Text = CurrentNumber;
            }
            else
            {
                if (!OperationNumber.Contains("."))
                {
                    OperationNumber += ".";
                }

                TextDisplay.Text = OperationNumber;
            }
        }

       

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            NumberOperation(3);
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            NumberOperation(4);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            NumberOperation(1);
        }

        private void btn_subtract_Click(object sender, EventArgs e)
        {
            NumberOperation(2);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            CurrentNumber = "0";
            OperationNumber = "0";
            CurrentOperation = 0;
            IsCurrentNumberShown = true;
            TextDisplay.Text = CurrentNumber;
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (TextDisplay.Text.Contains("-"))
            {

                TextDisplay.Text = TextDisplay.Text.Remove(0, 1);
            }
               else
            {
                TextDisplay.Text = "-" + TextDisplay.Text;
            }
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            NumberOperation(0);
        }
    }
}
