using Planningame_Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Interfaces.Repositorios
{
    public interface IJogadorRepositoy
    {
        Task<Guid> Criar(Jogador jogador, CancellationToken cancellation);
        Task<IEnumerable<Jogador>> GetByPartidaId(Guid partidaId, CancellationToken cancellation);
    }
}
