using ASPnetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPnetCoreMVC.DataContext
{
    public class ASPnetNoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=AspnetNoteDb;User Id=root;Password =1234 ; ");
        }
    }
}
