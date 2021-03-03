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
            foreach (ConvertMoney val in MainWindow.current_list_convert_money)
            {
                if (Convert.check_buton1 == true && Convert.Convert2Text != val.Id)
                {
                    RadioButton rb = new RadioButton() { Content = val.Name + " " + val.Id, Name = val.Id, GroupName = val.Value.ToString(), FontFamily= new FontFamily("Time New Roman"), FontSize = 24 };
                    rb.Click += delegate (object sender, RoutedEventArgs e)
                    {
                        Convert.Convert1Text = rb.Name;
                        Convert.Convert1Value = System.Convert.ToDouble(rb.GroupName);
                        this.NavigationService.Navigate(new Uri("Convert.xaml", UriKind.Relative));
                    };
                    MyStackPanel.Children.Add(rb);
                } else if(Convert.check_button2 == true && Convert.Convert1Text != val.Id)
                {
                    RadioButton rb = new RadioButton() { Content = val.Name + " " + val.Id, Name = val.Id, GroupName = val.Value.ToString(), FontFamily = new FontFamily("Time New Roman"), FontSize = 24 };
                    rb.Click += delegate (object sender, RoutedEventArgs e)
                    {
                        Convert.Convert2Text = rb.Name;
                        Convert.Convert2Value = System.Convert.ToDouble(rb.GroupName);
                        this.NavigationService.Navigate(new Uri("Convert.xaml", UriKind.Relative));
                    };
                    MyStackPanel.Children.Add(rb);
                }
                
            }
        }
    }
}
