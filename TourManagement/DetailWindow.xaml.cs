using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private TourService _tourService = new();

        public Tour EditedOne { get; set; }

        public DetailWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to quit??", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckVar())
                return;
            Tour tour = new();
            if (EditedOne != null)
            tour.TourId = int.Parse(TourIDTextBox.Text);
            tour.TourName = TourNameTextBox.Text;
            tour.Price = float.Parse(PriceTextBox.Text);
            tour.StartTime = StartTimeTextBox.Text;
            tour.FinishTime = FinishTimeTextBox.Text;
            tour.NumberOfParticipate = int.Parse(ParticipantsTextBox.Text);

            if (EditedOne != null) // đang ở chế độ edit
                _tourService.UpdateTour(tour);
            else
             _tourService.AddTour(tour);
            this.Close();
        }

        public bool CheckVar()
        {
            if (string.IsNullOrWhiteSpace(TourNameTextBox.Text))
            {
                MessageBox.Show("Tour Name Is Required!!", "Require Information!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (TourNameTextBox.Text.Trim().Length < 5)
            {
                MessageBox.Show("Tour Name Must Longer 5 Characters!!", "Require Information!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            TextInfo textInfor = CultureInfo.CurrentCulture.TextInfo;

            string tourName = TourNameTextBox.Text.Trim();

            tourName = textInfor.ToTitleCase(tourName.ToLower());
            TourNameTextBox.Text = tourName;

            if (string.IsNullOrWhiteSpace(PriceTextBox.Text))
            {
                MessageBox.Show("Price Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            bool convertStatus = float.TryParse(PriceTextBox.Text, out float price);

            if (!convertStatus)
            {
                MessageBox.Show("Price Must Be A Number!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (price <= 0)
            {
                MessageBox.Show("Price Must Greater Than 0!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            bool isValidStartTime = DateTime.TryParseExact(
             StartTimeTextBox.Text,
             "dd/MM/yyyy",
             CultureInfo.InvariantCulture,
             DateTimeStyles.None,
             out DateTime StartTime);

            if (!isValidStartTime)
            {
                MessageBox.Show("Start Time Must Be Format dd/MM/yyyy!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            };

            bool isValidFinishTime = DateTime.TryParseExact(
             FinishTimeTextBox.Text,
             "dd/MM/yyyy",
             CultureInfo.InvariantCulture,
             DateTimeStyles.None,
             out DateTime FinishTime);

            if (!isValidFinishTime)
            {
                MessageBox.Show("Finish Time Must Be Format dd/MM/yyyy!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            };

            if (StartTime >= FinishTime)
            {
                MessageBox.Show("Finish Time Must Be After Start Time.!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            };

            convertStatus = int.TryParse(ParticipantsTextBox.Text, out int NumberOfParticipants);

            if (!convertStatus)
            {
                MessageBox.Show("Number Of Participants Must Be A Number!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (NumberOfParticipants <= 0)
            {
                MessageBox.Show("Number Of Participants Must Greater Than 0!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (EditedOne != null)
            {
                TourIDTextBox.Text = EditedOne.TourId.ToString();
                TourIDTextBox.IsEnabled = false;
                TourNameTextBox.Text = EditedOne.TourName;
                PriceTextBox.Text = EditedOne.Price.ToString();
                StartTimeTextBox.Text = EditedOne.StartTime;
                FinishTimeTextBox.Text = EditedOne.FinishTime;
                ParticipantsTextBox.Text = EditedOne.NumberOfParticipate.ToString();
            }
        }
    }
}
