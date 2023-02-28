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
using Microsoft.EntityFrameworkCore;


namespace ArtGallery.Controllers
{
    
    public class ArtController : Controller
    {
        private readonly ACE42023Context db;
        public ArtController(ACE42023Context __db)
        {
            db=__db;
        }

        [Route("OurArtists")]
        public ActionResult GetArtists()
        {
            ViewBag.UserName =HttpContext.Session.GetString("username");
            if(ViewBag.UserName==null)
                return RedirectToAction("Login","Login");
            
            var result=(from i in db.Paintings.Include(x=>x.Artist) select i).ToList();
            return View(result);
        }

        [Route("Gallery")]
        public ActionResult GetPaintings()
        {
            
            ViewBag.UserName =HttpContext.Session.GetString("username");
            if(ViewBag.UserName!=null)
            return View(db.Paintings.ToList());

            return RedirectToAction("Login","Login");
        }
        public ActionResult Create()
        {
            ViewBag.UserName =HttpContext.Session.GetString("username");
            if(ViewBag.UserName==null)
                return RedirectToAction("Login","Login");

            var result =db.Artistishans.ToList();
            ViewBag.Artists=new SelectList(result,"Aid","Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Painting p)
        {
            if(ModelState.IsValid)
            {
                db.Paintings.Add(p);
                db.SaveChanges();
                return RedirectToAction("GetPaintings");
            }
            else return View();
        }

        public ActionResult SearchPaintings(IFormCollection f)
        {
            string keyword=f["keyword"].ToString();
            var result=db.Paintings.Where(x=>x.Title.Contains(keyword)).Select(x=>x).ToList();
            return View(result);
        }

        public IActionResult Details(int id)
        {
            ViewBag.UserName =HttpContext.Session.GetString("username");
            if(ViewBag.UserName==null)
                return RedirectToAction("Login","Login");
            Painting p=db.Paintings.Find(id);
            return View(p);
        }
        [HttpGet]
        [Route("Editing")]
        public IActionResult Edit(int id)
        {
            ViewBag.UserName =HttpContext.Session.GetString("username");
            if(ViewBag.UserName==null)
                return RedirectToAction("Login","Login");

            Painting p=db.Paintings.Where(x=>x.Pid==id).SingleOrDefault();
            return View(p);
        }
        [HttpPost]
        [Route("Editing")]
        
        public IActionResult Edit(Painting p)
        {
            db.Paintings.Update(p);
            db.SaveChanges();
            return RedirectToAction("GetPaintings");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.UserName =HttpContext.Session.GetString("username");
            if(ViewBag.UserName==null)
                return RedirectToAction("Login","Login");
            Painting p=db.Paintings.Where(x=>x.Pid==id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Painting p=db.Paintings.Where(x=>x.Pid==id).SingleOrDefault();
            db.Paintings.Remove(p);
            db.SaveChanges();
            return RedirectToAction("GetPaintings");
        }
        
    }
}