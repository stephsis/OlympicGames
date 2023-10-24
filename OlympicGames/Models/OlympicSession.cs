namespace OlympicGames.Models
{
    public class OlympicSession
    {
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string CatKey = "category";
        private const string GameKey = "game"; 

        private ISession session { get ; set; }
        public OlympicSession(ISession session) => this.session = session;

        public void SetMyCountries(List<Countries> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count());
        }

        public List<Countries> GetMyCountries() => session.GetObject<List<Countries>>(CountriesKey) ?? new List<Countries>();
        public int? GetMyCountriesCount() => session.GetInt32(CountKey);

        public void SetActiveCat(string activeCat) => session.SetString(CatKey, activeCat);
        public string GetActiveCat() => session.GetString(CatKey) ?? string.Empty;

        public void SetActiveGame(string activeGame) => session.SetString(GameKey, activeGame);
        public string GetActiveGame() => session.GetString(GameKey) ?? string.Empty;

        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey); session.Remove(CountKey);
        }
    }
}
