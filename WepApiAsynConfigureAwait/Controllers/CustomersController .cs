using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace WepApiAsynConfigureAwait.Controllers
{

    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

    }
    public class CustomerScoreService
    {
        public async Task<Customer> GetCustomerAsync(string id)
        {
            using (var client = new HttpClient
            {
                DefaultRequestHeaders = {
                 Accept = {
                    new MediaTypeWithQualityHeaderValue("application/json")
                }
                }
            })
            {
                //var json = await client
                //  .GetStringAsync($"http://localhost:64519/test/getcustomers/{id}");

                //if use ConfigureAwait(false) none block;
                var json = await client
            .GetStringAsync($"http://localhost:64519/test/getcustomers/{id}").ConfigureAwait(false);

                return Deserialize<Customer>(json);
            }
        }

        private static T Deserialize<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    [RoutePrefix("test")]
    public class CustomersController : ApiController
    {
        private readonly CustomerScoreService _service;

        public CustomersController()
        {
            _service = new CustomerScoreService();
        }

        [Route("getcustomers/{id}")]
        [HttpGet]
        public Customer GetCustomers(string id)
        {
            return new Customer
            {
                Id = "1",
                Name = "Fatih",
                Score = 100
            };
        }

        //call 
        //http://localhost:64519/test/blocking/222
        [Route("blocking/{id}")]
        [HttpGet]
        public Customer GetViaAsyncService(string id)
        {
            return SomeInternalThingOneAsync(id).Result;

            
        }


        //http://localhost:64519/test/nonblocking/222
        [Route("nonblocking/{id}")]
        [HttpGet]
        public async Task<Customer> GetViaAsyncService1(string id)
        {
            var result = await SomeInternalThingOneAsync(id);
            return result;
        }

        private async Task<Customer> SomeInternalThingOneAsync(string id)
        {
            var customer = await SomeInternalThingTwoAsync(id);

            //Do some stuff otherwise this could have elided instead of awaiting

            ////if use ConfigureAwait(false) none block;
            //var customer = await SomeInternalThingTwoAsync(id).ConfigureAwait(false);

            return customer;
        }

        private async Task<Customer> SomeInternalThingTwoAsync(string id)
        {
            //var customer = await _service.GetCustomerAsync(id) ;

            //Do some stuff otherwise this could have elided instead of awaiting

            //if use ConfigureAwait(false) none block;
            var customer = await _service.GetCustomerAsync(id).ConfigureAwait(false); 

            return customer;
        }
    }
}
