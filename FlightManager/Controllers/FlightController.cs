using ADO;
using FlightManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Controllers
{
    public class FlightController : Controller
    {
        private readonly ILogger<FlightController> _logger;

        private readonly FlightDAO fDAO = new FlightDAO();



        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int total_flights;
            string new_total_flights;
            int t_p;
            string new_tp;
            FlightDAO temp_flight = new FlightDAO();
            PassengerDAO temp_pass = new PassengerDAO();
            t_p = temp_pass.Count_Passengers();
            new_tp = t_p.ToString();
            total_flights = temp_flight.Count_Flights();
            new_total_flights = total_flights.ToString();
            ViewData["t_flights"] = new_total_flights;
            ViewData["t_pass"] = new_tp;

            return View();
           
        }

        

        public IActionResult All_Flights()
        {
            
            FlightDAO temp_flight = new FlightDAO();
            IEnumerable<Flight> flights = temp_flight.GetFlights(null,null,null,null,null,null,null,null,null);
            List<Flight> model = new List<Flight>();

            foreach (var flight in flights)
            {
                Flight temp = new Flight()
                {
                    Flight_Number = flight.Flight_Number,
                    Departure_Date = flight.Departure_Date,
                    Arrival_Date = flight.Arrival_Date,
                    Departure_Time = flight.Departure_Time,
                    Arrival_Time = flight.Arrival_Time,
                    Departure_Airport = flight.Departure_Airport,
                    Arrival_Airport = flight.Arrival_Airport,
                    Passenger_Limit = flight.Passenger_Limit,
                    Current_Passengers = flight.Current_Passengers

                };

                model.Add(temp);
            }

            return View(model);
        }

        public IActionResult Delete_Flight()
        {

            return View();
        }

        public IActionResult Find_Delete_Flight(string id)
        {
            bool confirm;
            int cid = Convert.ToInt32(id);

            FlightDAO temp_flight = new FlightDAO();

            confirm = temp_flight.Delete_Flight(cid);

            if (confirm == true)
            {

                ViewData["confirm"] = "Delete Successful";

            }
            else
            {
                ViewData["confirm"] = "Delete Not Successful";

            }

            return View();

            
        }


        public IActionResult Update_Flight()
        {

            return View();
        }

        public IActionResult Find_Update_Flight(string? fn, string? dd, string? ad, string? dt, string? at, string? da, string? aa, string? pl, string? cp)
        {

            int? cfn = null;
            int? cpl = null;
            int? ccp = null;


            if (fn != null)
            {
                cfn = Convert.ToInt32(fn);
            }

            if (pl != null)
            {
                cpl = Convert.ToInt32(pl);
            }

            if (cp != null)
            {
                ccp = Convert.ToInt32(cp);
            }



            bool update_confirm;

            FlightDAO temp_f = new FlightDAO();



            Flight temp = new Flight();

            update_confirm = temp_f.Update_Flight(cfn, dd, ad, dt, at, da, aa, cpl, ccp);

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

 
        public IActionResult Search_Flight()
        {

            return View();
        }


        public IActionResult Display_Flight(string? fn, string? dd, string? ad, string? dt, string? at, string? da, string? aa, string? pl, string? cp)
        {
            

            int? cfn = null;
            int? cpl = null;
            int? ccp = null;
            

            if (fn != null)
            {
                cfn = Convert.ToInt32(fn);
            }

            if (pl != null)
            {
                cpl = Convert.ToInt32(pl);
            }

            if (cp != null)
            {
                ccp = Convert.ToInt32(cp);
            }
            

            FlightDAO temp_flight = new FlightDAO();

            IEnumerable<Flight> flights = temp_flight.GetFlights(cfn, dd, ad, dt, at, da, aa, cpl, ccp);

            List<Flight> model = new List<Flight>();

            foreach (var p in flights)
            {
                Flight temp = new Flight()
                {
                    Flight_Number = p.Flight_Number,
                    Departure_Date = p.Departure_Date,
                    Arrival_Date = p.Arrival_Date,
                    Departure_Time = p.Departure_Time,
                    Arrival_Time = p.Arrival_Time,
                    Departure_Airport = p.Departure_Airport,
                    Arrival_Airport = p.Arrival_Airport,
                    Passenger_Limit = p.Passenger_Limit,
                    Current_Passengers = p.Current_Passengers

                };

                model.Add(temp);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create_Flight()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create_Flight([Bind] Flight flight_new)
        {

            
            if (ModelState.IsValid)
            {
                Flight newFlight = new Flight();
                newFlight.Flight_Number = flight_new.Flight_Number;
                newFlight.Departure_Date = flight_new.Departure_Date;
                newFlight.Arrival_Date = flight_new.Arrival_Date;
                newFlight.Departure_Time = flight_new.Departure_Time;
                newFlight.Arrival_Time = flight_new.Arrival_Time;
                newFlight.Departure_Airport = flight_new.Departure_Airport;
                newFlight.Arrival_Airport = flight_new.Arrival_Airport;
                newFlight.Passenger_Limit = flight_new.Passenger_Limit;
                newFlight.Current_Passengers = flight_new.Current_Passengers;
                    


                fDAO.AddFlightToDB(newFlight);

                return RedirectToAction("Index");
            }

            return View(flight_new);
        }

    


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
