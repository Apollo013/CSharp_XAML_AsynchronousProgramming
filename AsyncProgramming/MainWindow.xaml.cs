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

namespace AsyncProgramming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBasicTasks_Click(object sender, RoutedEventArgs e)
        {
            this.WinFrame.Navigate(new Uri("Views/BasicTasks.xaml", UriKind.Relative));
        }

        private void btnCancelToken_Click(object sender, RoutedEventArgs e)
        {
            this.WinFrame.Navigate(new Uri("Views/CancellationTokens.xaml", UriKind.Relative));
        }

        private void btnCallback_Click(object sender, RoutedEventArgs e)
        {
            this.WinFrame.Navigate(new Uri("Views/AsyncCallbacks.xaml", UriKind.Relative));
        }

        private void btnFileIO_Click(object sender, RoutedEventArgs e)
        {
            this.WinFrame.Navigate(new Uri("Views/FileIO.xaml", UriKind.Relative));
        }
    }
}
