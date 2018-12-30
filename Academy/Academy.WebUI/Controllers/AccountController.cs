using Academy.WebUI.Models;
using Academy.WebUI.Tools;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using UserManagement.Application.Contracts;

namespace Academy.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
            var identity = _authenticationService.Authenticate(model.Username, model.Password);

            if (identity != null)
            {
                var properties = AuthenticationPropertiesFactory.Create(model.RememberMe);                

                Request.GetOwinContext().Authentication.SignIn(properties, identity);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }

            //if (model.Username == "admin" && model.Password == "123456")
            //{
            //    var identity = new ClaimsIdentity("ApplicationCookie");
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Ismail"));
            //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            //    identity.AddClaim(new Claim("EyeColor", "Green"));

            //    var properties = new AuthenticationProperties
            //    {
            //        IsPersistent = model.RememberMe,
            //        ExpiresUtc = DateTime.Now.AddYears(1)
            //    };

            //    Request.GetOwinContext().Authentication.SignIn(properties, identity);

            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }
    }
}