using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookinigPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Clifford Wallce!";

            string sPortalType = "";
            if (Roles.IsUserInRole(User.Identity.Name, "Customer")) sPortalType = "Customer";
            else if (Roles.IsUserInRole(User.Identity.Name, "Employee")) sPortalType = "Employee";
            else if (Roles.IsUserInRole(User.Identity.Name, "Administrator")) sPortalType = "Admin";

            ViewBag.PortalType = sPortalType;

            return Redirect("~/news");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            ViewBag.Title = "Calendar";
            return View();
        }

    }
}
