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

namespace MidtermProgram
{
    /// <summary>
    /// Interaction logic for Flights.xaml
    /// </summary>
    public partial class Flights : Window
    {
        private List<FlightDetail> flight = new List<FlightDetail>();
        
        public Flights()
        {
            InitializeComponent();

            flight.Add(new FlightDetail(0, 0, "Brampton", "British Columbia", "25-Jun-2020", 15));
            flight.Add(new FlightDetail(1, 1, "Ottawa", "Toronto", "30-Jun-2020", 7));
            flight.Add(new FlightDetail(2, 2, "Toronta", "NovaScotia", "5-July-2020", 14));
            flight.Add(new FlightDetail(3, 3, "Las Vegas", "Toronto", "10-July-2020", 17));
            flight.Add(new FlightDetail(4, 4, "Calgary", "Ottawa", "20-July-2020", 7));

            var fliName = from fl in flight
                          select fl.DepartureCity;

            lstFlight.DataContext = fliName;

        }
        private void lstFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int fli = lstFlight.SelectedIndex;
            var selectFlight = from fl in flight
                               where fl.ID == fli
                               select fl;

            foreach (var f in selectFlight)
            {
                txtAirID.Text = f.AirlineID.ToString();
                txtDeptCity.Text = f.DepartureCity;
                txtDestCity.Text = f.DestinationCity;
                txtDeptDate.Text = f.DepartureDate;
                txtFlighTime.Text = f.FlightTime.ToString();

            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtAirID.Text == "" || txtDeptCity.Text == "" ||
                txtDestCity.Text == "" || txtDeptDate.Text == "" ||
               txtFlighTime.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                flight.Add(new FlightDetail(flight.Count, Int16.Parse(txtAirID.Text), txtDeptCity.Text, txtDestCity.Text,
                            txtDeptDate.Text, double.Parse(txtFlighTime.Text)));

                var fli = from f in flight
                              select f.DepartureCity;

                lstFlight.DataContext = fli;
            }

        }
        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update?", "Update Data", MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                FlightDetail ft = new FlightDetail(lstFlight.SelectedIndex, Int16.Parse(txtAirID.Text), txtDeptCity.Text, txtDestCity.Text, txtDeptDate.Text, double.Parse(txtFlighTime.Text));
                flight[lstFlight.SelectedIndex] = ft;

                var fli = from f in flight
                               select f.DepartureCity;

                lstFlight.DataContext = fli;
            }

        }
        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Delete Data", MessageBoxButton.YesNo,
               MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                flight.RemoveAt(lstFlight.SelectedIndex);

                for (int i = 0; i < flight.Count; i++)
                    flight[i].ID = i;

                var fli = from f in flight
                               select f.DepartureCity;

                lstFlight.DataContext = fli;
            }
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
