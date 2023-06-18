using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void NumberButtonClicked(char num)
        {
            if (textBoxInput.Text == "0")
            {
                textBoxInput.Text = num.ToString();
            }
            else
            {
                textBoxInput.Text += num;
            }
        }

        public void OperationButtonClicked(char op)
        {
            if (textBoxInput.Text == "∞" || textBoxInput.Text == "-∞")
            {
                textBoxInput.Text = "0";
                textBoxHystory.Text = "";
            }

            if (textBoxInput.Text == "0")
            {
                return;
            }

            else
            {
                if (int.TryParse(textBoxInput.Text.Substring(textBoxInput.Text.Length - 1, 1), out int result))
                {                    
                    textBoxInput.Text += op;
                }
                else
                {
                    textBoxInput.Text = textBoxInput.Text.Substring(0, textBoxInput.Text.Length - 1) + op;
                }
            }
        }

        public void ResultCalculation()
        {
            if (textBoxInput.Text == "∞" || textBoxInput.Text == "-∞")
            {
                textBoxInput.Text = "0";
                textBoxHystory.Text = "";
            }

            if (textBoxInput.Text == "0")
            {
                return;
            }

            if (!int.TryParse(textBoxInput.Text.Substring(textBoxInput.Text.Length - 1, 1), out int result))
            {
                textBoxInput.Text = textBoxInput.Text.Substring(0, textBoxInput.Text.Length - 1);
            }
            CalculatorProgram.Calculate(textBoxInput.Text);
            textBoxInput.Text = CalculatorProgram.ResultingVariable.ToString();

            if (CalculatorProgram.Operation == '*' || CalculatorProgram.Operation == '/')
            {
                textBoxHystory.Text = "(" + textBoxHystory.Text + ")" + CalculatorProgram.Operation.ToString() + CalculatorProgram.B_res.ToString();
            }
            else if (CalculatorProgram.Operation == '0')
            {
                textBoxHystory.Text = textBoxInput.Text;
            }
            else
            {
                textBoxHystory.Text += CalculatorProgram.Operation.ToString();
                textBoxHystory.Text += CalculatorProgram.B_res.ToString();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            CalculatorProgram Calc = new CalculatorProgram(0, 0);
            textBoxInput.Text = "0";
            textBoxHystory.Text = "";
        }

        private void Button0_OnClick(object sender, RoutedEventArgs e)
        {
            if (textBoxInput.Text == "0")
            {
                return;
            }
            else
            {
                textBoxInput.Text += '0';
            }
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('1');
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('2');
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('3');
        }

        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('4');
        }

        private void Button5_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('5');
        }

        private void Button6_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('6');
        }

        private void Button7_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('7');
        }

        private void Button8_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('8');
        }

        private void Button9_OnClick(object sender, RoutedEventArgs e)
        {
            NumberButtonClicked('9');
        }

        private void ButtonSum_OnClick(object sender, RoutedEventArgs e)
        {
            ResultCalculation();
            OperationButtonClicked('+');
        }        

        private void ButtonSub_OnClick(object sender, RoutedEventArgs e)
        {    
            if (textBoxInput.Text == "∞" || textBoxInput.Text == "-∞")
            {
                textBoxInput.Text = "-";
            }
            

            else
            {
                ResultCalculation();
                if (textBoxInput.Text == "0")
                {
                    textBoxInput.Text += "-";
                }
                OperationButtonClicked('-');
            }
            
        }

        private void ButtonMult_OnClick(object sender, RoutedEventArgs e)
        {
            ResultCalculation();
            OperationButtonClicked('*');
        }

        private void ButtonDiv_OnClick(object sender, RoutedEventArgs e)
        {
            ResultCalculation();
            OperationButtonClicked('/');
        }

        private void ButtonDot_OnClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxInput.Text.Substring(textBoxInput.Text.Length - 1, 1), out int result))
            {
                if (!CalculatorProgram.CheckDot(textBoxInput.Text))
                {
                    textBoxInput.Text += ',';
                    textBoxHystory.Text += ',';
                }
            }
        }

        private void ButtonC_OnClick(object sender, RoutedEventArgs e)
        {
            CalculatorProgram.ResultingVariable = 0;
            textBoxInput.Text = "0";
        }

        private void ButtonResult_OnClick(object sender, RoutedEventArgs e)
        {
            ResultCalculation();
        }

        private void ButtonCE_OnClick(object sender, RoutedEventArgs e)
        {
            CalculatorProgram.ResultingVariable = 0;
            textBoxInput.Text = "0"; 
            textBoxHystory.Text = "";
        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            if (textBoxInput.Text.Length == 1)
            {
                textBoxInput.Text = "0";
            }

            else if (textBoxInput.Text.EndsWith('*') || textBoxInput.Text.EndsWith('/'))
            {
                textBoxInput.Text = textBoxInput.Text.Remove(textBoxInput.Text.Length - 1, 1);
            }

            else
            {
                textBoxInput.Text = textBoxInput.Text.Remove(textBoxInput.Text.Length - 1, 1);
            }
        }
    }
}
