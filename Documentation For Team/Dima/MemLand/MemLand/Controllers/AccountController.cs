using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MemLand.Models;
using MemLand.Models.Account;
using Login = System.Web.UI.WebControls.Login;

namespace MemLand.Controllers
{
    public class AccountController : Controller
    {
        public MemContext db { get; set; }

        public AccountController()
        {
            db = new MemContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;

                user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);



                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Mem");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [

        HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                User user = null;

                user = db.Users.FirstOrDefault(u => u.Email == model.Name);


                if (user == null)
                {
                    // создаем нового пользователя

                    db.Users.Add(new User{ Email = model.Name, Password = model.Password, RoleId = 2});
                    db.SaveChanges();

                    user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password)
                        .FirstOrDefault();


                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Mem");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Mem");
        }
    }
}