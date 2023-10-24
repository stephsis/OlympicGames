using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        private CountryContext context;
        public FavoritesController(CountryContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                ActiveCat = session.GetActiveCat(),
                ActiveGame = session.GetActiveGame(),
                Countries = session.GetMyCountries(),
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(Countries countries)
        {
            countries = context.Countries
                .Include(c => c.Category)
                .Include(c => c.Game)
                .Where(c => c.CountryID == countries.CountryID)
                .FirstOrDefault() ?? new Countries();

            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);

            var Countries = session.GetMyCountries();
            Countries.Add(countries);
            session.SetMyCountries(Countries);
            cookies.SetMyCountryIds(Countries);

            TempData["message"] = $"{countries.CountryName} Added to your favorites";

            return RedirectToAction("Index", "Home", new
            {
                ActiveCat = session.GetActiveCat(),
                ActiveGame = session.GetActiveGame(),
            });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Index", "Home", new { ActiveCat = session.GetActiveCat(),  ActiveGame = session.GetActiveGame() });
        }
    }
}
