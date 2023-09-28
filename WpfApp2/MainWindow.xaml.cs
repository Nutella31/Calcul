using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace WpfApp2
{

    public partial class MainWindow : Window
    {
        string leftop = "";
        string operation = "";
        string rightop = "";
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textBlock.Text += s;
            int num;
            bool result = Int32.TryParse(s, out num);
            if (result == true)
            {
                if (operation == "")
                {
                    leftop += s;
                }
                else
                {
                    rightop += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                }
                else if (s == "C")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
                //case "//":
                //    rightop = Math.Sqrt(num1).ToString();
                //    break;
            }

        }

        private void RootButton(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(leftop))
            {
                double num1 = double.Parse(leftop);
                if (num1 >= 0)
                {
                    double result = Math.Sqrt(num1);
                    leftop = result.ToString();
                    textBlock.Text = leftop;
                }
                else
                {
                    textBlock.Text = "Error";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(leftop))
            {
                double num1 = double.Parse(leftop);
                if (num1 >= 0)
                {
                    double sinValue = Math.Sin(num1);
                    leftop = sinValue.ToString();
                    textBlock.Text = leftop;
                }
                else
                {
                    textBlock.Text = "Error";
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(leftop))
            {
                double num1 = double.Parse(leftop);
                if (num1 >= 0)
                {
                    double sinValue = Math.Cos(num1);
                    leftop = sinValue.ToString();
                    textBlock.Text = leftop;
                }
                else
                {
                    textBlock.Text = "Error";
                }
            }
        }


    }
}
