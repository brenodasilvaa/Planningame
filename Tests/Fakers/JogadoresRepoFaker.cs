using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningGame_Tests.Fakers
{
    internal class JogadoresRepoFaker : IJogadorRepository
    {
        public async Task<Guid> Criar(Jogador jogador, CancellationToken cancellation)
        {
            return await Task.FromResult(Guid.NewGuid());
        }

        public Task<IEnumerable<Jogador>> GetByPartidaId(Guid partidaId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
