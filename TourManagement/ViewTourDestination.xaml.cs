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
    /// Interaction logic for ViewTourDestination.xaml
    /// </summary>
    public partial class ViewTourDestination : Window
    {
        private TourDestinationService _service = new();

        public ViewTourDestination()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            ToursDestinationDataGrid.ItemsSource = null;
            ToursDestinationDataGrid.ItemsSource = _service.GetAllTD();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailTourDestination detailTourDestination = new DetailTourDestination();
            detailTourDestination.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TourDestination selected = ToursDestinationDataGrid.SelectedItems as TourDestination;
            if(selected == null)
            {
                MessageBox.Show("Please select a Tour Destination first!", "Item Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _service.Delete(selected);
            }

            FillDataGrid();
        }
    }
}
