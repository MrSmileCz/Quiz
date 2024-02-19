using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RandomProblem();
        }

        public Random rnd = new Random();
        public char[] operators = { '+', '-', '*', '/' };
        public int equals;

        public void RandomProblem()
        {
            char op = operators[rnd.Next(operators.Length)];
            int num1 = rnd.Next(10);
            int num2 = rnd.Next(10);
            MathProblem.Content = $"{num1} {op} {num2}";
            switch (op)
            {
                case '+':
                    equals = num1 + num2;
                    break;
                case '-':
                    equals = num1 - num2;
                    break;
                case '*':
                    equals = num1 * num2;
                    break;
                case '/':
                    if (!((num1 % num2) == 0) || num2 == 0)
                    {
                        num2 = num1;
                        num1 = num1 * rnd.Next(1, 10);
                        MathProblem.Content = $"{num1} {op} {num2}";
                    }
                    equals = num1 / num2;
                    break;

            }
            Btn1.Content = equals;
        }

        private void OnClickAnswer(object sender, RoutedEventArgs e)
        {
            RandomProblem();
            Score.Content = ((Button)sender).Tag;
        }
    }
}
