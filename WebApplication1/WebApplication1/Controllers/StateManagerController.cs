using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StateManagerController : Controller
    {
        const string SessionKeyCounter = "Counter";
        const string SessionKeyName = "Name";
        public IActionResult Index(int? id = 0)
        {
            if (HttpContext.Session.GetInt32(SessionKeyCounter) == null ||
            string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "Bajaj");
                HttpContext.Session.SetInt32(SessionKeyCounter, 0);
            }
            var counter = Convert.ToInt32(HttpContext.Session.GetInt32(SessionKeyCounter)) + 1;
            HttpContext.Session.SetInt32(SessionKeyCounter, counter);
            ViewData["Name"] = "This is ViewDataName";
            ViewBag.Counter = 9876543;
            TempData["Name"] = "This is from temp data";
            if(id.Value!=0)
                return RedirectToAction(nameof(Index2));
            else
                return View();
        }

        public IActionResult Index2()
        {

            return View();
        }
    }
}
