using FirstProject.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FirstProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyBtn_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();

            //Login login = new Login();
            //login.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //  MyImage.Visibility = Visibility.Collapsed;

            //BitmapImage logo = new BitmapImage();
            //logo.BeginInit();
            //logo.UriSource = new Uri("d:\\Ruzimurod\\Projects\\WPF\\FirstProject\\Suratim.png");
            //logo.EndInit();

            byte[] imgdata = File.ReadAllBytes("d:\\Ruzimurod\\Projects\\WPF\\FirstProject\\Suratim.png");

            //FileStream stream = File.Open("d:\\Ruzimurod\\Projects\\WPF\\FirstProject\\Suratim.png", FileMode.Open);

            //string Image = stream.ToString();
            string s = "";
            for (int i = 0; i < imgdata.Length; i++)
            {
                s += " " + imgdata[i].ToString();
            }
            //MyTextBox.Text = s;
            List<byte> list = new List<byte>();
            var m = s.Substring(1).Split(char.Parse(" "));

            foreach (var item in m)
            {

                list.Add(byte.Parse(item));
            }
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            Stream stream1 = new MemoryStream(list.ToArray());
            //stream1.ReadTimeout = 15;
            // stream1.WriteTimeout = 15;
            bitmapImage.StreamSource = stream1;
            bitmapImage.EndInit();

            MyImage.Source = bitmapImage;
        }
    }
}
