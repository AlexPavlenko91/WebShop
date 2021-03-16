using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("goods")]
    public class Product : DbEntity
    {
        [MaxLength(64)]
        [Column("name")]
        public string Name { get; set; }
        
        [Column("price")]
        public decimal Price { get; set; }

        [MaxLength(256)]
        [Column("description")]
        public string Description { get; set; }

        [Column("categoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Asset> Assets { get; set; }
        public List<ProductAsset> ProductAssets { get; set; }


        
    }
}
