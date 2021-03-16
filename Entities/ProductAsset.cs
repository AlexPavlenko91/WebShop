using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("goods_assets")]
    public class ProductAsset
    {
        public Product Product { get; set; }
        public Asset Asset { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("asset_id")]
        public Guid AssetId { get; set; }
    }
}
