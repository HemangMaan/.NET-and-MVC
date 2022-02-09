using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        IUserServices userServices;

        public AccountController(IUserServices service)
        {
            userServices = service;
        }

        //[Route("{returnUrl}")]
        public IActionResult Login(string returnUrl="")
        {
            ViewData["ReturnUrl"]= returnUrl;
            var model = new LoginViewModel();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model, [FromQuery]string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;
            //authenticate the user
            if(!ModelState.IsValid)
                return View(model);
            
            var status = userServices.Authenticate(model);

            if (!status)
            {
                ModelState.AddModelError("", "Invalid username/password");
                return View(model);
            }
            var user = userServices.GetUser;
            var role = userServices.GetRole(user.Id);
            HttpContext.Session.SetString("Username", user.FriendlyName);
            HttpContext.Session.SetInt32("UserId",user.Id);
            
            //setup claims for the user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.FriendlyName),
                new Claim(ClaimTypes.Role,role.RoleName),
            };
            //based on the claim set, create an identity for the user 
            var identity = new ClaimsIdentity(
                claims: claims,
                authenticationType: CookieAuthenticationDefaults.AuthenticationScheme
                );
            //Authentication Properties
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = returnUrl,
                AllowRefresh = true,
                IsPersistent = false,
            };
            //define the user principal based on the set of identities provided
            var principal = new ClaimsPrincipal(identity);
            //sign in the user using the scheme, principall object and the authentication properties
            await HttpContext.SignInAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                principal: principal,
                properties : authProperties);
           
            //check whether the url is a local url
            if(Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl); //go th the return url page
            else  //the url isstarting with http://....pattern
                return Redirect("/");

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            var authProperties = new AuthenticationProperties { 
                IsPersistent = false,
                AllowRefresh = true 
            };
           
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme,authProperties);
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Clear();
            return RedirectPermanent("/");
        }
    }
}
