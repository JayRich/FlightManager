using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using ADO;
using Microsoft.Extensions.Configuration;

namespace FlightManager
{
    public class PassengerDAO : IPassengerDAO
    {

        private string connString = "Data Source=DESKTOP-VVR1VUV;Initial Catalog=Flights;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        

        
        // add passenger to db and generate random booking number for the flight they've been added to. Flights passenger limit is checked and current passenger amount is also updated in dbo.Flights if not exceeding limit
        public void AddPassengerToDB(string id, string n, string j, string e, string a, string bn, string fn)
        {

            Passenger temp = new Passenger();
            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand("Insert into dbo.Passengers (Id,Name,Job,Email,Age,Booking_Number,Flight_Number) values (@Id,@Name,@Job,@Email,@Age,@Booking_Number,@Flight_Number)", conn);
                int cid = Convert.ToInt32(id);
                int ca = Convert.ToInt32(a);
                int cbn = Convert.ToInt32(bn);
                int cfn = Convert.ToInt32(fn);




                cmd.Parameters.AddWithValue("@Id", cid);
                cmd.Parameters.AddWithValue("@Name", n);
                cmd.Parameters.AddWithValue("@Job", j);
                cmd.Parameters.AddWithValue("@Email", e);
                cmd.Parameters.AddWithValue("@Age", ca);

                cmd.Parameters.AddWithValue("@Booking_Number", cbn);
                cmd.Parameters.AddWithValue("@Flight_Number", cfn);

                try
                {
                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all the passengers!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }



        }


        // builds a select query based on user input with flags and if statements
        public IEnumerable<Passenger> GetPassengers(int? id, string? n, string? j, string? e, int? a, int? bn, int? fn)
        {
            List<Passenger> PassengerList = new List<Passenger>();

            // will count the number of values the user input 

            int num_of_nulls = 0;

            // if input values isn't null then increment to determine how many fields to have in the query string
            if (id != null)
            {
                num_of_nulls++;
             }
            if (n != null)
            {
                num_of_nulls++;
            }
            if (j != null)
            {
                num_of_nulls++;
            }
            if (e != null)
            {
                num_of_nulls++;
            }
            if (a != null)
            {
                num_of_nulls++;
            }
            if (bn != null)
            {
                num_of_nulls++;
            }
            if (fn != null)
            {
                num_of_nulls++;
            }

            //SqlCommand cmd = new SqlCommand("");
            string query = "SELECT * FROM dbo.Passengers where ";
            // if all values are nulls then return a select * to All_Passengers controller action

            if (num_of_nulls == 0)
            {
                query = "SELECT * FROM dbo.Passengers";
            }
            bool is_first_condition = true;
           
            int find_last_condition = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // if user input value wasn't null then we need to add that field to the where condition with appropriate syntax
                if (id != null)
                {
                  
                    if (is_first_condition == true)
                    {
                        query += "Id = @iid";
                    }
                   
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Id = @iid";
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (n != null)
                {
                    

                    if (is_first_condition == true)
                    { 
                        query += "Name = @nn";
                    }
                    if(is_first_condition == false)
                    {
                        query += " and ";
                        query += "Name = @nn";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;

                }

                if (j != null)
                {
                    

                    if (is_first_condition == true)
                    {
                        query += "Job = @jj";
                    }
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Job = @jj";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (e != null)
                {
                   
                    if (is_first_condition == true)
                    {
                        query += "Email = @ee";
                    }
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Email = @ee";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (a != null)
                {
                   

                    if (is_first_condition == true)
                    {
                        query += "Age = @aa";
                    }
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Age = @aa";
                        
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

                if (bn != null)
                {
                    

                    if (is_first_condition == true)
                    {
                        query += "Booking_Number = @bbn";
                    }
                    if (is_first_condition == false)
                    {
                        query += " and ";
                        query += "Booking_Number = @bbn";
                       
                    }
                    is_first_condition = false;
                    find_last_condition++;
                }

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


                SqlCommand cmd = new SqlCommand(query, conn);

                // if field wasnt null then we need to add it to the select query as paramaterized input 
                if (id != null)
                {
                    cmd.Parameters.AddWithValue("@iid", id);
                }

                if (n != null)
                {
                    cmd.Parameters.AddWithValue("@nn", n);
                }

                if (j != null)
                {
                    cmd.Parameters.AddWithValue("@jj", j);
                }

                if (e != null)
                {
                    cmd.Parameters.AddWithValue("@ee", e);
                }

                if (a != null)
                {
                    cmd.Parameters.AddWithValue("@aa", a);
                }

                if (bn != null)
                {
                    cmd.Parameters.AddWithValue("@bbn", bn);
                }

                if (fn != null)
                {
                    cmd.Parameters.AddWithValue("@ffn", fn);
                }

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        string fnn = reader["Id"].ToString();
                        string dd = reader["Name"].ToString();
                        string ad = reader["Job"].ToString();
                        string dt = reader["Email"].ToString();
                        string at = reader["Age"].ToString();
                        string da = reader["Booking_Number"].ToString();
                        string aa = reader["Flight_Number"].ToString();





                        Passenger temp = new Passenger(Convert.ToInt32(fnn), dd, ad, dt, Convert.ToInt32(at), Convert.ToInt32(da), Convert.ToInt32(aa));





                        PassengerList.Add(temp);
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all passengers!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }



            return PassengerList;
        }

        // deletes passenger based on id. The flights current passenger amount is decremented by 1 in the dbo.Flights
        public bool Delete_Passenger(int id)
        {
            Passenger temp = new Passenger();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Passengers WHERE Id = @i_n", conn);
                cmd.Parameters.AddWithValue("@i_n", id);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fnn = reader["Id"].ToString();
                        int fnc = Convert.ToInt32(fnn);
                        string dd = reader["Name"].ToString();
                        string ad = reader["Job"].ToString();
                        string dt = reader["Email"].ToString();
                        string at = reader["Age"].ToString();
                        int atc = Convert.ToInt32(at);
                        string da = reader["Booking_Number"].ToString();
                        int dac = Convert.ToInt32(da);
                        string pl = reader["Flight_Number"].ToString();
                        int plc = Convert.ToInt32(pl);


                        temp.Id = fnc;
                        temp.Name = dd;
                        temp.Job = ad;
                        temp.Email = dt;
                        temp.Age = atc;
                        temp.Booking_Number = dac;
                        temp.Flight_Number = plc;




                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not find the passenger!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            // update flight number on flight by decreasing current passenger amount by 1
            FlightDAO temp_f = new FlightDAO();
            temp_f.Remove_Passenger_From_Flight(temp.Flight_Number);
                
            using (SqlConnection conn2 = new SqlConnection(connString))
            {


                SqlCommand cmd2 = new SqlCommand("Delete from dbo.Passengers where Id = @idd", conn2);

                cmd2.Parameters.AddWithValue("@idd", id);


                try
                {
                    conn2.Open();

                    cmd2.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not delete passenger!\n{0}", ex.Message);
                    return false;
                }
                finally
                {
                    conn2.Close();
                }
            }

          


            return true;

        }

        // builds an update query using if statements based on user input. If Flight number is changed then the flights current passengers amount in dbo.flights is changed
        public bool Update_Passenger(int id, string? n, string? j, string? e, int? a, int? fn)
        {

            Passenger temp = new Passenger();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Passengers WHERE Id = @i_n", conn);
                cmd.Parameters.AddWithValue("@i_n", id);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fnn = reader["Id"].ToString();
                        int fnc = Convert.ToInt32(fnn);
                        string dd = reader["Name"].ToString();
                        string ad = reader["Job"].ToString();
                        string dt = reader["Email"].ToString();
                        string at = reader["Age"].ToString();
                        int atc = Convert.ToInt32(at);
                        string da = reader["Booking_Number"].ToString();
                        int dac = Convert.ToInt32(da);
                        string pl = reader["Flight_Number"].ToString();
                        int plc = Convert.ToInt32(pl);


                        temp.Id = fnc;
                        temp.Name = dd;
                        temp.Job = ad;
                        temp.Email = dt;
                        temp.Age = atc;
                        temp.Booking_Number = dac;
                        temp.Flight_Number = plc;




                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not find the passenger!\n{0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            using (SqlConnection conn2 = new SqlConnection(connString))
            {

                SqlCommand cmd2 = new SqlCommand("Update dbo.Passengers set Id = @idd, Name = @ddd, Job = @add, Email = @dtt, Age = @att, Booking_Number = @daa, Flight_Number = @aaa where Id = @i", conn2);


                cmd2.Parameters.AddWithValue("@idd", id);
                // if value wasnt null then change column value to the new value
                if (n != null)
                {
                    cmd2.Parameters.AddWithValue("@ddd", n);
                }

                // if user input was blank then just update the column with the same value it had before. doesn't change.
                if (n == null)
                {
                    cmd2.Parameters.AddWithValue("@ddd", temp.Name);
                }
                if (j != null)
                {
                    cmd2.Parameters.AddWithValue("@add", j);
                }
                if (j == null)
                {
                    cmd2.Parameters.AddWithValue("@add", temp.Job);
                }
                if (e != null)
                {
                    cmd2.Parameters.AddWithValue("@dtt", e);
                }
                if (e == null)
                {
                    cmd2.Parameters.AddWithValue("@dtt", temp.Email);
                }
                if (a != null)
                {
                    cmd2.Parameters.AddWithValue("@att", a);
                }
                if (a == null)
                {
                    cmd2.Parameters.AddWithValue("@att", temp.Age);
                }

                // if flight number is changing then need to check capacity of new flight and generate a new random booking number by calling add passenger to flight function
                if (fn != null)
                {
                    int check_capacity = 0;
                    FlightDAO temp_f = new FlightDAO();
                    int ffn = Convert.ToInt32(fn);
                    check_capacity = temp_f.Add_Passenger_To_Flight(ffn);
                    temp_f.Remove_Passenger_From_Flight(temp.Flight_Number);
                    if (check_capacity != -1)
                    {
                        cmd2.Parameters.AddWithValue("@aaa", fn);
                        cmd2.Parameters.AddWithValue("@daa", check_capacity);
                    }

                }
                // if flight number is the same then the booking number also stays the same
                if (fn == null)
                {
                    cmd2.Parameters.AddWithValue("@aaa", temp.Flight_Number);
                    cmd2.Parameters.AddWithValue("@daa", temp.Booking_Number);
                }

                cmd2.Parameters.AddWithValue("@i", id);

                

                try
                {
                    conn2.Open();

                    cmd2.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not update passenger!\n{0}", ex.Message);
                    return false;
                }
                finally
                {
                    conn2.Close();
                }

            }


            return true;


        }

        // loops through the rows of the select all and counts them for home page to display
                public int Count_Passengers()
                {
                    int num_of_p = 0;

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Passengers", conn);


                        try
                        {
                            conn.Open();

                            SqlDataReader reader = cmd.ExecuteReader();


                            while (reader.Read())
                            {
                                num_of_p++;
                            }

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Could not count all passengers\n{0}", ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }



                    return num_of_p;
                }

        public Passenger GetPassenger(int id)
        {

            Passenger temp = new Passenger();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Passengers WHERE Booking_Number = @i_n", conn);
                cmd.Parameters.AddWithValue("@i_n", id);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fn = reader["Id"].ToString();
                        int fnc = Convert.ToInt32(fn);
                        string dd = reader["Name"].ToString();
                        string ad = reader["Job"].ToString();
                        string dt = reader["Email"].ToString();
                        string at = reader["Age"].ToString();
                        int atc = Convert.ToInt32(at);
                        string da = reader["Booking_Number"].ToString();
                        int dac = Convert.ToInt32(da);
                        string pl = reader["Flight_Number"].ToString();
                        int plc = Convert.ToInt32(pl);


                        temp.Id = fnc;
                        temp.Name = dd;
                        temp.Job = ad;
                        temp.Email = dt;
                        temp.Age = atc;
                        temp.Booking_Number = dac;
                        temp.Flight_Number = plc;




                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not find the passenger!\n{0}", ex.Message);
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
