using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingList.Models;

namespace ShoppingList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Item> items { get; set; }
        
    }
}
