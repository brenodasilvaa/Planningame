using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Insfrastructure.Repositorios
{
    internal class VotoRepository(PlanningameDbContext context) : IVotoRepository
    {
        public async Task<Guid> Criar(Voto voto, CancellationToken cancellation)
        {
            await context.Votos.AddAsync(voto, cancellation);

            return voto.Id;
        }
    }
}
