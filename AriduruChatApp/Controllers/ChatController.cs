using AriduruChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AriduruChatApp.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        private UserDbContext db; 
        public ActionResult Chat(string id)
        {
            if (Session[id]==null )
            {
                return Redirect("~/Index/Home");
            }
            using (db = new UserDbContext())
            {
                string username = db.Users.FirstOrDefault(x => x.UserSessionId == id).UserName;
                ViewBag.UserName = username;
            }
                ViewBag.Session = id;
            return View();
        }
    }
}