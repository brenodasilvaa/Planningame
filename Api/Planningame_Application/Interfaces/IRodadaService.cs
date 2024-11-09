using Planningame_Domain.Entidades;

namespace Planningame_Application.Interfaces
{
    public interface IRodadaService
    {
        Task<Guid> Criar(Rodada jogador, CancellationToken cancellation);
    }
}
