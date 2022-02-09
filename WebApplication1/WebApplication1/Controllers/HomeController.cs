using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //URL: http://localhost:XXXXHome/SayHello
        public string SayHello() => "Hello World!";

        //URL: /Home/today
        public string Today() => DateTime.Now.ToString();

        //URL: /Home/tommorow
        [ActionName("tommorow")]
        public string GetTommorow() => DateTime.Now.AddDays(1).ToString();

        //URL: /home/NextDate/5
        [Route("/home/nextdate/{days}")]
        public string NextDate(int days) => DateTime.Now.AddDays(days).ToString();

        public string ReturnId(int id) => (id + 100).ToString();

        public Student getstudent()
        {
            Student student = new Student();
            student.Id = 1000;
            student.Name = "Hemang";
            return student;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}