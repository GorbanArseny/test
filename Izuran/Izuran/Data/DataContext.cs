using Izuran.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Izuran.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base (options)
        {
            
        }

       
        public DbSet<Item> Items { get; set; }
    }
}
