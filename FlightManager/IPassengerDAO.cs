using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FlightManager
{
    interface IPassengerDAO
    {

        public void AddPassengerToDB(string id, string n, string j, string e, string a, string bn, string fn);

        public IEnumerable<Passenger> GetPassengers(int? id, string? n, string? j, string? e, int? a, int? bn, int? fn);
        public bool Delete_Passenger(int id);

        public bool Update_Passenger(int id, string? n, string? j, string? e, int? a, int? fn);

        public int Count_Passengers();

        public Passenger GetPassenger(int id);


    }
}
