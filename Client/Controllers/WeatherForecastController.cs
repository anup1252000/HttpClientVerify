using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            string response = string.Empty;
            for (int i = 0; i < 10; i++)
            {
              

                //var httpClient = new HttpClient
                //{
                //    BaseAddress = new Uri("http://localhost:51091/")
                //};

                var httpClient = _httpClientFactory.CreateClient("api1");

                response = await httpClient.GetStringAsync("weatherforecast")
                    .ConfigureAwait(false);
            };
            return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(response);



        }
    }
}
