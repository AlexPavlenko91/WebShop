using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryViewModel
    {
        public Guid Id { get; }

        [Required] public string Name { get; set; }

        public List<Product> Products { get; }

        public CategoryViewModel(){}

        public CategoryViewModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Products = category.Products;
        }

        public static IQueryable<CategoryViewModel> GetCategories(ICategoryRepository repository)
        {
            return (repository.AllItems as DbSet<Category>)
                .Include(item => item.Products)
                .Select(item => new CategoryViewModel(item));
        }
        public static CategoryViewModel GetCategoryById(ICategoryRepository repository, Guid id)
        {
            return (repository.AllItems as DbSet<Category>)
                .Where(item => item.Id == id)
                .Include(item => item.Products)
                .Select(item => new CategoryViewModel(item))
                .First();
        }
        public static implicit operator Category(CategoryViewModel model)
        {
            return new Category
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public static bool Edited(ICategoryRepository repository, Category category)
        {
            return (repository.ChangeItemAsync(category).IsCompletedSuccessfully);
        }
        
        public static bool Update(ICategoryRepository repository, Category category)
        {
            return (repository.ChangeItemAsync(category).IsCompletedSuccessfully);
        }
        public bool IsEmpty()
        {
            return Name == null;
        }
        
        public static bool DeleteProduct(ICategoryRepository repository, Guid id)
        {
            return (repository.DeleteItemAsync(id)).IsCompletedSuccessfully;
        }
    }
}