using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningGame_Tests.Fakers
{
    internal class RodadasRepoFaker : IRodadaRepository
    {
        public Task<Guid> Criar(Rodada rodada, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Rodada?> GetById(Guid rodadaId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Jogador>> GetByPartidaId(Guid partidaId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
