﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessObject
{
    public class ErpDbContext : DbContext 
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<BusinessBond> BusinessBonds { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Idiom> Idioms { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}