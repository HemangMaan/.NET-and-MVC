using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("hello")]
        public string Sayhello()
        {
            return "Welcome, from WEB API";
        }

        [HttpGet("today")]
        public string Today()
        {
            return DateTime.Now.ToString();
        }

        //url: /home/nextday/10
        [HttpGet("nextday/{days}")]
        public string NextDay(int days)
        {
            return DateTime.Now.AddDays(days).ToString();
        }
        [HttpGet("json")] //URL: /home/json
        public string GetJson()
        {
            var obj = new { Id = 1234, name = "Bajaj", Location = "Bangalore" };
            var jsonStr = System.Text.Json.JsonSerializer.Serialize(obj);
            return jsonStr;
        }

        [HttpGet("Category")]
        public DatawindDataAccess.Models.Category GetCategory()
        {
            var obj = new DatawindDataAccess.Models.Category
            {
                CategoryId = 1,
                CategoryName = "Stationary",
                CategoryDescription = "All stationary items are under this category"
            };
            return obj;
        }

        [HttpGet("categories/{id}")]
        public IActionResult GetCategoryDetails(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            if(id==0 || id > 10)
            {
                return NotFound();
            }
            var obj = new DatawindDataAccess.Models.Category
            {
                CategoryId = 1,
                CategoryName = "Stationary",
                CategoryDescription = "All stationary items are under this category"
            };
            return Ok(obj);
        }

        [HttpGet("allcategories/{id}")]
        public ActionResult<DatawindDataAccess.Models.Category> GetCategoryItems(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            if (id == 0 || id > 10)
            {
                return NotFound();
            }
            var obj = new DatawindDataAccess.Models.Category
            {
                CategoryId = 1,
                CategoryName = "Stationary",
                CategoryDescription = "All stationary items are under this category"
            };
            return obj; //returns HHTP-status - 200-OK
        }
    }
}
