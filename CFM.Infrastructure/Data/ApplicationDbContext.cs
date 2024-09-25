using CFM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFM.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Data)
                      .IsRequired()
                      .HasColumnType("date");

                entity.Property(e => e.Valor)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)")
                      .HasDefaultValue(0);

                entity.Property(e => e.Descricao)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.Categoria)
                      .IsRequired();
            });
        }
    }
}
