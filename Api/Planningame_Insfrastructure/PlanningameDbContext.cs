using Microsoft.EntityFrameworkCore;
using Planningame_Domain.Entidades;

namespace Planningame_Insfrastructure
{
    public class PlanningameDbContext : DbContext
    {
        public PlanningameDbContext(DbContextOptions<PlanningameDbContext> options) : base(options)
        {
        }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Rodada> Rodadas { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(100);
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanningameDbContext).Assembly);
        }

    }
}
