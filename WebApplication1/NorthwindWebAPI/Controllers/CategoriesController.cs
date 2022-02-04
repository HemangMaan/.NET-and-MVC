using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatawindDataAccess.Infrastructure;
using DatawindDataAccess.Models;
namespace NorthwindWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        iCategoryRepository<Category, int> _repository;
        public CategoriesController(iCategoryRepository<Category, int> repository)
            => _repository = repository;


        //URL: /categories/list
        [HttpGet("list")]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var model = _repository.FindAll();
            if (model == null)
                return NotFound();
            return model.ToList();
        }

        [HttpGet("details/{id}")]
        public ActionResult<Category> GetDetails(int id)
        {
            if (id == 0)
                return BadRequest();
            var model = _repository.FindById(id);
            if (model == null)
                return NotFound();
            else
                return model;
        }

        [HttpPost("create")]
        public ActionResult<Category> CreateNew(Category model)
        {
            if(model == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest();
            _repository.AddNew(model);
            return model;
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id,Category model)
        {
            if(model==null || id==0 || !ModelState.IsValid) return BadRequest();
            if(_repository.FindById(id)==null) return NotFound();

            if(id !=model.CategoryId) return BadRequest();
            _repository.Update(model);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteById(id);
            return Ok();
        }



    }
}
