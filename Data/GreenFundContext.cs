using GreenFundGS.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenFundGS.Data
{
    /// <summary>
    /// Representa a classe GreenFundContext para manipulação de dados.
    /// </summary>
    public class GreenFundContext : DbContext
    {
        public GreenFundContext(DbContextOptions<GreenFundContext> options) : base(options) { }

        /// <summary>
        /// DbSet para a entidade Usuario.
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// DbSet para a entidade Project.
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// DbSet para a entidade Donation.
        /// </summary>
        public DbSet<Donation> Donations { get; set; }

        /// <summary>
        /// DbSet para a entidade Reward.
        /// </summary>
        public DbSet<Reward> Rewards { get; set; }

        /// <summary>
        /// Configurações adicionais do modelo.
        /// </summary>
        /// <param name="modelBuilder">Construtor do modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para renomear a tabela Projects para Projetos
            modelBuilder.Entity<Project>().ToTable("Projetos");

            modelBuilder.Entity<Usuario>().ToTable("USUARIOS");

            modelBuilder.Entity<Donation>()
                .Property(d => d.ValorDoado)
                .HasPrecision(18, 2);
        }
    }
}
