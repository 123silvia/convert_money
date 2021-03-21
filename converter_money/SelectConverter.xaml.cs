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

namespace converter_money
{
    /// <summary>
    /// Логика взаимодействия для SelectConverter.xaml
    /// </summary>
    public partial class SelectConverter : Page
    {
        public SelectConverter()
        {
            InitializeComponent();
            Application.Current.MainWindow.Title = "Выбор валют";
            foreach (ConvertMoney valueMoney in ParseJson.ListConvertMoney)
            {
                if (ConvertValuesMoney.checkButton1 == true && ConvertValuesMoney.Convert2Text != valueMoney.IdMoney)
                {
                    RadioButton radioButtons = new RadioButton() { Content = valueMoney.NameMoney + " " + valueMoney.IdMoney, Name = valueMoney.IdMoney, GroupName = valueMoney.ValueMoney.ToString(), Tag=valueMoney.NominalMoney, FontFamily= new FontFamily("Time New Roman"), FontSize = 24 };
                    radioButtons.Click += delegate (object sender, RoutedEventArgs e)
                    {
                        ConvertValuesMoney.Convert1Text = radioButtons.Name;
                        ConvertValuesMoney.Convert1Value = System.Convert.ToDouble(radioButtons.GroupName);
                        ConvertValuesMoney.Convert1Nominal = System.Convert.ToDouble(radioButtons.Tag);
                        this.NavigationService.Navigate(new Uri("ConvertValue.xaml", UriKind.Relative));
                    };
                    MyStackPanel.Children.Add(radioButtons);
                } else if(ConvertValuesMoney.checkButton2 == true && ConvertValuesMoney.Convert1Text != valueMoney.IdMoney)
                {
                    RadioButton radioButtons = new RadioButton() { Content = valueMoney.NameMoney + " " + valueMoney.IdMoney, Name = valueMoney.IdMoney, GroupName = valueMoney.ValueMoney.ToString(), Tag = valueMoney.NominalMoney, FontFamily = new FontFamily("Time New Roman"), FontSize = 24 };
                    radioButtons.Click += delegate (object sender, RoutedEventArgs e)
                    {
                        ConvertValuesMoney.Convert2Text = radioButtons.Name;
                        ConvertValuesMoney.Convert2Value = System.Convert.ToDouble(radioButtons.GroupName);
                        ConvertValuesMoney.Convert2Nominal = System.Convert.ToDouble(radioButtons.Tag);
                        this.NavigationService.Navigate(new Uri("ConvertValue.xaml", UriKind.Relative));
                    };
                    MyStackPanel.Children.Add(radioButtons);
                }
                
            }
        }
    }
}
