using System;
using System.Threading.Tasks;
using TestMVC.DbAccess.Interface;
using TestMVC.ExternalAPI.Response;
using TestMVC.Models.Flight;
using TestMVC.Context;
using System.Web.Mvc;
using TestMVC.Models.Transport;
using TestMVC.DbAccess.Exeptions;

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
            Flight newFlight = new Flight()
            {
                FlightCode = flight.FlightNumber + flight.DepartureStation + flight.ArrivalStation + flight.DepartureDate.Day,
                DepartureStation = flight.DepartureStation,
                DepartureDate = flight.DepartureDate,
                ArrivalStation = flight.ArrivalStation,
                Currency = flight.Currency,
                Price = flight.Price,
                Transport = new Transport()
                {
                    FlightNumber = flight.FlightNumber + flight.DepartureDate.Day
                },
                FkTransport = flight.FlightNumber + flight.DepartureDate.Day

            };
            if (newFlight.FlightCode==null||newFlight.DepartureStation==null||newFlight.DepartureDate==null||
                newFlight.ArrivalStation == null || newFlight.Currency == null || newFlight.Price == 0 || newFlight.FkTransport == null)
            {
                throw new MissingFlightDataException("Any of the data to save for this flight is missed");
            }
            try
            {
                db.Flights.Add(newFlight);
                await db.SaveChangesAsync();
                return newFlight;
            }
            catch (Exception)
            {
                throw new FlightDataAlreadySavedException($"The flight {newFlight.FlightCode} is already stored in the data base");
            }
        }
    }
}