using Microsoft.EntityFrameworkCore;
using SND.SystemManagementCustomer.Repository.Entities;

namespace SND.SystemManagementCustomer.Repository
{
    public class SystemManagementContext : DbContext
    {
        public DbSet<CustomerDTO> CustomerDTO { get; set; }
        public SystemManagementContext(DbContextOptions<SystemManagementContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<CustomerDTO>().HasNoKey().ToView(null);
        }
    }
}