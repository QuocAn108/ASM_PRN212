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
    /// Interaction logic for DetailLocation.xaml
    /// </summary>
    public partial class DetailLocation : Window
    {
        private LocationService _service = new();
        public Location EditLocation { get; set; } = null;
        public DetailLocation()
        {
            InitializeComponent();
        }
        private bool ValidateElements()
        {
            if (LocationNameTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The location name is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (DescriptionTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The description is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (RegionTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The region is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (TypeTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The type is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
            return true;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateElements())
                return;


            Location x = new();
            x.LocationName = LocationNameTextBox.Text;
            x.Introduction = DescriptionTextBox.Text;
            x.Region = RegionTextBox.Text;
            x.Type = TypeTextBox.Text;
           
            if (EditLocation == null)
                _service.AddLocation(x);
            else
                _service.UpdateLocation(x);
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillElements(EditLocation);
            if (EditLocation != null)
                DetailLocationMode.Content = "Update infomation of Location";
            else
                DetailLocationMode.Content = "Create new Location";
        }
        private void FillElements(Location x)
        {
            if (x == null)
                return;
            LocationIDTextBox.Text = x.LocationId.ToString();
            LocationIDTextBox.IsEnabled = false;

            LocationNameTextBox.Text = x.LocationName;
            DescriptionTextBox.Text = x.Introduction;
            RegionTextBox.Text = x.Region;
            TypeTextBox.Text = x.Type;
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
