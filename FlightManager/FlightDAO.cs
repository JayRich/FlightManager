using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FlightManager;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ADO
{
    public class FlightDAO : IFlightDAO
    {
        

        private string connString = "Data Source=DESKTOP-VVR1VUV;Initial Catalog=Flights;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        
      
        // add a new flight to the database
        public void AddFlightToDB(Flight ff)
        {

            Flight temp = new Flight();
            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand("Insert into dbo.Flights (Flight_Number, Departure_Date, Arrival_Date, Departure_Time, Arrival_Time, Departure_Airport, Arrival_Airport, Passenger_Limit, Current_Passengers) values (@Flight_Number, @Departure_Date, @Arrival_Date, @Departure_Time, @Arrival_Time, @Departure_Airport, @Arrival_Airport, @Passenger_Limit, @Current_Passengers)", conn);

                cmd.Parameters.AddWithValue("@Flight_Number", ff.Flight_Number);
                cmd.Parameters.AddWithValue("@Departure_Date", ff.Departure_Date);
                cmd.Parameters.AddWithValue("@Arrival_Date", ff.Arrival_Date);
                cmd.Parameters.AddWithValue("@Departure_Time", ff.Departure_Time);
                cmd.Parameters.AddWithValue("@Arrival_Time", ff.Arrival_Time);
                cmd.Parameters.AddWithValue("@Departure_Airport", ff.Departure_Airport);
                cmd.Parameters.AddWithValue("@ArrivaL_Airport", ff.Arrival_Airport);
                cmd.Parameters.AddWithValue("@Passenger_Limit", ff.Passenger_Limit);
                cmd.Parameters.AddWithValue("@Current_Passengers", ff.Current_Passengers);
                try
                {
                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all the flights!\n{0}", ex.Message);
                    
                }
                finally
                {
                    conn.Close();
                }
            }
            



        }


        // builds a select query based on user input with flags and if statements
        public IEnumerable<Flight> GetFlights(int? fn, string? dd, string? ad, string? dt, string? at, string? da, string? aa, int? pl, int? cp)
        {
            List<Flight> FlightList = new List<Flight>();

            // will count the number of values the user input 
            int num_of_nulls = 0;
            // if input values isn't null then increment to determine how many fields to have in the query string
            if (fn != null)
            {
                num_of_nulls++;
            }
            if (dd != null)
            {
                num_of_nulls++;
            }
            if (ad != null)
            {
                num_of_nulls++;
            }
            if (dt != null)
            {
                num_of_nulls++;
            }
            if (at != null)
            {
                num_of_nulls++;
            }
            if (da != null)
            {
                num_of_nulls++;
            }
            if (aa != null)
            {
                num_of_nulls++;
            }
            if (pl != null)
            {
                num_of_nulls++;
            }
            if (cp != null)
            {
                num_of_nulls++;
            }

            string query = "SELECT * FROM dbo.Flights where ";
            // if all values are nulls then return a select * to All_Flights controller action
            if (num_of_nulls == 0)
            {
                query = "SELECT * FROM dbo.Flights";
            }
            bool is_first_condition = true;
          
            int find_last_condition = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // if user input value wasn't null then we need to add that field to the where condition with appropriate syntax
                if (fn != null)
                {
                    
                    if (is_first_condition == true)
                    {
                        query += "Flight_Number = @ffn";
                    }
                   
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Flight_Number = @ffn";
                       
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (dd != null)
                {
                    

                    if (is_first_condition == true)
                    {
                        query += "Departure_Date = @ddd";
                    }
                   
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Departure_Date = @ddd";
                      
                    }
                    is_first_condition = false;
                    find_last_condition++;

                }

                if (ad != null)
                {
                    
                    if (is_first_condition == true)
                    {
                        query += "Arrival_Date = @aad";
                    }
                  

                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Arrival_Date = @aad";
                       
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (dt != null)
                {
                    

                    if (is_first_condition == true)
                    {
                        query += "Departure_Time = @ddt";
                    }
                   
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Departure_Time = @ddt";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (at != null)
                {
                    
                    if (is_first_condition == true)
                    {
                        query += "Arrival_Time = @aat";
                    }
                   
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Arrival_Time = @aat";
                       
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (da != null)
                {
                    

                    if (is_first_condition == true)
                    {
                        query += "Departure_Airport = @dda";
                    }
                  
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Departure_Airport = @dda";
                       
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (aa != null)
                {
                   


                    if (is_first_condition == true)
                    {
                        query += "Arrival_Airport = @aaa";
                    }
                 
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Arrival_Airport = @aaa";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (pl != null)
                {
                   

                    if (is_first_condition == true)
                    {
                        query += "Passenger_Limit = @ppl";
                    }
                 
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Passenger_Limit = @ppl";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (cp != null)
                {
                  

                    if (is_first_condition == true)
                    {
                        query += "Current_Passengers = @ccp";
                    }
                   
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Current_Passengers = @ccp";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }


                SqlCommand cmd = new SqlCommand(query, conn);
                // if field wasnt null then we need to add it to the select query as paramaterized input 
                if (fn != null)
                {
                    cmd.Parameters.AddWithValue("@ffn", fn);
                }

                if (dd != null)
                {
                    cmd.Parameters.AddWithValue("@ddd", dd);
                }

                if (ad != null)
                {
                    cmd.Parameters.AddWithValue("@aad", ad);
                }

                if (dt != null)
                {
                    cmd.Parameters.AddWithValue("@ddt", dt);
                }

                if (at != null)
                {
                    cmd.Parameters.AddWithValue("@aat", at);
                }

                if (da != null)
                {
                    cmd.Parameters.AddWithValue("@dda", da);
                }

                if (aa != null)
                {
                    cmd.Parameters.AddWithValue("@aaa", aa);
                }


                if (pl != null)
                {
                    cmd.Parameters.AddWithValue("@ppl", pl);
                }


                if (cp != null)
                {
                    cmd.Parameters.AddWithValue("@ccp", cp);
                }
           
            try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        string fnn = reader["Flight_Number"].ToString();
                        string ddd = reader["Departure_Date"].ToString();
                        string add = reader["Arrival_Date"].ToString();
                        string dtt = reader["Departure_Time"].ToString();
                        string att = reader["Arrival_Time"].ToString();
                        string daa = reader["Departure_Airport"].ToString();
                        string aaa = reader["Arrival_Airport"].ToString();
                        string ppl = reader["Passenger_Limit"].ToString();
                        string ccp = reader["Current_Passengers"].ToString();





                        Flight temp = new Flight(Convert.ToInt32(fnn), ddd, add, dtt, att, daa, aaa, Convert.ToInt32(ppl), Convert.ToInt32(ccp));





                        FlightList.Add(temp);
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all flight!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }



            return FlightList;

        }

        // deletes a flight and the database uses cascade delete to delete all passengers from passengers table that had that flight number
        public bool Delete_Flight(int f_num)
        {

            Flight temp = new Flight();
            
         
            using (SqlConnection conn2 = new SqlConnection(connString))
            {


                SqlCommand cmd2 = new SqlCommand("Delete from dbo.Flights where Flight_Number = @fd", conn2);

                cmd2.Parameters.AddWithValue("@fd", f_num);


                try
                {
                    conn2.Open();

                    cmd2.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all the flights!\n{0}", ex.Message);
                    return false;
                }
                finally
                {
                    conn2.Close();
                }
            }
            return true;


        }

       
        // builds an update query using if statements based on user input. Flight number can never be changed. Also must use flight number for every update statement.
        public bool Update_Flight(int? fn, string? dd, string? ad, string? dt, string? at, string? da, string? aa, int? pl, int? cp)
        {
            Flight temp = new Flight();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // get current flight row data for update query
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Flights WHERE Flight_Number = @fnn", conn);
                cmd.Parameters.AddWithValue("@fnn", fn);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fnn = reader["Flight_Number"].ToString();
                        string ddd = reader["Departure_Date"].ToString();
                        string add = reader["Arrival_Date"].ToString();
                        string dtt = reader["Departure_Time"].ToString();
                        string att = reader["Arrival_Time"].ToString();
                        string daa = reader["Departure_Airport"].ToString();
                        string aaa = reader["Arrival_Airport"].ToString();
                        string ppl = reader["Passenger_Limit"].ToString();
                        string ccp = reader["Current_Passengers"].ToString();

                        temp.Flight_Number = Convert.ToInt32(fnn);
                        temp.Departure_Date = ddd;
                        temp.Arrival_Date = add;
                        temp.Departure_Time = dtt;
                        temp.Arrival_Time = att;
                        temp.Departure_Airport = daa;
                        temp.Arrival_Airport = aaa;
                        temp.Passenger_Limit = Convert.ToInt32(ppl);
                        temp.Current_Passengers = Convert.ToInt32(ccp);




                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not update the flight!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            using (SqlConnection conn2 = new SqlConnection(connString))
            {

                SqlCommand cmd2 = new SqlCommand("Update dbo.Flights set Flight_Number = @fnn, Departure_Date = @dd, Arrival_Date = @ad, Departure_Time = @dt, Arrival_Time = @at, Departure_Airport = @da, Arrival_Airport = @aa, Passenger_Limit = @pl, Current_Passengers = @cp where Flight_Number = @fn", conn2);


                cmd2.Parameters.AddWithValue("@fnn", fn);
                // if value wasnt null then change column value to the new value
                if (dd != null)
                {
                    cmd2.Parameters.AddWithValue("@dd", dd);
                }

                // if user input was blank then just update the column with the same value it had before. doesn't change.
                if (dd == null)
                {
                    cmd2.Parameters.AddWithValue("@dd", temp.Departure_Date);
                }
                if (ad != null)
                {
                    cmd2.Parameters.AddWithValue("@ad", ad);
                }
                if (ad == null)
                {
                    cmd2.Parameters.AddWithValue("@ad", temp.Arrival_Date);
                }
                if (dt != null)
                {
                    cmd2.Parameters.AddWithValue("@dt", dt);
                }
                if (dt == null)
                {
                    cmd2.Parameters.AddWithValue("@dt", temp.Departure_Time);
                }
                if (at != null)
                {
                    cmd2.Parameters.AddWithValue("@at", at);
                }
                if (at == null)
                {
                    cmd2.Parameters.AddWithValue("@at", temp.Arrival_Time);
                }

                if (da != null)
                {
                    cmd2.Parameters.AddWithValue("@da", da);
                }
                if (da == null)
                {
                    cmd2.Parameters.AddWithValue("@da", temp.Departure_Airport);
                }
                if (aa != null)
                {
                    cmd2.Parameters.AddWithValue("@aa", aa);
                }
                if (aa == null)
                {
                    cmd2.Parameters.AddWithValue("@aa", temp.Arrival_Airport);
                }
                if (pl != null)
                {
                    cmd2.Parameters.AddWithValue("@pl", pl);
                }
                if (pl == null)
                {
                    cmd2.Parameters.AddWithValue("@pl", temp.Passenger_Limit);
                }
                if (cp != null)
                {
                    cmd2.Parameters.AddWithValue("@cp", cp);
                }
                if (cp == null)
                {
                    cmd2.Parameters.AddWithValue("@cp", temp.Current_Passengers);
                }

                cmd2.Parameters.AddWithValue("@fn", fn);

                try
                {
                    conn2.Open();

                    cmd2.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not update flight!\n{0}", ex.Message);
                    return false;
                }
                finally
                {
                    conn2.Close();
                }

                return true;

            }


           

        }
    

        // counts the total flights for user display on home page
        public int Count_Flights()
        {
            int num_of_flights = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Flights", conn);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    // counts number of rows returned
                    while (reader.Read())
                    {
                        num_of_flights++;
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all the flights!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }



            return num_of_flights;
        }

        // when adding a passenger to a flight the current_passengers amount must be incremented by 1
        public int Add_Passenger_To_Flight(int f_num)
        {
           Flight temp = new Flight();
            int check_capacity;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // get new flight row information for updating
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Flights WHERE Flight_Number = @f_n", conn);

                cmd.Parameters.AddWithValue("@f_n", f_num);
 

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fn = reader["Flight_Number"].ToString();
                        int fnc = Convert.ToInt32(fn);
                        string dd = reader["Departure_Date"].ToString();
                        string ad = reader["Arrival_Date"].ToString();
                        string dt = reader["Departure_Time"].ToString();
                        string at = reader["Arrival_Time"].ToString();
                        string da = reader["Departure_Airport"].ToString();
                        string aa = reader["Arrival_Airport"].ToString();

                        string pl = reader["Passenger_Limit"].ToString();
                        int plc = Convert.ToInt32(pl);
                        string cp = reader["Current_Passengers"].ToString();
                        int cpc = Convert.ToInt32(cp);
                       // make new current_passengers amount increased by 1
                        
                        check_capacity = cpc + 1;

                        // check the passenger limit
                        if (check_capacity > plc)
                        {
                            return -1;
                        }

                      
                        temp.Flight_Number = fnc;
                        temp.Departure_Date = dd;
                        temp.Arrival_Date = ad;
                        temp.Departure_Time = dt;
                        temp.Arrival_Time = at;
                        temp.Departure_Airport = da;
                        temp.Arrival_Airport = aa;
                        temp.Passenger_Limit = plc;
                        temp.Current_Passengers = check_capacity;



                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not find the flight!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                // update the new flight current passenger amount
                SqlCommand cmd1 = new SqlCommand("Update dbo.Flights set Current_Passengers = @ccp where Flight_Number = @fnn", conn1);

                // parameterized query for safety again sql injections
                cmd1.Parameters.AddWithValue("@ccp", temp.Current_Passengers);
                cmd1.Parameters.AddWithValue("@fnn", temp.Flight_Number);

                try
                {
                    conn1.Open();

                    cmd1.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not update the flight!\n{0}", ex.Message);
                }
                finally
                {
                    conn1.Close();
                   
                }
                // generates random unique booking number for each passenger added to a flight
                Random _random = new Random();
                int booking_num = _random.Next();
            
                return booking_num;

            }




        }
        // decrement previous flights current passengers amount by 1 if passenger changes flight or gets deleted
        public void Remove_Passenger_From_Flight(int f_num)
        {
            Flight temp = new Flight();
            int check_capacity;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // get the flight information of the previous flight the passenger moved from or got deleted from
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Flights WHERE Flight_Number = @f_n", conn);

                cmd.Parameters.AddWithValue("@f_n", f_num);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fn = reader["Flight_Number"].ToString();
                        int fnc = Convert.ToInt32(fn);
                        string dd = reader["Departure_Date"].ToString();
                        string ad = reader["Arrival_Date"].ToString();
                        string dt = reader["Departure_Time"].ToString();
                        string at = reader["Arrival_Time"].ToString();
                        string da = reader["Departure_Airport"].ToString();
                        string aa = reader["Arrival_Airport"].ToString();

                        string pl = reader["Passenger_Limit"].ToString();
                        int plc = Convert.ToInt32(pl);
                        string cp = reader["Current_Passengers"].ToString();
                        int cpc = Convert.ToInt32(cp);
                        check_capacity = cpc - 1;

                        // can't have negative passengers on a flight
                        // if there's only 1 passenger then removing a passenger makes it -1 so just set it to 0
                        if (check_capacity < 0)
                        {
                            check_capacity = 0;
                        }


                        temp.Flight_Number = fnc;
                        temp.Departure_Date = dd;
                        temp.Arrival_Date = ad;
                        temp.Departure_Time = dt;
                        temp.Arrival_Time = at;
                        temp.Departure_Airport = da;
                        temp.Arrival_Airport = aa;
                        temp.Passenger_Limit = plc;
                        // set new value of current_passengers for updating the flight
                        temp.Current_Passengers = check_capacity;



                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not find the flight!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                // query to update the flight passenger was removed from
                SqlCommand cmd1 = new SqlCommand("Update dbo.Flights set Current_Passengers = @ccp where Flight_Number = @fnn", conn1);

                // parameterized queries to prevent sql injection
                cmd1.Parameters.AddWithValue("@ccp", temp.Current_Passengers);
                cmd1.Parameters.AddWithValue("@fnn", temp.Flight_Number);

                try
                {
                    conn1.Open();

                    cmd1.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not update the flight!\n{0}", ex.Message);
                }
                finally
                {
                    conn1.Close();

                }

                

            }




        }
        public Flight GetFlight(int f_num)
        {

            Flight temp = new Flight();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Flights WHERE Flight_Number = @f_n", conn);

                cmd.Parameters.AddWithValue("@f_n", f_num);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fn = reader["Flight_Number"].ToString();
                        int fnc = Convert.ToInt32(fn);
                        string dd = reader["Departure_Date"].ToString();
                        string ad = reader["Arrival_Date"].ToString();
                        string dt = reader["Departure_Time"].ToString();
                        string at = reader["Arrival_Time"].ToString();
                        string da = reader["Departure_Airport"].ToString();
                        string aa = reader["Arrival_Airport"].ToString();
                        string pl = reader["Passenger_Limit"].ToString();
                        int plc = Convert.ToInt32(pl);
                        string cp = reader["Current_Passengers"].ToString();
                        int cpc = Convert.ToInt32(cp);


                        temp.Flight_Number = fnc;
                        temp.Departure_Date = dd;
                        temp.Arrival_Date = ad;
                        temp.Departure_Time = dt;
                        temp.Arrival_Time = at;
                        temp.Departure_Airport = da;
                        temp.Arrival_Airport = aa;
                        temp.Passenger_Limit = plc;
                        temp.Current_Passengers = cpc;



                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not find the flight!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            return temp;
        }


    }
}
