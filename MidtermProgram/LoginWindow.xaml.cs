
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Dictionary<string, Logins> log = new Dictionary<string, Logins>();
        private int _superUser;

        public int superUser
        {
            get { return _superUser; }
            set { _superUser = value; }
        }
        public LoginWindow()
        {
            InitializeComponent();

            log["ark"] = new Logins(1, "patel", 1);
            log["pinak"] = new Logins(2, "trivedi", 0);
            log["jeet"] = new Logins(3, "thaker", 0);
            log["deep"] = new Logins(4, "patel", 1);
            log["pradeep"] = new Logins(5, "mahi", 1);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool login = (from l in log
                               where l.Key == txtUser.Text && l.Value.Password == txtPass.Password
                               select true).SingleOrDefault();

            superUser = (from l in log
                         where l.Key == txtUser.Text && l.Value.Password == txtPass.Password
                         select l.Value.SuperUser).SingleOrDefault();

            if (login == true)
            {
                if (superUser == 1)
                {
                    MainWindow m = new MainWindow();
                    m.Title = "Welcome SuperUser";
                    m.ShowDialog();
                }
                else
                {
                    MainWindow m = new MainWindow();
                    m.Title = "Welcome";
                    m.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Cancle", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
