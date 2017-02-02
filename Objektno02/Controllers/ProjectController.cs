using handling_projects.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace handling_projects.Controllers
{
    public class ProjectController : Controller
    {

        [HttpGet]
        [Authorize]
        public ActionResult My()
        {
            Models.UserProfileSessionData profileData = (Models.UserProfileSessionData)Session["userProfile"];
            
            var user = new Models.KorisnickiRacun();
            if (!user.hasTeam(profileData.UserId))
            {
                return RedirectToAction("All", "Project");
            }
            if (user.isLeader(profileData.UserId))
            {
                Models.Project project = new Models.Project(profileData.UserId);
                return View(project);
            }
            else
            {
                return RedirectToAction("Profile", "Project", new { id = profileData.UserId });
            }
        }

        [Authorize]
        public ActionResult All()
        {
            string query = "SELECT KorisnickiRacun.idKorisnickiRacun FROM KorisnickiRacun JOIN ClanTIma ON KorisnickiRacun.idKorisnickiRacun = ClanTIma.idKorisnickiRacun WHERE ClanTIma.vodja = 1";
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();

            List<Models.Project> allProjects = new List<Models.Project>();

            while (DB.reader.Read())
            {
                int userID = DB.reader.GetInt32(0);
                Models.Project project = new Models.Project(userID);
                allProjects.Add(project);
            }
            DB.reader.Dispose();
            DB.disposeHelper();

            return View(allProjects);
        }

        [Authorize]
        public ActionResult New()
        {
            Models.UserProfileSessionData profileData = (Models.UserProfileSessionData)Session["userProfile"];
            var user = new Models.KorisnickiRacun();
            if (user.hasTeam(profileData.UserId))
            {
                return RedirectToAction("My", "Project");
            }
            else
            {
            return View();
            }
            
        }

        [Authorize]
        public ActionResult Profile(int id)
        {
            Models.UserProfileSessionData profileData = (Models.UserProfileSessionData)Session["userProfile"];
            Models.Project profile = new Models.Project(id);
            profile.perspectiveId = profileData.UserId;
            Models.KorisnickiRacun user = new Models.KorisnickiRacun();
            Models.Zahtjev request = new Models.Zahtjev();


            if (request.requestSent(profileData.UserId, profile.team.idTima) || user.hasTeam(profileData.UserId))
            {
                profile.team.idStatusa = 2; 
            }
            return View(profile);
        }


        [Authorize]
        public ActionResult Delete(int idUser)
        {
            Models.Tim team = new Models.Tim(idUser);
            team.deleteTim();
            return RedirectToAction("My", "Project");
        }

        [Authorize]
        public ActionResult RemoveUser(int idUser)
        {
            Models.KorisnickiRacun user = new Models.KorisnickiRacun();
            user.leaveTeam(idUser);
            return RedirectToAction("My", "Project");
        }

        [Authorize]
        public ActionResult Lock(int idUser)
        {
            Models.Tim team = new Models.Tim(idUser);
            team.Lock(true);
            return RedirectToAction("My", "Project");
        }

        [Authorize]
        public ActionResult Unlock(int idUser)
        {
            Models.Tim team = new Models.Tim(idUser);
            team.Lock(false);
            return RedirectToAction("My", "Project");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Save(Models.Tim project)
        {
            Models.UserProfileSessionData profileData = (Models.UserProfileSessionData)Session["userProfile"];
            project.bodovi = 0;
            project.idStatusa = 1;
            project.saveTim(profileData.UserId);
            return RedirectToAction("My", "Project");
        }
        
    }
}
