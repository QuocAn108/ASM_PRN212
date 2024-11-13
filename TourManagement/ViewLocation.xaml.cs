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
    /// Interaction logic for ViewLocation.xaml
    /// </summary>
    public partial class ViewLocation : Window
    {
        private LocationService _service = new();
        public ViewLocation()
        {
            InitializeComponent();
            FillDataGrid(_service.GetAllLocation());
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailLocation d = new();
            d.ShowDialog();
            FillDataGrid(_service.GetAllLocation());
        }
        private void FillDataGrid(List<Location> list)
        {
            LocaltionDataGrid.ItemsSource = null;
            LocaltionDataGrid.ItemsSource = list;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Location? selected = LocaltionDataGrid.SelectedItem as Location;
            if (selected == null)
            { 
                MessageBox.Show("Please select a row/ an location before deleting", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Do you really want to delete?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;

            _service.DeleteLocation(selected);
            FillDataGrid(_service.GetAllLocation());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Location? selected = LocaltionDataGrid.SelectedItem as Location;
            if (selected == null)
            { 
                MessageBox.Show("Please select a row/ an location before editing", "Select a row", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
          
            DetailLocation d = new();
            d.EditLocation = selected;
            d.ShowDialog();
            FillDataGrid(_service.GetAllLocation());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var result = _service.SearchLocation(LocationTextBox.Text.Trim(), RegionTextBox.Text.Trim());
            FillDataGrid(result);
        }
    }
}
