using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;
        public HomeController(CountryContext ctx) => context = ctx;

        public ViewResult Index(CountriesViewModel model)
        {
       
         model.Categories = context.Categories.ToList();
         model.Games = context.Games.ToList();

            IQueryable<Countries> query = context.Countries.OrderBy(c => c.CountryName);

            if(model.ActiveCat != "all")
                query = query.Where(c => c.Category.CategoryId.ToLower() == model.ActiveCat.ToLower());
            if(model.ActiveGame != "all")
                query = query.Where(g => g.Game.GameID.ToLower() == model.ActiveGame.ToLower());

            model.Country = query.ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            var country = context.Countries
                .Include(c => c.Category)
                .Include(c => c.Game)
                .FirstOrDefault(c => c.CountryID == id);
            return View(country);
        }
    }
}
