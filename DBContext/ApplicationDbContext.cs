using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;
namespace ECommerceApp.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Tables
        public DbSet<User> Users { get; set; }

    }
}
