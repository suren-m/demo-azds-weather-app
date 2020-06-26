using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Weather.Web.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<WeatherForecast> WeatherReport { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient();
            _logger.LogInformation("\n...Retrieving Data...\n");

            var request = new System.Net.Http.HttpRequestMessage();
            request.RequestUri = new Uri("http://weatherinternalapi/weatherforecast");

            if (this.Request.Headers.ContainsKey("azds-route-as"))
            {
                // Propagate the dev space routing header
                request.Headers.Add("azds-route-as",
                this.Request.Headers["azds-route-as"] as IEnumerable<string>);
            }
            var response = await client.SendAsync(request);

            var jsonResult = await response.Content.ReadAsStringAsync();

            WeatherReport = JsonSerializer.Deserialize<List<WeatherForecast>>(
                    jsonResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            _logger.LogInformation("\n...Finished Retrieving Data...\n");
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

}
