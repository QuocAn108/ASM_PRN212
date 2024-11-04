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
    /// Interaction logic for ViewUser.xaml
    /// </summary>
    public partial class ViewUser : Window
    {
        private MemberServices _service = new();
        public ViewUser()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            UserDataGrid.ItemsSource = null;
            UserDataGrid.ItemsSource = _service.GetAllUser();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Member? selected = UserDataGrid.SelectedItem as Member;
            if (selected == null)
            {
                MessageBox.Show("Please select a row/ an location before editing", "Select a row", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DetailUser d = new();
            d.EditMember = selected;
            d.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            Member? selected = UserDataGrid.SelectedItem as Member;
            if (selected == null)
            {
                MessageBox.Show("Please select a row/ an location before deleting", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Do you really want to delete?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;

            _service.DeleteUser(selected);
            FillDataGrid();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailUser d = new();
            d.ShowDialog();
            FillDataGrid();
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
