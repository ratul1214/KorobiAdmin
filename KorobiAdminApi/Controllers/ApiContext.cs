using Microsoft.EntityFrameworkCore;
using Newweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newweb.Controllers
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> context) : base(context)
        {
            // "MyTasteDatabase": "Server=DESKTOP-K0O55OV\\SQLEXPRESS;Database=TasteDatabase;Trusted_Connection=True;"
        }
        public DbSet<Product> product { get; set; }

        public DbSet<Product_Category> product_category { get; set; }
        
        public DbSet<Product_subCategory> Product_subCategory { get; set; }
        public DbSet<Product_subSubCategory> Product_subSubCategory { get; set; }
        public DbSet<Newweb.Models.Product_Price> Product_Price { get; set; }
        public DbSet<Newweb.Models.PublisherList> PublisherList { get; set; }
        public DbSet<Newweb.Models.WriterList> WriterList { get; set; }
    }
}
