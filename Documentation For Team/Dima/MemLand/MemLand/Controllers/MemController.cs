using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MemLand.Models;
using MemLand.Models.FunnyImages;

namespace MemLand.Controllers
{
    public class MemController : Controller
    {
        MemContext db = new MemContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Mem
        public ActionResult Index()
        {
            
            return View(db.Mems.Where(u => u.PostMem == true).ToList());
        }
        [Authorize(Roles = "manager")]
        [HttpGet]
        public ActionResult PostOrNoMem()
        {
            return View(db.Mems.Where(u => u.PostMem == false).ToList());
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult PostOrNoMem(int numberMem)
        //{
        //    db.Mems.Where(i => i.Id == numberMem).FirstOrDefault().PostMem = true;
        //    db.SaveChanges();
        //    return RedirectToAction("PostOrNoMem");
        //}

        [HttpPost]
        [Authorize]
        public ActionResult CountLike(int numberid)
        {
            db.Mems.Where(i => i.Id == numberid).FirstOrDefault().Like = db.Mems.Where(i => i.Id == numberid).FirstOrDefault().Like + 1;
            db.SaveChanges();
            ViewBag.Like = db.Mems.Where(i => i.Id == numberid).FirstOrDefault().Like;
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public ActionResult AddMem()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddMem(Mem mem)
        {
            var user = db.Roles.Where(i => i.Id == db.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().RoleId).FirstOrDefault().Name;
            if (user == "user")
            {
                mem.PostMem = false;
            }
            else
            {
                mem.PostMem = true;
            }
            mem.UserId = db.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
            mem.Like = 0;
            mem.PostedOn = DateTime.Now;
            db.Mems.Add(mem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ActivePost(int id)
        {
            db.Mems.Where(u => u.Id == id).FirstOrDefault().PostMem = true;
            db.SaveChanges();
            return RedirectToAction("PostOrNoMem");
        }

        public ActionResult DeleteMem(int id)
        {
            var delete = db.Mems.Where(u => u.Id == id).FirstOrDefault();
            db.Mems.Remove(delete);
            return RedirectToAction("PostOrNoMem");
        }

    }
}