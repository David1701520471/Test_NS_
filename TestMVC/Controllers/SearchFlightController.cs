using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using TestMVC.ExternalAPI.Response;
using TestMVC.ExternalAPI.Interface; 

namespace TestMVC.Controllers
{
    public class SearchFlightController : Controller
    {
        
        private readonly ApiInterface _api;
        
        public SearchFlightController(ApiInterface api)
        {
            _api = api;
        }

        // GET: SearchFlight
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
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


    }
}