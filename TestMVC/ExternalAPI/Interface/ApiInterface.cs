
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestMVC.ExternalAPI.Response;

namespace TestMVC.ExternalAPI.Interface
{
    public interface ApiInterface
    {
        Task<IEnumerable<ResAPI>> GetFlightsFromApi(string FlightOrigin, string FlightDestination, string FlightDate);

        [HttpGet]
        Task<IEnumerable<ResAPI>> Flight(string origin, string destination, string from);
    }
}