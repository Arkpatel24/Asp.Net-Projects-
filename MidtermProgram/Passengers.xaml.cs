using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Passengers.xaml
    /// </summary>
    public partial class Passengers : Window
    {
        private Stack<Passenger> pass= new Stack<Passenger>();
        public Passengers()
        {
            InitializeComponent();
            pass.Push(new Passenger(0, 0, 0));
            pass.Push(new Passenger(1, 1, 1));
            pass.Push(new Passenger(2, 2, 2));
            pass.Push(new Passenger(3, 3, 3));
            pass.Push(new Passenger(4, 4, 4));
            pass.Push(new Passenger(5, 5, 5));
           

            var pas = from p in pass
                       select p.ID;
            lstPassengers.DataContext = pas;
        }

        private void lstPassengers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pas = lstPassengers.SelectedIndex;
            var passenger = from p in pass
                            where p.ID == pas
                            select p;

            foreach (var p in passenger)
            {
                tbID.Text = p.ID.ToString();
                tbCustomerId.Text = p.CustomerID.ToString();
                tbFlightId.Text = p.FlightID.ToString();
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbID.Text == "" || tbCustomerId.Text == "" ||
                tbFlightId.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                pass.Push(new Passenger(Int16.Parse(tbID.Text), Int16.Parse(tbCustomerId.Text), Int16.Parse(tbFlightId.Text)));

                var pas = from p in pass
                           select p.ID;

                lstPassengers.DataContext = pas;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update?", "Update Data", MessageBoxButton.YesNo,
               MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Passenger p = new Passenger(Int16.Parse(tbID.Text), Int16.Parse(tbCustomerId.Text), Int16.Parse(tbFlightId.Text));
               
      
                var pas = from pa in pass
                            select pa.ID;

                lstPassengers.DataContext = pas;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Delete Data", MessageBoxButton.YesNo,
               MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                pass.Pop();


                var pas = from p in pass
                          select p.ID;

                lstPassengers.DataContext = pas;
            }
        }
        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
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

