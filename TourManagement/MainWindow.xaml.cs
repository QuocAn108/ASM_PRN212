using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourManagement.BLL.Services;
using TourManagement.DAL.Model;

namespace TourManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LocationService _service = new();
        private TourService _tourService = new();
        public Member CurAccount { get; set; }
        public MainWindow()
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

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            ViewLocation v = new();
            v.ShowDialog();
        }
        private void ViewTDButton_Click(object sender, RoutedEventArgs e)
        {
            ViewTourDestination v1 = new();
            v1.ShowDialog();
        }

        private void FillDataGrid(List<Tour> list)
        {
            // xóa lưới cũ, đổ lưới mới
            TourDataGrid.ItemsSource = null; // xóa data cũ
            TourDataGrid.ItemsSource = list;
        }


        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow d = new();
            d.ShowDialog();
            FillDataGrid(_tourService.GetAllTour());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Tour? selected = TourDataGrid.SelectedItem as Tour;
            if (selected == null)
            {
                // chửi việc kh có chịu bấm 1 dòng mà bày đặt đòi edit
                MessageBox.Show("Please select an Tour Before Updated", "Select one Tour to update!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;// kh chọn 1 dòng, thoát, không làm gì cả

            }
            DetailWindow d = new();
            d.EditedOne = selected;
            d.ShowDialog();
            FillDataGrid(_tourService.GetAllTour());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Tour? selected = TourDataGrid.SelectedItem as Tour; // set selected is a variable that you had clicked in screen
            if (selected == null)
            {
                MessageBox.Show("Please select an Tour Before Deleted", "Select one Tour to Deleted!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                // if you havent clicked anything, show warning
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Are You Sure Delete???", "Confirm Delete???", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // before delete, require confirm and permision to delete!!
            if (answer == MessageBoxResult.No)
                return;
            _tourService.DeleteTour(selected);
            FillDataGrid(_tourService.GetAllTour()); //refresh datagrid screen to renew grid

        }

        private void ViewUserButton_Click(object sender, RoutedEventArgs e)
        {
            ViewUser v3 = new();
            v3.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HelloMSGLabel.Content = "Hello, " + CurAccount.FullName;
            FillDataGrid(_tourService.GetAllTour());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string location = LocationTextBox.Text.Trim();
            string tourName = TourTextBox.Text.Trim();
            string startDate = StartDateTextBox.Text.Trim();  
            string endDate = EndDateTextBox.Text.Trim();     

            if (ValidateSearchInput(location, tourName, startDate, endDate))
            {
                var tours = _tourService.GetAllTour();

                var filteredTours = tours.Where(tour =>
           (string.IsNullOrEmpty(location) ||
               tour.TourDestinations.Any(td => td.Location.LocationName.ToLower().Contains(location.ToLower()))) && 
           (string.IsNullOrEmpty(tourName) || tour.TourName.ToLower().Contains(tourName.ToLower())) &&
           (string.IsNullOrEmpty(startDate) || tour.StartTime.Contains(startDate)) && 
           (string.IsNullOrEmpty(endDate) || tour.FinishTime.Contains(endDate)) 
       ).ToList();

                FillDataGrid(filteredTours);
            }
        }
        private bool ValidateSearchInput(string location, string tourName, string startDate, string endDate)
        {
            if (HasSpecialCharacters(location) || HasSpecialCharacters(tourName))
            {
                MessageBox.Show("Địa chỉ và tên tour không được chứa ký tự đặc biệt.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!string.IsNullOrEmpty(startDate))
            {
                if (!IsValidDateFormat(startDate))
                {
                    MessageBox.Show("Ngày đi không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                DateTime parsedStartDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", null);

                if (parsedStartDate < DateTime.Now.Date)
                {
                    MessageBox.Show("Ngày đi không thể là ngày trong quá khứ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                if (parsedStartDate < DateTime.Now.AddDays(4).Date)
                {
                    MessageBox.Show("Ngày đi phải sau ngày hiện tại ít nhất 4 ngày.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                if (!IsValidDateFormat(endDate))
                {
                    MessageBox.Show("Ngày về không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                DateTime parsedEndDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", null);

                if (parsedEndDate < DateTime.Now.Date)
                {
                    MessageBox.Show("Ngày về không thể là ngày trong quá khứ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                DateTime parsedStartDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", null);
                DateTime parsedEndDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", null);

                if (parsedEndDate <= parsedStartDate.AddDays(3))
                {
                    MessageBox.Show("Ngày về phải sau ngày đi ít nhất 3 ngày.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            return true;
        }

        private bool IsValidDateFormat(string date)
        {
            DateTime tempDate;
            return DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out tempDate);
        }

        private bool HasSpecialCharacters(string input)
        {
            return input.Any(c => !Char.IsLetterOrDigit(c) && c != ' ');
        }

    }
}