using AriduruChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AriduruChatApp.Controllers
{
    public class HomeController : Controller
    {
        UserDbContext db = new UserDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}