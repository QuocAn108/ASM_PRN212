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
    }
}
