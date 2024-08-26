using System.Windows;
using FaceDetection.ViewModel;

namespace FaceDetection
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
        }
    }
}