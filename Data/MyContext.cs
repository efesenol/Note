using Microsoft.EntityFrameworkCore;
using Note.Entities;


namespace Note.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserNote> UserNote { get; set; }
    }
    
}