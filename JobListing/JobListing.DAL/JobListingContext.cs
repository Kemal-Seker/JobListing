using JobListing.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.DAL
{
    public class JobListingContext:DbContext,IDisposable
    {
        public JobListingContext():base("JobListingConnection")
        {

        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<JobRequirement>().ToTable("JobRequirement");
            modelBuilder.Entity<Resume>().ToTable("Resume");
            modelBuilder.Entity<Tag>().ToTable("Tag");

            modelBuilder.Entity<Job>()
                .HasMany<Tag>(j => j.Tags)
                .WithMany(t => t.Jobs)
                .Map(rm =>
                {
                    rm.MapLeftKey("JobId");
                    rm.MapRightKey("TagId");
                    rm.ToTable("JobTag");
                });

            modelBuilder.Entity<Job>()
                .HasMany<Category>(j => j.Categories)
                .WithMany(c=>c.Jobs)
                .Map(rm =>
                {
                    rm.MapLeftKey("JobId");
                    rm.MapRightKey("CategoryId");
                    rm.ToTable("JobCategory");
                });

            modelBuilder.Entity<Application>()
                .HasRequired(a => a.Resume).WithOptional().WillCascadeOnDelete(false);
        }
    }
}
