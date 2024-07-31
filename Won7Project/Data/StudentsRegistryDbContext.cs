using Microsoft.EntityFrameworkCore;
using Won7Project.Models;

namespace Won7Project.Data
{
    public class StudentsRegistryDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public StudentsRegistryDbContext(DbContextOptions<StudentsRegistryDbContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
