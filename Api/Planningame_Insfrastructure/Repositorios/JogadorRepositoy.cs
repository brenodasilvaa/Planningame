using Microsoft.EntityFrameworkCore;
using Planningame_Domain.Entidades;
using Planningame_Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Interfaces.Repositorios
{
    internal class JogadorRepositoy(PlanningameDbContext context) : IJogadorRepository
    {
        public async Task<Guid> Criar(Jogador jogador, CancellationToken cancellation)
        {
            await context.Jogadores.AddAsync(jogador);

            return jogador.Id;
        }

        public async Task<IEnumerable<Jogador>> GetByPartidaId(Guid partidaId, CancellationToken cancellation)
        {
            return await context.Jogadores.Where(x => x.PartidaId == partidaId).ToListAsync(cancellation);
        }
    }
}
