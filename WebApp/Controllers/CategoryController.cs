using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;


namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        // GET: CategoryController
        
        public IActionResult List()
        {
            return View(CategoryViewModel.GetCategories(_repository));
        }
        

       
       
        public ActionResult Create(CategoryViewModel model)
        {
            if (model.IsEmpty())
                return View(model);

            _repository.AddItemAsync(model);
            return Redirect("List");
        }

        public IActionResult Edit(Guid? Id)
        {
            if (Id.HasValue)
            {
                
                return View(CategoryViewModel.GetCategoryById(_repository, Id.Value));
            } return NotFound(); 
        }
        public IActionResult EditAccept(CategoryViewModel cat)
        {
            //_repository.ChangeItemAsync(cat);
            CategoryViewModel.Update(_repository,cat);
            return Redirect("List");
        }
        
        public IActionResult Delete(Guid? id)
        {
            if (id.HasValue)
            {
                return View(CategoryViewModel.DeleteProduct(_repository, (Guid)id));
            } return NotFound(); 
        }
    }
}
