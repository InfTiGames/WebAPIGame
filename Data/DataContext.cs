using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Data
{
    // This class is used to interact with the database
    public class DataContext : DbContext {
        // This is the constructor for the DataContext class
        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Character> Characters { get; set; }

    }
}