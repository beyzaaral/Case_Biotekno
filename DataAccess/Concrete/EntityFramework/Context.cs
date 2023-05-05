using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // hangi vt ile ilişkilendirdiğimizi gösterdiğimiz yer 
        {
            optionsBuilder.UseSqlServer(@"Server=Beyza-ARAL;Database=Case;Trusted_Connection=true"); // peki hangi veri tabanına bağlanıcam onun cevabı(SQL düzenlendikten sonra bağlanacaktır)
        }

        
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
