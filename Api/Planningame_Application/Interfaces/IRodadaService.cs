using Planningame_Domain.Entidades;

namespace Planningame_Application.Interfaces
{
    public interface IRodadaService
    {
        Task<Guid> Criar(Rodada rodada, CancellationToken cancellation);
        Task<double> CalcularVotos(Guid id, CancellationToken cancellation);
    }
}
