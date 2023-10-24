using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGames.Models;
using System.Reflection.Metadata.Ecma335;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;
        public HomeController(CountryContext ctx) => context = ctx;

        public ViewResult Index(CountriesViewModel model)
        {
            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveCat(model.ActiveCat);
            session.SetActiveGame(model.ActiveGame);

            int? count = session.GetMyCountriesCount();
            if(!count.HasValue)
            {
                var cookies = new OlympicCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                if(ids.Length > 0)
                {
                    var mycountries = context.Countries
                        .Include(c => c.Category)
                        .Include(c => c.Game)
                        .Where(c => ids.Contains(c.CountryID))
                        .ToList();
                    session.SetMyCountries(mycountries);
                }
            }

            model.Categories = context.Categories.ToList();
            model.Games = context.Games.ToList();

            IQueryable<Countries> query = context.Countries.OrderBy(c => c.CountryName);

            if (model.ActiveCat != "all")
                query = query.Where(c => c.Category.CategoryId.ToLower() == model.ActiveCat.ToLower());
            if (model.ActiveGame != "all")
                query = query.Where(g => g.Game.GameID.ToLower() == model.ActiveGame.ToLower());

            model.Country = query.ToList();

            return View(model);
        }
        [HttpGet]
        public ViewResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                Countries = context.Countries
                    .Include(c => c.Category)
                    .Include(c => c.Game)
                    .FirstOrDefault(c => c.CountryName == id) ?? new Countries(), ActiveCat = session.GetActiveCat(), ActiveGame = session.GetActiveGame()
            };
            return View(model);
        }       
    }
}
