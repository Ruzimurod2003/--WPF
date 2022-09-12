using FirstProject.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private bool test { get; set; }
        private byte[] image { get; set; }
        public Register()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage logo = new BitmapImage();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    logo.BeginInit();
                    logo.UriSource = new Uri(openFileDialog.FileName);
                    logo.EndInit();
                    PersonImage.Source = logo;
                    image = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                test = false;
            }

        }

        private Department GetDepartment(string department)
        {
            Department dep = new Department();
            switch (department)
            {
                case "Mathematics":
                    dep = Department.Mathematics;
                    break;
                case "Physics":
                    dep = Department.Physics;
                    break;
                case "Informatics":
                    dep = Department.Informatics;
                    break;
                case "Chemistry":
                    dep = Department.Chemistry;
                    break;
            }
            return dep;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            int maxId = 0;
            bool result = ValidatorExtensions.IsValidEmailAddress(EmailText.Text);
            if (!result)
            {
                EmailText.Foreground = Brushes.Red;
                EmailText.Background = Brushes.White;
                MessageBox.Show("Iltimos to'g'ri kiriting!!!", "Xatolik", MessageBoxButton.OK);
            }
            else
            {
                List<User> users = new List<User>();
                string FileName = "d:\\Ruzimurod\\Projects\\WPF\\FirstProject\\Data\\Users.json";
                #region Find max Id
                try
                {
                    string jsonString = File.ReadAllText(FileName);
                    users = JsonSerializer.Deserialize<List<User>>(jsonString);
                }
                catch (Exception)
                {

                }
                #endregion
                EmailText.Foreground = Brushes.Black;
                EmailText.Background = Brushes.White;
                if (users.Count == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = users.Max(i => i.Id) + 1;
                }

                User user = new User
                {
                    FullName = NameText.Text.ToString(),
                    Password = PasswordText.Text.ToString(),
                    Email = EmailText.Text.ToString(),
                    Department = GetDepartment(DepartmentCombo.Text),
                    Birth = BirthDate.Text.ToString(),
                    Image = image,
                    Created = DateTime.Now.ToString("dd.MM.yyyy"),
                    Token = Guid.NewGuid().ToString(),
                    Id = maxId
                };
                // List<User> persons = new List<User>();
                users.Add(user);
                string json = JsonSerializer.Serialize(users);
                File.WriteAllText(FileName, json);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double m = 30;
            DepartmentCombo.Items.Add("Mathematics");
            DepartmentCombo.Items.Add("Physics");
            DepartmentCombo.Items.Add("Chemistry");
            DepartmentCombo.Items.Add("Informatics");

            label1.FontSize = m;
            label2.FontSize = m;
            label3.FontSize = m;
            label4.FontSize = m;
            label5.FontSize = m;
            label5.FontSize = m;
            label6.FontSize = m;
            label7.FontSize = m;

            NameText.FontSize = m;
            PasswordText.FontSize = m;
            EmailText.FontSize = m;
            DepartmentCombo.FontSize = m;
            BirthDate.FontSize = m;

            btnOpenFile.FontSize = m;
            Add.FontSize = m;
            Update.FontSize = m;
            Delete.FontSize = m;
        }

    }
    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }
}
