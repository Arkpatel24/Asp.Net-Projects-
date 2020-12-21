using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProgram
{
    class Logins
    {
        private int _ID;
        private string _userName;
        private string _password;
        private int _superUser;


        public Logins(int id, string userName, string password, int superUser)
        {
            _ID = id;
            _userName = userName;
            _password = password;
            _superUser = superUser;
        }

        public Logins(int id, string password, int superUser)
        {
            _ID = id;
            _password = password;
            _superUser = superUser;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

     

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int SuperUser
        {
            get { return _superUser; }
            set { _superUser = value; }
        }

     
    }
}
