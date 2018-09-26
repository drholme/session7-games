using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session7VideoGames.Controllers
{
    public class MyGameController : Controller
    {
        // GET: MyGame
        public ActionResult Index()
        {
            return View();
        }
    }
}