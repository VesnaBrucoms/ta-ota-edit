using OTAEdit.ViewModels;
using OTAEdit.ViewModels.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OTAEdit.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            WindowViewLoaderService.GetInstance.SetMainWindow = this;
            Loaded += OnMainWindowLoaded;
        }

        public void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            viewModel = DataContext as MainWindowViewModel;
            Closing += viewModel.OnViewClosing;
        }

        public void ApplicationClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
