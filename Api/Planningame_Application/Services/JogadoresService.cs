using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace Planningame_Application.Services
{
    internal class JogadoresService(IJogadorRepositoy jogadorRepositoy, IUnityOfWork unityOfWork) : IJogadoresService
    {
        public async Task<Guid> Criar(Jogador jogador, CancellationToken cancellation)
        {
            await jogadorRepositoy.Criar(jogador, cancellation);

            await unityOfWork.SaveAsync();

            return jogador.Id;
        }
    }
}
