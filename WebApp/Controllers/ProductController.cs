﻿using BL;
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

        public IActionResult List()
        {
            return View(ProductViewModel.GetProducts(_repository));
        }
        public IActionResult Details(Guid Id)
        {
            return View(ProductViewModel.GetProductById(_repository, Id));
        }

        public IActionResult Create(ProductViewModel model)
        {
            if (model.IsEmpty())
                return View(model);

            _repository.AddItemAsync(model);
            return Redirect("List");
        }
       
    }
}
