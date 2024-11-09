using Planningame_Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Interfaces.Repositorios
{
    public interface IVotoRepository
    {
        Task<Guid> Criar(Voto voto, CancellationToken cancellation);
    }
}
