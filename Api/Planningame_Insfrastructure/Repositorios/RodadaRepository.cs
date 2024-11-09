using Planningame_Domain.Entidades;
using Planningame_Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Interfaces.Repositorios
{
    public class RodadaRepository(PlanningameDbContext context) : IRodadaRepository
    {
        public async Task<Guid> Criar(Rodada rodada, CancellationToken cancellation)
        {
            await context.Rodadas.AddAsync(rodada, cancellation);

            return rodada.Id;
        }
    }
}
