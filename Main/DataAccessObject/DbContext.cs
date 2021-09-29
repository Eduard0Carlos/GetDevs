using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessObject
{
    public class ErpDbContext : DbContext 
    {
        DbSet<Announcement> Announcements { get; set; }
        DbSet<BusinessBond> BusinessBonds { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Education> Educations { get; set; }
        DbSet<Idiom> Idioms { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<Resume> Resumes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
