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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        private List<Customer> cust = new List<Customer>();
        public Customers()
        {
            InitializeComponent();
            cust.Add(new Customer(0, "Ark", "Brampton", "ark@gmail.com", "43723544546"));
            cust.Add(new Customer(1, "Rutul", "Toronto", "rutul@gmail.com", "469855452530"));
            cust.Add(new Customer(2, "Paresh", "Vaughan", "paresh@gmail.com", "9874411230"));
            cust.Add(new Customer(3, "Rutvik", "Berrie", "rutvik@gmail.com", "78644545599"));
            cust.Add(new Customer(4, "Bhavik", "Ottawa", "bhavik@gmail.com", "774245444740"));

            var custnames = from c in cust
                            select c.Name;

            lstCustomer.DataContext = custnames;
        }
        private void lstCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstCustomer.SelectedIndex;
            var selectedCustomer = from c in cust
                                   where c.ID == i
                                   select c;

            foreach (var c in selectedCustomer)
            {
                tbName.Text = c.Name;
                tbAddress.Text = c.Address;
                tbEmail.Text = c.Email;
                tbPhone.Text = c.Phone;
            }
        }


        public void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbName.Text == "" ||
               tbAddress.Text == "" || tbPhone.Text == "")
            {
                MessageBox.Show("Please Enter the value in the textbox", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cust.Add(new Customer(cust.Count, tbName.Text, tbAddress.Text, tbEmail.Text,
                            tbPhone.Text));

                var custNames = from c in cust
                                select c.Name;

                lstCustomer.DataContext = custNames;
            }

        }
        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update?", "Update Data", MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Customer c1 = new Customer(lstCustomer.SelectedIndex, tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text);
                cust[lstCustomer.SelectedIndex] = c1;

                var custNames = from c in cust
                                select c.Name;

                lstCustomer.DataContext = custNames;
            }

        }
        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Delete Data", MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                cust.RemoveAt(lstCustomer.SelectedIndex);

                for (int i = 0; i < cust.Count; i++)
                    cust[i].ID = i;

                var custNames = from c in cust
                                select c.Name;

                lstCustomer.DataContext = custNames;
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
