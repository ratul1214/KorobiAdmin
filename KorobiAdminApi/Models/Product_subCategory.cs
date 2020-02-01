using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newweb.Models
{
    public class Product_subCategory
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string subCategory { get; set; }
        [Column(TypeName = "int")]
        public int parentCategoryId { get; set; }
        [Column(TypeName = "date")]
        public DateTime date { get; set; }
    }
}
