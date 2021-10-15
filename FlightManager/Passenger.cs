using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FlightManager
{
    public class Passenger
    {
       
   
            public int Id { get; set; }

            public string Name { get; set; }

            public string Job { get; set; }

            public string Email { get; set; }

            public int Age { get; set; }

            public int Booking_Number { get; set; }

            public int Flight_Number { get; set; }

           


            public Passenger() { }

            public Passenger(int Id, string Name, string Job, string Email, int Age, int Booking_Number, int Flight_Number)
            {

                this.Id = Id;
                this.Name = Name;
                this.Job = Job;
                this.Email = Email;
                this.Age = Age;
                this.Booking_Number = Booking_Number;
                this.Flight_Number = Flight_Number;
               
            }

        }
  
}
