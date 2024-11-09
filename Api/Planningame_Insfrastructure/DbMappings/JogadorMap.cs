using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planningame_Domain.Entidades;

namespace Planningame_Insfrastructure.DbMappings
{
    public class JogadorMap : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Partida).WithMany(x => x.Jogadores).HasForeignKey(x => x.PartidaId);
            builder.Property(x => x.Nome).HasMaxLength(500);
        }
    }
}
