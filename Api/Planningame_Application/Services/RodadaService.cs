using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace Planningame_Application.Services
{
    internal class RodadaService(IRodadaRepository rodadaRepositoy, 
        IJogadorRepositoy jogadorRepositoy, IUnityOfWork unityOfWork) : IRodadaService
    {
        public async Task<Guid> Criar(Rodada rodada, CancellationToken cancellation)
        {
            await rodadaRepositoy.Criar(rodada, cancellation);

            var jogadores = await jogadorRepositoy.GetByPartidaId(rodada.PartidaId, cancellation);

            rodada.Jogadores = jogadores.ToList();

            await unityOfWork.SaveAsync();

            return rodada.Id;
        }
    }
}
