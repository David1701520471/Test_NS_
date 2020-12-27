using System;
using System.Threading.Tasks;
using TestMVC.ExternalAPI.Response;
using TestMVC.ExternalAPI.Interface;
using TestMVC.Models.Flight;
using TestMVC.DbAccess.Interface;
using System.Web.Http;
using System.Web.Mvc;
using TestMVC.Models.SearchData;
using TestMVC.Models.Search;

namespace TestMVC.Controllers
{
    public class SearchFlightController : Controller
    {

        private readonly IAPI _api;
        private readonly IDbAcces _dbAccess;

        public SearchFlightController(IAPI api, IDbAcces dbAccess)
        {
            _api = api;
            _dbAccess = dbAccess;
        }

        // GET: SearchFlight
        public ActionResult Index()
        {
            return View();
        }


        [System.Web.Http.HttpGet]
        public async Task<ActionResult> Search([FromBody] SearchData searchData)
        {
            try
            {
                var response = await _api.Flight(searchData.Origin, searchData.Destination, searchData.Datepicker);
                return View("Search", response);
            }
            catch (Exception ex)
            {
                throw new SearchMissedFieldException("Any field required for the search is missed" + ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Save([FromBody] ResAPI flight)
        {
            try
            {

                Flight model = await _dbAccess.SaveFlight(flight);
                return View("Save", model);
            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje de error " + ex.Message);
            }
        }


    }
}