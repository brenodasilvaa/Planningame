using Planningame_Domain.Entidades;

namespace Planningame_Domain.Interfaces.Repositorios
{
    public interface IRodadaRepository
    {
        Task<Guid> Criar(Rodada rodada, CancellationToken cancellation);
        Task<Rodada?> GetById(Guid rodadaId, CancellationToken cancellation);
    }
}
