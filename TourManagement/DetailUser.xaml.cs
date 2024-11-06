using Microsoft.IdentityModel.Tokens;
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
using TourManagement.BLL.Services;
using TourManagement.DAL.Model;

namespace TourManagement
{
    /// <summary>
    /// Interaction logic for DetailUser.xaml
    /// </summary>
    public partial class DetailUser : Window
    {
        private MemberServices _service = new();
        public Member EditMember { get; set; } = null;
        public DetailUser()
        {
            InitializeComponent();
        }
        private bool ValidateElements()
        {
            if (FullNameTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The full name is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (UserNameTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The username is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (GenderTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The gender is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (PasswordTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The password is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (RoleTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The role is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateElements())
                return;


            Member x = new();
            if (EditMember != null && UserIDTextBox.Text != null)
            {
                x.UserId = int.Parse(UserIDTextBox.Text);
            }
            x.Username = UserNameTextBox.Text;
            x.FullName = FullNameTextBox.Text;
            x.Gender = GenderTextBox.Text;
            x.Password = PasswordTextBox.Text;
            x.Role = RoleTextBox.Text;

            if (EditMember == null)
                _service.AddUser(x);
            else
                _service.UpdateUser(x);
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillElements(EditMember);
            if (EditMember != null)
                DetailUserMode.Content = "Update infomation of member";
            else
                DetailUserMode.Content = "Create new member";
        }
        private void FillElements(Member x)
        {
            if (x == null)
                return;
            UserIDTextBox.Text = x.UserId.ToString();
            UserIDTextBox.IsEnabled = false;

            UserNameTextBox.Text = x.Username;
            FullNameTextBox.Text = x.FullName;
            GenderTextBox.Text = x.Gender;
            PasswordTextBox.Text = x.Password;
            RoleTextBox.Text = x.Role;
            RoleTextBox.IsEnabled = false;
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
