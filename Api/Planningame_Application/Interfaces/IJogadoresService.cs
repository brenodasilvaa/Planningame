using Planningame_Domain.Entidades;

namespace Planningame_Application.Interfaces
{
    public interface IJogadoresService
    {
        Task<Guid> Criar(Jogador jogador, CancellationToken cancellation);
    }
}
