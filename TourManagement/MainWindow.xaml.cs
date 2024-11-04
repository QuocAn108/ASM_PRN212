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
        public Member CurAccount { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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

        private void ViewUserButton_Click(object sender, RoutedEventArgs e)
        {
            ViewUser v3 = new();
            v3.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HelloMSGLabel.Content = "Hello, " + CurAccount.FullName;
        }
    }
}