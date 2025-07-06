using Microsoft.EntityFrameworkCore;
using Recuriment_Platform.Models;

namespace Recuriment_Platform.Data
{
    public class MyContextDB : DbContext
    {
        public MyContextDB(DbContextOptions<MyContextDB> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Apply> Applies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite key for Apply
            modelBuilder.Entity<Apply>()
                .HasKey(a => new { a.JobId, a.CandidateId });

            // Configure relationships
            modelBuilder.Entity<Apply>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applies) // Assumes Job has List<Apply> Applies
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Apply>()
                .HasOne(a => a.Candidate)
                .WithMany(c => c.Applies) // Assumes Candidate has List<Apply> Applies
                .HasForeignKey(a => a.CandidateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}