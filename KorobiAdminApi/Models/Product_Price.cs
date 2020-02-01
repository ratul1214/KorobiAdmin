using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newweb.Models
{
    public class Product_Price
    {
        [Key]
        public int price_id { get; set; }
        [Column(TypeName = "int")]
        public int product_id { get; set; }
        [Column(TypeName = "int")]
        public int price_type { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string active_flag { get; set; }
        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }
        [Column(TypeName = "float")]
        public float price { get; set; }
        [Column(TypeName = "int")]
        public int created_by { get; set; }
        [Column(TypeName = "date")]
        public DateTime creation_date { get; set; }
        [Column(TypeName = "int")]
        public int last_updated_by { get; set; }
        [Column(TypeName = "date")]
        public DateTime last_update_date { get; set; }
        
    }
}
