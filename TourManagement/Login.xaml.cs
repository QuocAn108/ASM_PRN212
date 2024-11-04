using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Shapes;
using TourManagement.BLL.Services;
using TourManagement.DAL.Model;

namespace TourManagement
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private MemberServices _service = new();
        public Login()
        {
            InitializeComponent();
            uploadImage();
        }
        private void uploadImage()
        {
            string imgFolderPath = @"C:\Users\lienm\source\repos\ASM_PRN212\TourManagement\Img\";
            string backgroundImageFileName = "fushi4k.jpg";
            string backgroundImagePath = System.IO.Path.Combine(imgFolderPath, backgroundImageFileName);
            if (File.Exists(backgroundImagePath))
            {
                ImageBrush backgroundBrush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(backgroundImagePath, UriKind.Absolute)),
                    Stretch = Stretch.Fill
                };
                BackgroundGrid.Background = backgroundBrush;
            }
            else
            {
                MessageBox.Show("Ảnh nền không tồn tại trong thư mục img!");
            }
        }
        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Username")
            {
                UsernameTextBox.Text = "";
                UsernameTextBox.Foreground = Brushes.Black;
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Username";
                UsernameTextBox.Foreground = Brushes.Black;
            }
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text == "Password")
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.Foreground = Brushes.Black;
            }
        }

        private void PasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                PasswordTextBox.Text = "Password";
                PasswordTextBox.Foreground = Brushes.Black;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text.IsNullOrEmpty() || PasswordTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Both username and password are required ", "Required fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Member? u = _service.CheckLogin(UsernameTextBox.Text, PasswordTextBox.Text);
            if (u == null)
            {
                MessageBox.Show("Invalid username or password", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow m = new();
            m.CurAccount = u;
            m.ShowDialog();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
