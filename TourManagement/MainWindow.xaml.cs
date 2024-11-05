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
    }
}