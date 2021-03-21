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


namespace PI.ConvertMoneyOther
{
    public partial class ConvertValue : Page
    {
        public ConvertValue()
        {
            Application.Current.MainWindow.Title = "Конвертер валют";
            InitializeComponent();
            ConvertingMoney[] inputs = ParsingJson.ListConvertMoney.GetRange(0, 2).ToArray();
            if (ConvertingValuesMoney.СheckButton1 != true && ConvertingValuesMoney.Convert1Text == null)
            {
                ValueElement1.convertName.Content= inputs[0].IdMoney;
                ConvertingValuesMoney.Convert1Text = inputs[0].IdMoney;
                ConvertingValuesMoney.Convert1Value = inputs[0].ValueMoney;
                ConvertingValuesMoney.Convert1Nominal = inputs[0].NominalMoney;

            }
            else
            {
                ValueElement1.convertName.Content = ConvertingValuesMoney.Convert1Text;
                ValueElement1.convertSum.Text = ConvertingValuesMoney.PrintSum1;
                string dataText = ValueElement1.convertSum.Text;
                ValueElement2.convertSum.Text = ConvertingValuesMoney.Convert1Convert2(dataText);
            }

            if (ConvertingValuesMoney.СheckButton2 != true && ConvertingValuesMoney.Convert2Text  ==  null)
            {
                ValueElement2.convertName.Content= inputs[1].IdMoney;
                ConvertingValuesMoney.Convert2Text = inputs[1].IdMoney;
                ConvertingValuesMoney.Convert2Value = inputs[1].ValueMoney;
                ConvertingValuesMoney.Convert2Nominal = inputs[1].NominalMoney;
            }
            else
            {
                ValueElement2.convertName.Content = ConvertingValuesMoney.Convert2Text;
                ValueElement2.convertSum.Text = ConvertingValuesMoney.PrintSum2;
                string dataText = ValueElement1.convertSum.Text;
                ValueElement2.convertSum.Text = ConvertingValuesMoney.Convert1Convert2(dataText);
            }
            
        }

        private void ConvertButtonClick1(object sender, RoutedEventArgs e)
        {
            ConvertingValuesMoney.СheckButton1 = true;
            ConvertingValuesMoney.СheckButton2 = false;
            ConvertingValuesMoney.PrintSum1 = ValueElement1.convertSum.Text;
            ConvertingValuesMoney.PrintSum2 = ValueElement2.convertSum.Text;
            this.NavigationService.Navigate(new Uri("SelectConverter.xaml", UriKind.Relative));
        }

        private void ConvertButtonClick2(object sender, RoutedEventArgs e)
        {
            ConvertingValuesMoney.СheckButton1 = false;
            ConvertingValuesMoney.СheckButton2 = true;
            ConvertingValuesMoney.PrintSum1 = ValueElement1.convertSum.Text;
            ConvertingValuesMoney.PrintSum2 = ValueElement2.convertSum.Text;
            this.NavigationService.Navigate(new Uri("SelectConverter.xaml", UriKind.Relative));
        }
        private void TextChangedConvertSum1(object sender, RoutedEventArgs e)
        {
            string dataText = ValueElement1.convertSum.Text;
            if (ValueElement1.convertSum.IsFocused  ==  true)
                ValueElement2.convertSum.Text = ConvertingValuesMoney.Convert1Convert2(dataText);
        }
        private void TextChangedConvertSum2(object sender, RoutedEventArgs e)
        {

            string dataText = ValueElement2.convertSum.Text;
            if (ValueElement2.convertSum.IsFocused == true) 
                ValueElement1.convertSum.Text = ConvertingValuesMoney.Convert2Convert1(dataText);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ConvertingValuesMoney.TranspositionConvert();
            ValueElement1.convertName.Content = ConvertingValuesMoney.Convert1Text;
            ValueElement2.convertName.Content = ConvertingValuesMoney.Convert2Text;
            string dataText = ValueElement1.convertSum.Text;
            ValueElement2.convertSum.Text = ConvertingValuesMoney.Convert1Convert2(dataText);
        }
    }
}
