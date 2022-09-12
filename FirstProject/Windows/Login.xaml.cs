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
using System.Windows.Shapes;

namespace FirstProject.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int m = 30;
            label1.FontSize = m;
            label2.FontSize = m;
            Elektron_pochta.FontSize = m;
            Parol.FontSize = m;
            Kirish.FontSize = m;
        }

        private void Kirish_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
