using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProgram
{
    class Customer
    {
        private int _ID;
        private string _name;
        private string _address;
        private string _email;
        public string _phone;


        public Customer(int id, string name, string address, string email, string phone)
        {
            _ID = id;
            _name = name;
            _address = address;
            _email = email;
            _phone = phone;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

    }
}
