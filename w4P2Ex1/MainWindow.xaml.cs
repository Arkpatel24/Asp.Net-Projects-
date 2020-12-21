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

namespace w4P2Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string user = "ark";
        string pass = "patel";
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Copy_Click(object sender, RoutedEventArgs e)
        {
            if ((tbuser.Text == user) && (tbpass.Password == pass))
            {
                var result = MessageBox.Show("Correct login", "Login Successfull", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Incorrect login", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
