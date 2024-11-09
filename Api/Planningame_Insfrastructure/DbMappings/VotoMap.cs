using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Planningame_Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Insfrastructure.DbMappings
{
    public class VotoMap : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.HasKey(v => v.Id);
            builder.HasOne(x => x.Jogador).WithMany(x => x.Votos).HasForeignKey(x => x.JogadorId);
            builder.HasOne(x => x.Rodada).WithMany(x => x.Votos).HasForeignKey(x => x.RodadaId);
        }
    }
}
