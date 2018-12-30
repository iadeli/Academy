using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Academy.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            return View();
        }
    }
}