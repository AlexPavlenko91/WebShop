using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BL
{
    public class ProductViewModel
    {
        public Guid Id { get; }

        [Required] public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Guid> Images { get; set; } = new List<Guid>();

        public ProductViewModel()
        {
        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            CategoryId = product.CategoryId;
            CategoryName = product.Category?.Name;
            Description = product.Description;
            Price = product.Price;
            Images = product.Assets.Select(a => a.Id).ToList();
        }

        public bool IsEmpty()
        {
            return Name == null;
        }

        public static implicit operator Product(ProductViewModel model)
        {
            return new Product
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Description = model.Description,
                ProductAssets = model.Images.Select(
                    img => new ProductAsset {AssetId = img, ProductId = model.Id}).ToList()
            };
        }

        public static IQueryable<ProductViewModel> GetProducts(IProductRepository repository, Guid? catId = null)
        {
            if (catId.HasValue)
                return (repository.AllItems as DbSet<Product>)
                    .Where(item => item.CategoryId == catId)
                    .Include(item => item.Category)
                    .Include(item => item.Assets)
                    .Select(item => new ProductViewModel(item));
            else
                return (repository.AllItems as DbSet<Product>)
                    .Include(item => item.Category)
                    .Include(item => item.Assets)
                    .Select(item => new ProductViewModel(item));
        }

        public static ProductViewModel GetProductById(IProductRepository repository, Guid id)
        {
            return (repository.AllItems as DbSet<Product>)
                .Where(item => item.Id == id)
                .Include(item => item.Category)
                .Include(item => item.Assets)
                .Select(item => new ProductViewModel(item))
                .First();
        }

        public static IQueryable<ProductViewModel> Edit(IProductRepository repository, Guid id)
        {
            return GetProducts(repository, id);
        }

        public static bool DeleteProduct(IProductRepository repository, Guid id)
        {
            return (repository.DeleteItemAsync(id)).IsCompletedSuccessfully;
        }
    }
}