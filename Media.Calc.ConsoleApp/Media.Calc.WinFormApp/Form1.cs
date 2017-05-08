using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Media.Calc.Core;
using Media.Calc.Core.Common;

namespace Media.Calc.WinFormApp
{
    public partial class Form1 : Form
    {
        private readonly CommandInvoker _invoker = new CommandInvoker();
        private readonly List<Number> _numbers = new List<Number>();
        private readonly List<Number> _bracketNumbers = new List<Number>();
        private readonly ResultReceiver _result = new ResultReceiver();
        private int _bracketCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            displayTxt.Text += Constants.One;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Two;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Three;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Four;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Five;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Six;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Seven;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Eight;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Nine;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            displayTxt.Text += Constants.Zero;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            expressionLbl.Text += String.IsNullOrEmpty(displayTxt.Text) ? Constants.Add : displayTxt.Text + Constants.Add;
            var number = new Number
            {
                EnteredNumber = String.IsNullOrEmpty(displayTxt.Text) ? 0 : Convert.ToDouble(displayTxt.Text),
                IsCalculated = false
            };
            AddCommand addCommand;
            //Deferred execution
            if (_bracketCount == 0 || _bracketCount % 2 == 0)
            {
                _numbers.Add(number);
                addCommand = new AddCommand(_result, _numbers);
                //Calculating
                _invoker.CalculatingOperations();
            }
            else if (_bracketCount > 0 && _bracketCount % 2 == 0)
            {
                _bracketNumbers.Add(number);
                addCommand = new AddCommand(_result, _bracketNumbers);
                _invoker.CalculatingOperations();
            }
            else
            {
                _bracketNumbers.Add(number);
                addCommand = new AddCommand(_result, _bracketNumbers);
            }
            //Adding current operation into sequence
            _invoker.IncludeOperations(addCommand);
            displayTxt.Clear();
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            expressionLbl.Text += String.IsNullOrEmpty(displayTxt.Text) ? Constants.Subtract : displayTxt.Text + Constants.Subtract;
            var number = new Number
            {
                EnteredNumber = String.IsNullOrEmpty(displayTxt.Text) ? 0 : Convert.ToDouble(displayTxt.Text),
                IsCalculated = false
            };
            SubtractCommand subCommand;
            //Deferred execution
            if (_bracketCount == 0 || _bracketCount % 2 == 0)
            {
                _numbers.Add(number);
                subCommand = new SubtractCommand(_result, _numbers);
                //Calculating
                _invoker.CalculatingOperations();
            }
            else if (_bracketCount > 0 && _bracketCount % 2 == 0)
            {
                _bracketNumbers.Add(number);
                subCommand = new SubtractCommand(_result, _bracketNumbers);
                _invoker.CalculatingOperations();
            }
            else
            {
                _bracketNumbers.Add(number);
                subCommand = new SubtractCommand(_result, _bracketNumbers);
            }
            //Adding current operation into sequence
            _invoker.IncludeOperations(subCommand);
            
            displayTxt.Clear();
        }

        private void mulButton_Click(object sender, EventArgs e)
        {
            expressionLbl.Text += String.IsNullOrEmpty(displayTxt.Text) ? Constants.Multiply : displayTxt.Text + Constants.Multiply;
            var number = new Number
            {
                EnteredNumber = String.IsNullOrEmpty(displayTxt.Text) ? 1 : Convert.ToDouble(displayTxt.Text),
                IsCalculated = false
            };
            MultiplyCommand multiplyCommand;
            //Deferred execution
            if (_bracketCount == 0 || _bracketCount % 2 == 0)
            {
                _numbers.Add(number);
                multiplyCommand = new MultiplyCommand(_result, _numbers);
                //Calculating
                _invoker.CalculatingOperations();
            }
            else if (_bracketCount > 0 && _bracketCount % 2 == 0)
            {
                _bracketNumbers.Add(number);
                multiplyCommand = new MultiplyCommand(_result, _bracketNumbers);
                _invoker.CalculatingOperations();
            }
            else
            {
                _bracketNumbers.Add(number);
                multiplyCommand = new MultiplyCommand(_result, _bracketNumbers);
            }
            //Adding current operation into sequence
            _invoker.IncludeOperations(multiplyCommand);
            displayTxt.Clear();
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            expressionLbl.Text += String.IsNullOrEmpty(displayTxt.Text) ? Constants.Divide : displayTxt.Text + Constants.Divide;
            var number = new Number
            {
                EnteredNumber = String.IsNullOrEmpty(displayTxt.Text) ? 1 : Convert.ToDouble(displayTxt.Text),
                IsCalculated = false
            };
            DivideCommand divideCommand;
            //Deferred execution
            if (_bracketCount == 0 || _bracketCount % 2 == 0)
            {
                _numbers.Add(number);
                divideCommand = new DivideCommand(_result, _numbers);
                //Calculating
                _invoker.CalculatingOperations();
            }
            else if (_bracketCount > 0 && _bracketCount % 2 == 0)
            {
                _bracketNumbers.Add(number);
                divideCommand = new DivideCommand(_result, _bracketNumbers);
                _invoker.CalculatingOperations();
            }
            else
            {
                _bracketNumbers.Add(number);
                divideCommand = new DivideCommand(_result, _bracketNumbers);
            }
            //Adding current operation into sequence
            _invoker.IncludeOperations(divideCommand);
            displayTxt.Clear();
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(displayTxt.Text))
            {
                expressionLbl.Text += Constants.Sqrt + Constants.LeftBrace + displayTxt.Text + Constants.RightBrace;
                double enteredValue = Convert.ToDouble(displayTxt.Text);
                var number = new Number {EnteredNumber = enteredValue, IsCalculated = false};
                _numbers.Add(number);
                _invoker.IncludeOperations(new SquareRootCommand(_result, number));
                displayTxt.Clear();
            }
        }

        private void powButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(displayTxt.Text))
            {
                expressionLbl.Text += displayTxt.Text + Constants.Power;
                double enteredValue = Convert.ToDouble(displayTxt.Text);
                var number = new Number { EnteredNumber = enteredValue, IsCalculated = false };
                _numbers.Add(number);
                _invoker.IncludeOperations(new PowerCommand(_result, _numbers));
                displayTxt.Clear();
            }
        }

        private void gaussButton_Click(object sender, EventArgs e)
        {
            using (var gaussForm = new GaussForm())
            {
                if (gaussForm.ShowDialog() == DialogResult.OK)
                {
                    displayTxt.Text = Constants.Gauss + Constants.LeftBrace + gaussForm.A + Constants.Comma
                                        + gaussForm.B + Constants.Comma + gaussForm.C + Constants.Comma + gaussForm.X + Constants.RightBrace;
                    expressionLbl.Text += displayTxt.Text;
                    _invoker.IncludeOperations(new GaussCommand(_result, Convert.ToDouble(gaussForm.A)
                        , Convert.ToDouble(gaussForm.B), Convert.ToDouble(gaussForm.C), Convert.ToDouble(gaussForm.X), _numbers, _bracketNumbers
                        , _bracketCount % 2 == 0));
                    _invoker.Execute(_invoker.Operations.Last());
                    displayTxt.Clear();
                }
            }
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(displayTxt.Text))
            {
                string text = displayTxt.Text;
                displayTxt.Clear();

                displayTxt.Text = text.Substring(0, text.Length - 1);    
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            displayTxt.Clear();
            expressionLbl.Text = String.Empty;
            _numbers.Clear();
            _bracketNumbers.Clear();
            _bracketCount = 0;
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            if (expressionLbl.Text.ToCharArray().Last() != ')')
            {
                if (!String.IsNullOrEmpty(displayTxt.Text))
                {
                    expressionLbl.Text += displayTxt.Text;
                    var number = new Number { EnteredNumber = Convert.ToDouble(displayTxt.Text), IsCalculated = false };
                    _numbers.Add(number);
                }
                else
                {
                    expressionLbl.Text += _result.Answer;
                    var number = new Number { EnteredNumber = _result.Answer, IsCalculated = false };
                    _numbers.Add(number);
                }
            }
            _invoker.CalculatingOperations();
            displayTxt.Text = _result.Answer.ToString();
            _numbers.Clear();
            _bracketNumbers.Clear();
            _result.Answer = 0;
            _invoker.RemovesAllOperations();
            expressionLbl.Text = String.Empty;
        }

        private void lBraceButton_Click(object sender, EventArgs e)
        {
            _bracketCount++;
            displayTxt.Text += Constants.LeftBrace;
            expressionLbl.Text += displayTxt.Text;
            displayTxt.Clear();
        }

        private void rBracebutton_Click(object sender, EventArgs e)
        {
            _bracketCount--;
            displayTxt.Text += Constants.RightBrace;
            //Instant calculation
            expressionLbl.Text += displayTxt.Text;
            //Removing ")" symbol
            var trimmedText = displayTxt.Text.Substring(0, displayTxt.Text.Length - 1);
            if (!String.IsNullOrEmpty(trimmedText) && trimmedText.ToCharArray().Last() != ')')
            {
                var number = new Number { EnteredNumber = Convert.ToDouble(trimmedText), IsCalculated = false };
                _bracketNumbers.Add(number);
                //Calculating
                _invoker.Execute(_invoker.Operations.Last());
            }
            displayTxt.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dotButton_Click(object sender, EventArgs e)
        {
            if (!displayTxt.Text.Contains(Constants.Dot))
            {
                displayTxt.Text += Constants.Dot;
            }
        }
    }
}