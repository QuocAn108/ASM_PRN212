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
    /// Interaction logic for DetailTourDestination.xaml
    /// </summary>
    public partial class DetailTourDestination : Window
    {
        private TourService _tourService = new TourService();
        private LocationService _locationService = new LocationService();
        private TourDestinationService _tourDestinationService = new TourDestinationService();
        public DetailTourDestination()
        {
            InitializeComponent();
        }

        private void DetailTourDestination1_Loaded(object sender, RoutedEventArgs e)
        {
            TourIdComboBox.ItemsSource = _tourService.GetAllTour();
            TourIdComboBox.DisplayMemberPath = "TourName";
            TourIdComboBox.SelectedValuePath = "TourId";
            LocationIdComboBox.ItemsSource= _locationService.GetAllLocation();
            LocationIdComboBox.DisplayMemberPath = "LocationName";
            LocationIdComboBox.SelectedValuePath = "LocationId";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Check())
            {
                return;
            }

            TourDestination tourDestination = new TourDestination();
            tourDestination.TourId = int.Parse(TourIdComboBox.SelectedValue.ToString());
            tourDestination.LocationId = int.Parse(LocationIdComboBox.SelectedValue.ToString());
            tourDestination.Type = TypeTextBox.Text;

            _tourDestinationService.Add(tourDestination);

            this.Close();
        }

        public bool Check()
        {
            if (string.IsNullOrWhiteSpace(TypeTextBox.Text))
            {
                MessageBox.Show("Please enter Type before saving!", "Type Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (TourIdComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Tour before saving!", "Tour Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (LocationIdComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Location before saving!", "Location Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            int tourId = int.Parse(TourIdComboBox.SelectedValue.ToString());
            int locationId = int.Parse(LocationIdComboBox.SelectedValue.ToString());

            if (_tourDestinationService.IsExist(tourId, locationId))
            {
                MessageBox.Show("Tour Destination already exist!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
