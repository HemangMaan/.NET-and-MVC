using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ProductsController : Controller
    {
        IRepository<Product, int> _repository;

        public ProductsController(IRepository<Product,int> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = _repository.FindAll();
            return View(model: model);
        }
        
        public IActionResult Details(int id)
        {
            string role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            if(!role.ToLower().Contains("admin"))
                return Redirect("/home/accessdenied");
            var model = _repository.FindById(id);
            if(model == null)
                return NotFound();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new Product();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Product model) 
        {
            //=> Request provides this data, ASP.NET Runtime uses a ModelBinder
            //This modelBinder takes each input element and assigns it to the model
            //In case the assignment fails, the state of the model is marked as invalid.
            if(!ModelState.IsValid)
                return View(model);
            try
            {
                _repository.AddNew(model);
            }
            catch (Exception)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = _repository.FindById(id);
            if(model != null)
                return View(model);
            else
                return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _repository.Update(model);
            }
            catch(Exception ex)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var model = _repository.FindById(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else 
                return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
