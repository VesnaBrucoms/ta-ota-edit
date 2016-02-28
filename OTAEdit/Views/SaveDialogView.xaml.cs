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

namespace OTAEdit.Views
{
    /// <summary>
    /// Interaction logic for SaveDialogView.xaml
    /// </summary>
    public partial class SaveDialogView : Window
    {
        public SaveDialogView()
        {
            InitializeComponent();
        }

        public void WindowSave_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Command.Execute(btn.CommandParameter);
            Close();
        }

        public void WindowDontSave_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Command.Execute(btn.CommandParameter);
            Close();
        }

        public void WindowCancel_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Command.Execute(btn.CommandParameter);
            Close();
        }
    }
}
