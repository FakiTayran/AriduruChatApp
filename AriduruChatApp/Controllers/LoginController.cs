using AriduruChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AriduruChatApp.Controllers
{
    public class LoginController : Controller
    {
        private UserDbContext db;
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            using (db = new UserDbContext())
            {
                if (ModelState.IsValid)
                {
                    SHA256 sha = new SHA256CryptoServiceProvider();
                    user.Password = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
                    db.Entry(user).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            using (db = new UserDbContext())
            {
                if (ModelState.IsValid)
                {
                    SHA256 sha = new SHA256CryptoServiceProvider();
                    user.Password = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
                    var authenticatedUser = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

                    if (authenticatedUser != null)
                    {
                        authenticatedUser.UserSessionId = Guid.NewGuid().ToString();
                        db.Entry(authenticatedUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Session[authenticatedUser.UserSessionId] = DateTime.Now;
                        ViewBag.Auth = authenticatedUser.UserSessionId;
                        return RedirectToAction("Chat", "Chat", new { id = ViewBag.Auth });
                    }
                }

                return RedirectToAction("Index", "Home");
            }
        }
    }
}