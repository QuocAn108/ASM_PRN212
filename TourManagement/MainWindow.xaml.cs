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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TourDataGrid.ItemsSource = _tourService.GetAllTour();
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
            Tour? selected = TourDataGrid.SelectedItem as Tour;
            if (selected == null)
            {
                // chửi việc kh có chịu bấm 1 dòng mà bày đặt đòi edit
                MessageBox.Show("Please select an Tour Before Deleted", "Select one Tour to Deleted!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;// kh chọn 1 dòng, thoát, không làm gì cả
            }

            MessageBoxResult answer = MessageBox.Show("Are You Sure Delete???", "Confirm Delete???", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;
            _tourService.DeleteTour(selected);
            // xóa xong, phải f5 lại cái grid, vì grid chơi với ram, đâu có đồng bộ với dtb sau khi bị xóa
            // cực kì quan trọng: tạo mới, update, delete đều phải f5 cái grid, chưa kể mở màn hình này cũng phải load grid, trong giang hồ, cái nào lặp đi lặp lạo thì ta tách hàm
            // hàm này trợ giúp các hàm khác, hàm helper
            FillDataGrid(_tourService.GetAllTour());

        }
    }
}