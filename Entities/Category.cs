using Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("categories")]
    public class Category:DbEntity
    {
        [MaxLength(32)]
        [Column("name")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
