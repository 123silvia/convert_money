using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading;
using System.Globalization;

namespace converter_money
{
    /// <summary>
    /// Логика взаимодействия для Convert.xaml
    /// </summary>
    public partial class Convert : Page
    {
        static public double Convert1Value;
        static public double Convert2Value;
        static public string Convert1Text;
        static public string Convert2Text;
        static public bool check_buton1=false;
        static public bool check_button2=false;
        public Convert()
        {
            Application.Current.MainWindow.Title = "Конвертер валют";
            InitializeComponent();
            ConvertMoney[] inputs = MainWindow.current_list_convert_money.GetRange(0, 2).ToArray();
            if (check_buton1 != true && Convert1Text==null)
            {
                Convert1.Content = inputs[0].Id;
                Convert1Text = inputs[0].Id;
                Convert1Value = inputs[0].Value;

            }
            else
            {
                Convert1.Content = Convert1Text;
            }
            if (check_button2 != true && Convert2Text==null)
            {
                Convert2.Content = inputs[1].Id;
                Convert2Text = inputs[1].Id;
                Convert2Value = inputs[1].Value;
            }
            else
            {
                Convert2.Content = Convert2Text;
            }
            
        }
        public static bool isInteger(String s)
        {
            try
            {
                System.Convert.ToInt64(s);
            }
            catch (FormatException e)
            {
                return false;
            }
            return true;
        }
        public static bool isDouble(String s)
        {
            try
            {
                double res=System.Convert.ToDouble(s);
            }
            catch (FormatException e)
            {
                return false;
            }
            return true;
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!textBoxConvert1.Text.Contains(".")
               && textBoxConvert1.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void textBoxConvert2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!textBoxConvert2.Text.Contains(".")
               && textBoxConvert2.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void textBoxConvert1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            string data = textBoxConvert1.Text;
            if (data != "0.0" && data!="" && (isInteger(data) || isDouble(data)) && textBoxConvert1.IsFocused==true)
            {
                double val = System.Convert.ToDouble(data);
               double res = val * Convert2Value;
                textBoxConvert2.Text = System.Convert.ToString(res);
            }
        }

        private void textBoxConvert2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            string data = textBoxConvert2.Text;
            if (data != "0.0" && data != "" && (isInteger(data) || isDouble(data)) && textBoxConvert2.IsFocused == true)
            {
                double res = System.Convert.ToDouble(data) * Convert1Value;
                textBoxConvert1.Text = System.Convert.ToString(res);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            check_buton1 = true;
            check_button2 = false;
            this.NavigationService.Navigate(new Uri("SelectConverter.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            check_buton1 = false;
            check_button2 = true;
            this.NavigationService.Navigate(new Uri("SelectConverter.xaml", UriKind.Relative));
        }
    }
}
