using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace handling_projects.Controllers
{
    public class RequestController : Controller
    {

        public ActionResult Send(int idUser,int idTeam)
        {
            Models.Zahtjev request = new Models.Zahtjev();
            request.send(idUser, idTeam);
            return RedirectToAction("My", "Project");
        }

        public ActionResult Accept(int idUser, int idTeam)
        {
            Models.Zahtjev request = new Models.Zahtjev();
            request.accept(idUser, idTeam);
            return RedirectToAction("My", "Project");
        }

        public ActionResult Decline(int idUser, int idTeam)
        {
            Models.Zahtjev request = new Models.Zahtjev();
            request.decline(idUser, idTeam);
            return RedirectToAction("My", "Project");
        }

    }
}
