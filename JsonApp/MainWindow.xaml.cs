using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading.Tasks;
using RestSharp;
using System.IO;

namespace JsonApp
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ulozit(object Sender, RoutedEventArgs e)
        {
            string url = "https://jsonplaceholder.typicode.com/comments";
            string stream;
            string path = "data.txt";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute<List<komenty>>(request);
            stream = SimpleJson.SerializeObject(response.Data);
            File.WriteAllText(path, stream + DateTime.Now.ToString());
            status.Content = "OK, data uložená v texťáku!!!";
        }

    }
}
