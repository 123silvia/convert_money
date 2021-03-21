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

namespace PI.ConvertMoneyOther
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
            foreach (ConvertingMoney valueMoney in ParsingJson.ListConvertMoney)
            {
                if (ConvertingValuesMoney.checkButton1 == true && ConvertingValuesMoney.Convert2Text != valueMoney.IdMoney)
                {
                    RadioButton radioButtons = new RadioButton() { Content = valueMoney.NameMoney + " " + valueMoney.IdMoney, Name = valueMoney.IdMoney, GroupName = valueMoney.ValueMoney.ToString(), Tag=valueMoney.NominalMoney, FontFamily= new FontFamily("Time New Roman"), FontSize = 24 };
                    radioButtons.Click += delegate (object sender, RoutedEventArgs e)
                    {
                        ConvertingValuesMoney.Convert1Text = radioButtons.Name;
                        ConvertingValuesMoney.Convert1Value = System.Convert.ToDouble(radioButtons.GroupName);
                        ConvertingValuesMoney.Convert1Nominal = System.Convert.ToDouble(radioButtons.Tag);
                        this.NavigationService.Navigate(new Uri("ConvertValue.xaml", UriKind.Relative));
                    };
                    MyStackPanel.Children.Add(radioButtons);
                } else if(ConvertingValuesMoney.checkButton2 == true && ConvertingValuesMoney.Convert1Text != valueMoney.IdMoney)
                {
                    RadioButton radioButtons = new RadioButton() { Content = valueMoney.NameMoney + " " + valueMoney.IdMoney, Name = valueMoney.IdMoney, GroupName = valueMoney.ValueMoney.ToString(), Tag = valueMoney.NominalMoney, FontFamily = new FontFamily("Time New Roman"), FontSize = 24 };
                    radioButtons.Click += delegate (object sender, RoutedEventArgs e)
                    {
                        ConvertingValuesMoney.Convert2Text = radioButtons.Name;
                        ConvertingValuesMoney.Convert2Value = System.Convert.ToDouble(radioButtons.GroupName);
                        ConvertingValuesMoney.Convert2Nominal = System.Convert.ToDouble(radioButtons.Tag);
                        this.NavigationService.Navigate(new Uri("ConvertValue.xaml", UriKind.Relative));
                    };
                    MyStackPanel.Children.Add(radioButtons);
                }
                
            }
        }
    }
}
