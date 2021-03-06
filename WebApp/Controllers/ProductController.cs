using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ListAdmin()
        {
            return View(ProductViewModel.GetProducts(_repository));
        }

        public IActionResult List()
        {
            return View(ProductViewModel.GetProducts(_repository));
        }
        public IActionResult ListWithCat(Guid? id)
        {
            return View("List", ProductViewModel.GetProducts(_repository, id));
        }
        public IActionResult Details(Guid Id)
        {
            return View(ProductViewModel.GetProductById(_repository, Id));
        }

        public IActionResult DetailsAdmin(Guid Id)
        {
            return View(ProductViewModel.GetProductById(_repository, Id));
        }

        public IActionResult Create(ProductViewModel model)
        {
            if (model.IsEmpty())
                return View(model);

            _repository.AddItemAsync(model);
            return Redirect("ListAdmin");
        }

        public IActionResult Edit(Guid? Id)
        {
            if (Id.HasValue)
            {
            return View(ProductViewModel.GetProductById(_repository, (Guid)Id));
            } return NotFound(); 
        }

        public IActionResult Delete(Guid? id)
        {
            if (id.HasValue)
            {
                return View(ProductViewModel.DeleteProduct(_repository, (Guid)id));
            } return NotFound(); 
        }

        public IActionResult ShowSearchForm()
        {
            throw new NotImplementedException();
        }
    }
}
