using System;
using System.Threading.Tasks;
using TestMVC.ExternalAPI.Response;
using TestMVC.ExternalAPI.Interface;
using TestMVC.Models.Flight;
using TestMVC.DbAccess.Interface;
using System.Web.Http;
using System.Web.Mvc;

namespace TestMVC.Controllers
{
    public class SearchFlightController : Controller
    {
        
        private readonly IAPI _api;
        private readonly IDbAcces _dbAccess;

        public SearchFlightController(IAPI api,IDbAcces dbAccess)
        {
            _api = api;
            _dbAccess = dbAccess;
        }

        // GET: SearchFlight
        public ActionResult Index()
        {
            return View();
        }


        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> Search(string Origin,string Destination,string Datepicker)
        {
            try
            {
                var response = await _api.Flight(Origin, Destination, Datepicker);
                return View("Search", response);
            }
            catch(Exception ex)
            {
                throw new Exception("Somethin happen: " + ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Save([FromBody] ResAPI flight)
        {
            try
            {

                Flight model = await _dbAccess.SaveFlight(flight);
                return View("Save",model);
            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje de error " + ex.Message);
            }
        }


    }
}