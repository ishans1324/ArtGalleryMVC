using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;


namespace ArtGallery.Controllers
{
    public class LoginController : Controller
    {

        private readonly ISession session;
        private readonly ACE42023Context db;
        public LoginController(ACE42023Context _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }




        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ArtUser a)
        {
            var result=(from i in db.ArtUsers where i.Uname==a.Uname&&i.Password==a.Password select i).SingleOrDefault();
            if(result!=null)
            {
                HttpContext.Session.SetString("username",result.Uname);
               return RedirectToAction("GetPaintings","Art");
            }

            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ArtUser a)
        {

            db.ArtUsers.Add(a);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        

    }
}