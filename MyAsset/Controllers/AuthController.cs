using MyAsset.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;

namespace MyAsset.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult LogIn(string returnUrl)
        {
           
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            //空專案加入claim base
            //http://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1
            if (!ModelState.IsValid)
            {
                return View();
            }

            // 
            if (model.Email == "a@b.com" && model.Password == "1234")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "BRIAN"));
                claims.Add(new Claim(ClaimTypes.Email, "a@b.com"));
                claims.Add(new Claim(ClaimTypes.Role, "skilltree"));
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(identity);
                return Redirect(getRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "錯誤的帳號或密碼");
            return View();
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
        private string getRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
    }
}