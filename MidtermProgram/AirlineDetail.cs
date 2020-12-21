using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProgram
{
    class AirlineDetail
    {
        private int _ID;
        private string _name;
        private string _airplane;
        private int _seatsAvailable;
        private string _mealAvailable;

        public AirlineDetail()
        { 
        }
        public AirlineDetail(int id, string name, string airplane, int seatAvail,string mealAvail)
        {
             _ID = id;
             _name= name;
            _airplane = airplane;
            _seatsAvailable = seatAvail;
            _mealAvailable = mealAvail;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Airplane
        {
            get { return _airplane; }
            set { _airplane = value; }
        }

        public int SeatsAvailable
        {
            get { return _seatsAvailable; }
            set { _seatsAvailable = value; }
        }
        public string MealAvailable
        {
            get { return _mealAvailable; }
            set { _mealAvailable = value; }
        }
    }
}
