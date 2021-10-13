using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class MainContext : DbContext 
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
