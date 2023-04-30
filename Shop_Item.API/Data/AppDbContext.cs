using Microsoft.EntityFrameworkCore;
using Shop_Item.API.Data.Models;

namespace Shop_Item.API.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }

        public  DbSet<Shop>  Shop { get; set; }

        public DbSet<Item> Item { get; set; }


    }
}
