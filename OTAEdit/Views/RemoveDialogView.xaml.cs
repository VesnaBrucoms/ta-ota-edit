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
    /// Interaction logic for RemoveDialogView.xaml
    /// </summary>
    public partial class RemoveDialogView : Window
    {
        public RemoveDialogView()
        {
            InitializeComponent();
        }

        public void WindowRemove_Click(object sender, RoutedEventArgs e)
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
