using BSVEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BSVEFCore.DBContext
{
    public class BSVDBContext:DbContext
    {
        public BSVDBContext(DbContextOptions<BSVDBContext>options):base(options)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasOne(d => d.Departments)
                .WithMany(e => e.Employees)
                .HasForeignKey(d => d.D_Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
