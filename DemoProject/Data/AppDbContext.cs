using DemoProject.Data.model;
using DemoProject.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        // M:N RelationShip
        public DbSet<RelationShip> Relationships { get; set; }
       
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the M:N relationship
            modelBuilder.Entity<RelationShip>()
                .HasKey(Pd => new { Pd.PatId, Pd.DocId });

            modelBuilder.Entity<RelationShip>()
                .HasOne(Pd => Pd.patient)
                .WithMany(P => P.Relationships)
                .HasForeignKey(Pd => Pd.PatId);

            modelBuilder.Entity<RelationShip>()
                .HasOne(Pd => Pd.doctor)
                .WithMany(D => D.Relationships)
                .HasForeignKey(Pd => Pd.DocId);
        }
    }
}
