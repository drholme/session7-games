using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Session7VideoGames.Models;

namespace Session7VideoGames.Controllers
{
    public class JohnGameController : Controller
    {
        public ActionResult Index()
        {
            GamesContext bafudgery = new GamesContext();
            return View(bafudgery.Games.ToList());
        }

        public ActionResult Analyze(string someTitle, int DeveloperId, DateTime ReleaseDate, string Genre, string Rating)
        {
            GamesContext haberdashery = new GamesContext();
            Game gamegame = new Game();
            gamegame.Title = someTitle;
            gamegame.ReleaseDate = ReleaseDate;
            gamegame.Rating = Rating;
            gamegame.Genre = Genre;
            gamegame.Developer = haberdashery.Developers.Find(DeveloperId);
            haberdashery.Games.Add(gamegame);
            haberdashery.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}