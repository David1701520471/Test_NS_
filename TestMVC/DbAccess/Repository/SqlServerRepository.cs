using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMVC.DbAccess.Interface;
using TestMVC.ExternalAPI.Response;
using TestMVC.Models.Flight;
using TestMVC.Context;
using System.Web.Mvc;
using TestMVC.Models.Transport;

namespace TestMVC.DbAccess.Repository
{
    public class SqlServerRepository : IDbAcces 
    {
        private readonly TestContext db;

        public SqlServerRepository(TestContext context)
        {
            db = context; 
        }

        [HttpPost]
        public async Task<Flight> SaveFlight(ResAPI flight)
        {
            try
            {
                Flight newFlight = new Flight()
                {
                    FlightCode = flight.FlightNumber+flight.DepartureStation+flight.ArrivalStation+flight.DepartureDate.Day,
                    DepartureStation = flight.DepartureStation,
                    DepartureDate = flight.DepartureDate,
                    ArrivalStation = flight.ArrivalStation,
                    Currency = flight.Currency,
                    Price = flight.Price,
                    Transport = new Transport()
                    {
                        FlightNumber = flight.FlightNumber+flight.DepartureDate.Day
                    },
                    FkTransport = flight.FlightNumber+flight.DepartureDate.Day

                };
                db.Flights.Add(newFlight);
                await db.SaveChangesAsync();
                return newFlight;
            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje de error " + ex.Message);
            }
        }
    }
}