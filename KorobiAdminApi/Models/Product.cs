using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newweb.Models
{
    public class Product
    {
        [Key]
        public string SKU { get; set; }
        [Column(TypeName="nvarchar(255)")]
        public string title { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Brand { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string producer { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string shortDetails { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string description { get; set; }
        [Column(TypeName = "int")]
        public int catagory_id { get; set; }
        [Column(TypeName = "int")]
        public int subCategory_id { get; set; }
        [Column(TypeName = "int")]
        public int subSubCategory_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string product_status { get; set; }
        [Column(TypeName = "date")]
        public DateTime updated { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Product_Currency { get; set; }
        [Column(TypeName = "int")]
        public int price_id { get; set; }
        [Column(TypeName = "int")]
        public int stock { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string images { get; set; }
        [Column(TypeName = "date")]
        public DateTime created { get; set; }


}
}
