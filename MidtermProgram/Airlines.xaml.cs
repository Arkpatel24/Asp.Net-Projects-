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
    /// Interaction logic for Airlines.xaml
    /// </summary>
    public partial class Airlines : Window
    {
        private Queue<AirlineDetail> air = new Queue<AirlineDetail>();
        string airplane,meal;
        public Airlines()
        {
            InitializeComponent();
            air.Enqueue(new AirlineDetail(0, "Kingfisher", "AirBus 320",100,"Salad"));
            air.Enqueue(new AirlineDetail(1, "Qatar", "Boing 777", 180, "Salad"));
            air.Enqueue(new AirlineDetail(2, "Emirates", "AirBus 320", 200, "Chicken"));
            air.Enqueue(new AirlineDetail(3, "Air India", "Boing 777", 480, "Salad"));
            air.Enqueue(new AirlineDetail(4, "Air Canada", "AirBus 320", 70, "Chicken"));

            var airline = from a in air
                          select a.name;
            lstAirlines.DataContext = airline;

        }

        private void lstAirlines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = lstAirlines.SelectedIndex;
            var selectedAirlines = from ai in air
                               where ai.ID == a
                               select ai;

            foreach (var s in selectedAirlines)
            {
                tbName.Text = s.name;
                txtAirplane.Text = s.Airplane;
                tbSeat.Text = s.SeatsAvailable.ToString();
                txtMeal.Text = s.MealAvailable;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
           

            if (tbName.Text == "" || tbSeat.Text == ""  )
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                air.Enqueue(new AirlineDetail(air.Count, tbName.Text,
                            airplane,Int16.Parse(tbSeat.Text),meal));

                var names = from a in air
                            select a.name;

                lstAirlines.DataContext = names;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update?", "Update Data", MessageBoxButton.YesNo,
               MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                AirlineDetail a = new AirlineDetail(lstAirlines.SelectedIndex, tbName.Text,
                airplane, Int16.Parse(tbSeat.Text), meal);


                var names = from ai in air
                            select ai.name;

                lstAirlines.DataContext = names;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete?", "Delete Data", MessageBoxButton.YesNo,
               MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                air.Dequeue();

                var names = from a in air
                            select a.name;

                lstAirlines.DataContext = names;
            }
        }

        private void r1_Checked(object sender, RoutedEventArgs e)
        {
            airplane = "Boing 777";
        }

        private void r2_Checked(object sender, RoutedEventArgs e)
        {
            airplane = "Airbus 320";
        }

        private void r3_Checked(object sender, RoutedEventArgs e)
        {
            meal = "Salad";
        }

        private void r4_Checked(object sender, RoutedEventArgs e)
        {
            meal = "Chicken";
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