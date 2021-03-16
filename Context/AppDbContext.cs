using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAsset> ProductAssets { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product => { 

                product.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId);

                product.Property(p => p.Price)
                    .HasColumnType("smallmoney");

                product.HasMany(p => p.Assets)
                    .WithMany(a => a.Products)
                    .UsingEntity<ProductAsset>(
                        j => j.HasOne(pa => pa.Asset)
                              .WithMany(a => a.ProductAssets)
                              .HasForeignKey(pa => pa.AssetId)
                              .HasPrincipalKey(a => a.Id),

                        j => j.HasOne(pa => pa.Product)
                              .WithMany(p => p.ProductAssets)
                              .HasForeignKey(pa => pa.ProductId)
                              .HasPrincipalKey(p => p.Id),      //необязятельно, написали для примера,
                                                                //используется для указания форейн кей на поле  которе не primary
                                                                //если мы используем primary, то связь идет по умолчанию
                        pa => pa.HasKey(pa => new { pa.ProductId, pa.AssetId })
                  );
            });

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = Guid.NewGuid(), Name = "Пиво разливное" },
                    new Category { Id = Guid.NewGuid(), Name = "Пиво бутылочное" },
                    new Category { Id = Guid.NewGuid(), Name = "Снеки" }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
