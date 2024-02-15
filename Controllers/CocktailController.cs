using Exercise4.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Exercise4.Controllers
{
    public class CocktailController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<CocktailViewModel> drinks = new List<CocktailViewModel>();
            string url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await httpClient.GetAsync(url);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(results);
                JArray drinkArray = (JArray)json["drinks"];
                drinks = drinkArray.ToObject<List<CocktailViewModel>>();

            }
            else
            {
                Console.WriteLine("error calling the web API");
            }

          //  HttpClient httpClient = new HttpClient();
          //   HttpResponseMessage getData = await httpClient.GetAsync(url);
            return View(drinks);
        }

    }
}




