using Exercise4.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Exercise4.Controllers
{
    public class CharacterController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CharacterViewModel> characters = new List<CharacterViewModel>();
            string url = "https://mocki.io/v1/d4867d8b-b5d5-4a48-a4ab-79131b5809b8";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage getData = await httpClient.GetAsync(url);

            if (getData.IsSuccessStatusCode)
            {
                string results = await getData.Content.ReadAsStringAsync();
                characters = JsonConvert.DeserializeObject<List<CharacterViewModel>>(results);
            }
            else
            {
                Console.WriteLine("Error calling the web API");
            }

            return View(characters);
        }
    }
}
