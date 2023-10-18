using Microsoft.AspNetCore.Mvc;
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

            return View(model);
        }
    }
}
