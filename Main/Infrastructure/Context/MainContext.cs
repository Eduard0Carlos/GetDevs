using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Database;
using System.Reflection;

namespace Infrastructure
{
    public class MainContext : DbContext 
    {

        protected DbSet<Announcement> Announcements;
        protected DbSet<BusinessBond> BusinessBonds;
        protected DbSet<CandidateAnnouncement> AnnouncementCandidate;
        protected DbSet<Company> Companies;
        protected DbSet<Course> Courses;
        protected DbSet<Education> Educations;
        protected DbSet<Resume> Resumes;
        protected DbSet<ResumeAI> ResumesAI;
        protected DbSet<User> User;
        protected DbSet<Candidate> Candidates;

        public MainContext(DbContextOptions<MainContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlDataBase.CONNECTION_STRING);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
