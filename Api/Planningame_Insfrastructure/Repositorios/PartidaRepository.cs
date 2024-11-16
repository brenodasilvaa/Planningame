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
    public class PartidaRepository(PlanningameDbContext dbContext) : IPartidaRepository
    {
        public async Task<Partida> Criar(Partida partida, CancellationToken cancellation)
        {
            await dbContext.Partidas.AddAsync(partida);

            return partida;
        }

        public async Task<Partida?> GetById(Guid id, CancellationToken cancellation)
        {
            return await dbContext.Partidas
                .Include(x => x.Jogadores)
                .Include(x => x.Rodadas)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Guid> GetRodadaAtiva(Guid id, CancellationToken cancellation)
        {
            return (await dbContext.Rodadas
                .Where(x => x.PartidaId == id)
                .OrderByDescending(x => x.Numero).FirstAsync(cancellationToken: cancellation)).Id;
        }
    }
}
