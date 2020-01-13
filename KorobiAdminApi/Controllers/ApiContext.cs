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
    }
}
