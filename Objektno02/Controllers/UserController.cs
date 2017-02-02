using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace handling_projects.Controllers
{
    public class UserController : Controller
    {

        [Authorize]
        public ActionResult SetSession(int id)
        {
            var user = new Models.KorisnickiRacun(id);
            var profileData = new Models.UserProfileSessionData
            {

                UserId = user.idKorisnickiRacun,
                UserName = user.korisnickoIme,
                NameSurname = user.imePrezime
            };

            Session["userProfile"] = profileData;
            return RedirectToAction("My", "Project");
        }


        [HttpGet]
        public ActionResult Login()
        {   
             return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.KorisnickiRacun user)
        {
            if (ModelState.IsValid)
            {   
                if (user.IsValid())
                {
                    FormsAuthentication.SetAuthCookie(user.imePrezime, user.zapamtiMe);
                    return RedirectToAction("SetSession", "User", new { id = user.idKorisnickiRacun });
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}
