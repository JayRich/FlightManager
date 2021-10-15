using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO
{
    public class Flight
    {
        public int Flight_Number { get; set; }

        public string Departure_Date { get; set; }

        public string Arrival_Date { get; set; }

        public string Departure_Time { get; set; }

        public string Arrival_Time { get; set; }

        public string Departure_Airport { get; set; }

        public string Arrival_Airport { get; set; }

        public int Passenger_Limit { get; set; }

        public int Current_Passengers { get; set; }


        public Flight() { }

        public Flight(int Flight_Number, string Departure_Date, string Arrival_Date, string Departure_Time, string Arrival_Time, string Departure_Airport, string Arrival_Airport, int Passenger_Limit, int Current_Passengers)
        {
           
            this.Flight_Number = Flight_Number;
            this.Departure_Date = Departure_Date;
            this.Arrival_Date = Arrival_Date;
            this.Departure_Time = Departure_Time;
            this.Arrival_Time = Arrival_Time;
            this.Departure_Airport = Departure_Airport;
            this.Arrival_Airport = Arrival_Airport;
            this.Passenger_Limit = Passenger_Limit;
            this.Current_Passengers = Current_Passengers;
        } 

    }
}

