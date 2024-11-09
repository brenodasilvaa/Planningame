using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planningame_Domain.Entidades;

namespace Inspira.Infrastructure.DbMappings
{
    internal class RodadaMap : IEntityTypeConfiguration<Rodada>
    {
        public void Configure(EntityTypeBuilder<Rodada> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Partida).WithMany(x => x.Rodadas).HasForeignKey(x => x.PartidaId);
        }
    }
}
