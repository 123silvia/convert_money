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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace converter_money
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{ 
        public MainWindow()
        {
            InitializeComponent();
        }
        static private List<ConvertMoney> list_convert_money = new List<ConvertMoney>();
        static internal List<ConvertMoney> current_list_convert_money { get => list_convert_money; set => list_convert_money = value; }
        private void load(object o, DoWorkEventArgs args)
        {
            string url = "https://www.cbr-xml-daily.ru/daily_json.js";
            string result_json_string;
            using (var webClient = new WebClient())
            {
                result_json_string = webClient.DownloadString(url);
                JObject result_data = JObject.Parse(result_json_string);
                JObject result_convert_money = (JObject)result_data["Valute"];
                foreach (JProperty res in (JToken)result_convert_money)
                {
                    string value_id = System.Convert.ToString(res.Name);
                    string value_name = System.Convert.ToString(res.Value["Name"]);
                    double value_val = System.Convert.ToDouble(res.Value["Value"]);
                    current_list_convert_money.Add(new ConvertMoney(value_id, value_name, value_val));
                }
                Task.Delay(2000).Wait();
            }

        }
        private void OnRunWorkerCompleted(object o, RunWorkerCompletedEventArgs args)
        {
            _mainFrame.Navigate(new Convert());
        }
        private void Конвертер_валют_Loaded(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Load());
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += load;
            worker.RunWorkerCompleted += OnRunWorkerCompleted;
            worker.RunWorkerAsync();
        }
    }
}
