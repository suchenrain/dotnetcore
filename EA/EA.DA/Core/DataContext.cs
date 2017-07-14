using EA.Common.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EA.DA.Core
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
        {
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=EA.DA;Integrated Security=true; Timeout=500000;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #region Entities representing Database objects

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobTask> JobTask { get; set; }
        public DbSet<JobWorker> JobWorker { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }


        #endregion Entities representing Database objects
    }
}