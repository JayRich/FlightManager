using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FlightManager;

namespace ADO
{
    public interface IFlightDAO
    {
  
        public void AddFlightToDB(Flight ff);

        public IEnumerable<Flight> GetFlights(int? fn, string? dd, string? ad, string? dt, string? at, string? da, string? aa, int? pl, int? cp);


        public bool Delete_Flight(int f_num);

        public bool Update_Flight(int? fn, string? dd, string? ad, string? dt, string? at, string? da, string? aa, int? pl, int? cp);

        public int Count_Flights();

        public int Add_Passenger_To_Flight(int f_num);

        public void Remove_Passenger_From_Flight(int f_num);

        public Flight GetFlight(int f_num);


    }
}
