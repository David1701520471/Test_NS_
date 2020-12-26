
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json; 
using System.Threading.Tasks;
using System.Web.Mvc;
using TestMVC.ExternalAPI.Interface;
using TestMVC.ExternalAPI.Response;

namespace TestMVC.ExternalAPI.Repository
{
    public class ApiRepository : ApiInterface
    {
        readonly string baseUrl = "http://testapi.vivaair.com/otatest/api/values";
        public HttpClient Client { get; }
        

        public ApiRepository()
        {
            Client = new HttpClient();
        }

        [HttpGet]
        public async Task<IEnumerable<ResAPI>> Flight(string origin, string destination, string from)
        {
            try
            {
                var response = await GetFlightsFromApi(origin, destination, from);
                return response;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        public async Task<IEnumerable<ResAPI>> GetFlightsFromApi(string FlightOrigin, string FlightDestination,
                                                                string FlightDate)
        {
            try
            {
                List<ResAPI> reply = new List<ResAPI>();
                var requestObject = new
                {
                    Origin = FlightOrigin,
                    Destination = FlightDestination,
                    From = FlightDate
                };
                var requestJson = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(requestObject), 
                    Encoding.UTF8, 
                    "application/json");

                var httpResponse =await Client.PostAsync(baseUrl, requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var responseStream = await httpResponse.Content.ReadAsStringAsync();
                responseStream = responseStream.Substring(1, responseStream.Length - 2).Replace("\\", "");
                reply = JsonSerializer.Deserialize<List<ResAPI>>(responseStream);

                return reply;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}