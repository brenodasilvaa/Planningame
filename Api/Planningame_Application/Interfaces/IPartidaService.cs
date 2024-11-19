using Planningame_Application.Models;
using Planningame_Domain.Entidades;

namespace Planningame_Application.Interfaces
{
    public interface IPartidaService
    {
        Task<CriarPartidaDto> Criar(Partida partida, CancellationToken cancellation);
        Task<Partida> GetById(Guid id, CancellationToken cancellation);
    }
}
