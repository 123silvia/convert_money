using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace PI.ConvertMoneyOther
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{ 
        public MainWindow()
        {
            InitializeComponent();
        }
        private void loadPaseJson(object o, DoWorkEventArgs args)
        {
            ParsingWebClient webClient = new ParsingWebClient();
            string urlText = "https://www.cbr-xml-daily.ru/daily_json.js";
            bool result = webClient.ConnectionToParse(urlText);
            while (!result)
            {
                MessageBox.Show("Нет соединения с интернетом, проверьте свое соединение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                result = webClient.ConnectionToParse(urlText);
            }
            Task.Delay(2000).Wait();

        }
        private void OnRunWorkerCompleted(object o, RunWorkerCompletedEventArgs args)
        {
            mainFrame.Navigate(new ConvertValue());
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new LoadAnimals());
            BackgroundWorker workerLoaded = new BackgroundWorker();
            workerLoaded.DoWork += loadPaseJson;
            workerLoaded.RunWorkerCompleted += OnRunWorkerCompleted;
            workerLoaded.RunWorkerAsync();
        }
    }
}
