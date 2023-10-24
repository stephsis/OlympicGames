namespace OlympicGames.Models
{
    public class CountriesViewModel
    {
        public Countries Countries { get; set; } = new Countries();
        public string ActiveCat { get; set; } = "all";
        public string ActiveGame { get; set; } = "all";
        public List<Countries>Country { get; set; } = new List<Countries>();
        public List<Category> Categories { get; set; } = new List<Category> { };
        public List<Game> Games { get; set;} = new List<Game>();    

        public string CheckActiveCat(string c) => c.ToLower() == ActiveCat.ToLower() ? "active" : "";
        public string CheckActiveGame(string g) => g.ToLower() == ActiveGame.ToLower() ? "active" : "";
    }
}
