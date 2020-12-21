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

namespace MidtermProgram
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
        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers();
            c.Title = "Customre Page";
            c.ShowDialog();
        }

        private void btnFlights_Click(object sender, RoutedEventArgs e)
        {
            Flights f = new Flights();
            f.Title = "Flight Page";
            f.ShowDialog();
        }

        private void btnAirlines_Click(object sender, RoutedEventArgs e)
        {
            Airlines a = new Airlines();
            a.Title = "Customre Page";
            a.ShowDialog();
        }

        private void btnPassengers_Click(object sender, RoutedEventArgs e)
        {
            Passengers p = new Passengers();
            p.Title = "Customre Page";
            p.ShowDialog();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
                ContactUs c = new ContactUs();
                c.Title = "Contact us";
                c.ShowDialog();
            
        }
    }
}
