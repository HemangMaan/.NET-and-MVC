using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category, int> _repository;

        public CategoryController(IRepository<Category,int> repository)
        {
            _repository = repository;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var model = _repository.FindAll();
            return View(model: model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var model = _repository.FindById(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            var model = new Category();
            return View(model);
        }

        // POST: CategoryController/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _repository.AddNew(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _repository.FindById(id);
            if (model != null)
                return View(model);
            else
                return RedirectToAction(nameof(Index));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _repository.Update(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _repository.FindById(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return View(model);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repository.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
