using ADO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Controllers
{
    public class PassengerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search_Passenger()
        {

            return View();
        }


        public IActionResult Display_Passenger(string? id, string? n, string? j, string? e, string? a, string? bn, string? fn)
        {

            int? cid = null;
            int? ca = null;
            int? cbn = null;
            int? cfn = null;

            if (id != null)
            {
                cid = Convert.ToInt32(id);
            }

            if (a != null)
            {
                ca = Convert.ToInt32(a);
            }

            if (bn != null)
            {
                cbn = Convert.ToInt32(bn);
            }
            if (fn != null)
            {
                cfn = Convert.ToInt32(fn);

            }

            PassengerDAO temp_pass = new PassengerDAO();
            IEnumerable<Passenger> passengers = temp_pass.GetPassengers(cid, n, j, e, ca, cbn, cfn);
            List<Passenger> model = new List<Passenger>();

            foreach (var p in passengers)
            {
                Passenger temp = new Passenger()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Job = p.Job,
                    Email = p.Email,
                    Age = p.Age,
                    Booking_Number = p.Booking_Number,
                    Flight_Number = p.Flight_Number

                };

                model.Add(temp);
            }

            return View(model);

           

        }
    

       
        public IActionResult Finish_Add_Passenger(string id, string n, string j, string e, string a, string bn, string fn)
        {

            PassengerDAO p = new PassengerDAO();

            FlightDAO temp = new FlightDAO();

            
            // before adding passenger to flight the current passenger ammount is checked and if not full the amount is updated and the passenger gets a randomly generated booking number for the flight
            int check_capacity = temp.Add_Passenger_To_Flight(Convert.ToInt32(fn));
            // check capacity holds the newly generated booking number
            if (check_capacity != -1)
            {
                p.AddPassengerToDB(id, n, j, e, a, check_capacity.ToString(), fn);


            }
           

            return View();
        }

       
       
        public IActionResult Add_Passenger()
        {
           

            return View();
        }

        public IActionResult All_Passengers()
        {
        

            PassengerDAO temp_pass = new PassengerDAO();
            IEnumerable<Passenger> passengers = temp_pass.GetPassengers(null, null, null, null, null, null, null);
            List<Passenger> model = new List<Passenger>();

            foreach (var p in passengers)
            {
                Passenger temp = new Passenger()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Job = p.Job,
                    Email = p.Email,
                    Age = p.Age,
                    Booking_Number = p.Booking_Number,
                    Flight_Number = p.Flight_Number

                };

                model.Add(temp);
            }

            return View(model);
        }

        public IActionResult Delete_Passenger()
        {

            return View();
        }

        public IActionResult Find_Delete_Passenger(string id)
        {

            int cid = Convert.ToInt32(id);
            bool delete_confirm;

            PassengerDAO temp_p = new PassengerDAO();



            Passenger temp = new Passenger();

            delete_confirm = temp_p.Delete_Passenger(cid);

            if (delete_confirm == true)
            {

                ViewData["confirm"] = "Delete Successful";

            }
            else
            {
                ViewData["confirm"] = "Delete Not Successful";

            }
            Passenger p_t = new Passenger();
            p_t = temp_p.GetPassenger(cid);
            FlightDAO flightDAO = new FlightDAO();
            Flight temp_flight = new Flight();

            temp_flight = flightDAO.GetFlight(p_t.Flight_Number);

            flightDAO.Remove_Passenger_From_Flight(temp_flight.Flight_Number);

            return View();

        }

            public IActionResult Update_Passenger()
            {

                return View();
            }

            public IActionResult Find_Update_Passenger(string id, string? n, string? j, string? e, string? a, string? fn)
            {
                
            int cid = Convert.ToInt32(id);
            int? ca = null;
           
            int? cfn = null;

            if (a != null)
            {
                ca = Convert.ToInt32(a);
            }
            
            
            if (fn != null)
            {
                cfn = Convert.ToInt32(fn);
             
            }

            bool update_confirm;

                PassengerDAO temp_p = new PassengerDAO();



                Passenger temp = new Passenger();

                update_confirm = temp_p.Update_Passenger(cid, n, j, e, ca, cfn);
                // update passenger needs to check if the requested updated information like changing flights is allowable 
                if (update_confirm == true)
                {

                    ViewData["confirm"] = "Update Successful";

                }
                else
                {
                    ViewData["confirm"] = "Update Not Successful";

                }
                return View();

            }

       



    }
}
