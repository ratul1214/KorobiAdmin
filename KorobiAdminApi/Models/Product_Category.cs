using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newweb.Models
{
    public class Product_Category
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string category { get; set; }
        [Column(TypeName = "date")]
        public DateTime date { get; set; }
    }
}
