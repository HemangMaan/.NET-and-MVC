using Microsoft.AspNetCore.Mvc;
using NorthwindWebAPI.Models;

namespace NorthwindWebAPI.Controllers
{
    public class AccountController : Controller
    {
        IUserServices _userServices;
        public AccountController(IUserServices service) => _userServices = service;
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginModel model)
        {
            var status = _userServices.Authenticate(model);
            if(status == null)
            {
                return BadRequest(new { message = "Username and/or password is incorrect." });
            }
            return Ok(status);
        }

    }
}
