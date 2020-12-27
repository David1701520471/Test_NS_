
using System.Threading.Tasks;
using System.Web.Mvc;
using TestMVC.Models.Flight;
using TestMVC.ExternalAPI.Response;

namespace TestMVC.DbAccess.Interface
{
    public interface IDbAcces
    {
        [HttpPost]
        Task<Flight> SaveFlight(ResAPI flight);
    }
}
