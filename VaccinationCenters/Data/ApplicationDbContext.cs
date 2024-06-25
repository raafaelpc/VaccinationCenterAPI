using Microsoft.EntityFrameworkCore;
using VaccinationCenters.Models;

namespace VaccinationCenters.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<VaccinationCenter> VaccinationCenters { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaccinationCenter>()//Validação Nome igual do posto de vacinação
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Vaccine>()//Validação Lote igual da vacina
                .HasIndex(x => x.Batch)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
