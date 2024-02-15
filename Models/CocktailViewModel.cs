namespace Exercise4.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CocktailViewModel
    {

        public string strDrink { get; set; }
        public string strDrinkThumb { get; set; }
        public string idDrink { get; set; }
    }

    public class Root
    {
        public List<CocktailViewModel> drinks { get; set; }
    }


}
