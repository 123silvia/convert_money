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


namespace converter_money
{
    /// <summary>
    /// Логика взаимодействия для Convert.xaml
    /// </summary>
    public partial class ConvertValue : Page
    {
        public ConvertValue()
        {
            Application.Current.MainWindow.Title = "Конвертер валют";
            InitializeComponent();
            ConvertMoney[] inputs = ParseJson.ListConvertMoney.GetRange(0, 2).ToArray();
            if (ConvertValuesMoney.checkButton1 != true && ConvertValuesMoney.Convert1Text==null)
            {
                ValueElement1.convertName.Content= inputs[0].IdMoney;
                ConvertValuesMoney.Convert1Text = inputs[0].IdMoney;
                ConvertValuesMoney.Convert1Value = inputs[0].ValueMoney;
                ConvertValuesMoney.Convert1Nominal = inputs[0].NominalMoney;

            }
            else
            {
                ValueElement1.convertName.Content = ConvertValuesMoney.Convert1Text;
                ValueElement1.convertSum.Text = ConvertValuesMoney.PrintSum1;
                string dataText = ValueElement1.convertSum.Text;
                ValueElement2.convertSum.Text = ConvertValuesMoney.Convert1Convert2(dataText);
            }
            if (ConvertValuesMoney.checkButton2 != true && ConvertValuesMoney.Convert2Text==null)
            {
                ValueElement2.convertName.Content= inputs[1].IdMoney;
                ConvertValuesMoney.Convert2Text = inputs[1].IdMoney;
                ConvertValuesMoney.Convert2Value = inputs[1].ValueMoney;
                ConvertValuesMoney.Convert2Nominal = inputs[1].NominalMoney;
            }
            else
            {
                ValueElement2.convertName.Content = ConvertValuesMoney.Convert2Text;
                ValueElement2.convertSum.Text =ConvertValuesMoney.PrintSum2;
                string dataText = ValueElement1.convertSum.Text;
                ValueElement2.convertSum.Text = ConvertValuesMoney.Convert1Convert2(dataText);
            }
            
        }

        private void ConvertButtonClick1(object sender, RoutedEventArgs e)
        {
            ConvertValuesMoney.checkButton1 = true;
            ConvertValuesMoney.checkButton2 = false;
            ConvertValuesMoney.PrintSum1 = ValueElement1.convertSum.Text;
            ConvertValuesMoney.PrintSum2 = ValueElement2.convertSum.Text;
            this.NavigationService.Navigate(new Uri("SelectConverter.xaml", UriKind.Relative));
        }

        private void ConvertButtonClick2(object sender, RoutedEventArgs e)
        {
            ConvertValuesMoney.checkButton1 = false;
            ConvertValuesMoney.checkButton2 = true;
            ConvertValuesMoney.PrintSum1 = ValueElement1.convertSum.Text;
            ConvertValuesMoney.PrintSum2 = ValueElement2.convertSum.Text;
            this.NavigationService.Navigate(new Uri("SelectConverter.xaml", UriKind.Relative));
        }
        private void TextChangedtextboks1(object sender, RoutedEventArgs e)
        {
            string dataText = ValueElement1.convertSum.Text;
            if (ValueElement1.convertSum.IsFocused==true)
                ValueElement2.convertSum.Text = ConvertValuesMoney.Convert1Convert2(dataText);
        }
        private void TextChangedtextboks2(object sender, RoutedEventArgs e)
        {

            string dataText = ValueElement2.convertSum.Text;
            if (ValueElement2.convertSum.IsFocused == true) 
                ValueElement1.convertSum.Text = ConvertValuesMoney.Convert2Convert1(dataText);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ConvertValuesMoney.TranspositionConvert();
            ValueElement1.convertName.Content = ConvertValuesMoney.Convert1Text;
            ValueElement2.convertName.Content = ConvertValuesMoney.Convert2Text;
            string dataText = ValueElement1.convertSum.Text;
            ValueElement2.convertSum.Text = ConvertValuesMoney.Convert1Convert2(dataText);
        }
    }
}
