using CRUDMVVMWPF.ViewModels;
using System.Windows;

namespace CRUDMVVMWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var viewModel = new MainViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
