using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace Planningame_Application.Services
{
    public class JogadoresService(IJogadorRepositoy jogadorRepositoy, 
        IPartidaRepository partidaRepository,
        IRodadaRepository rodadaRepository,
        IUnityOfWork unityOfWork) : IJogadoresService
    {
        public async Task<Guid> Criar(Jogador jogador, CancellationToken cancellation)
        {
            var rodadaAtualId = await partidaRepository.GetRodadaAtiva(jogador.PartidaId, cancellation);
            var rodadaAtual = await rodadaRepository.GetById(rodadaAtualId, cancellation);
            jogador.Rodadas.Add(rodadaAtual!);

            await jogadorRepositoy.Criar(jogador, cancellation);

            await unityOfWork.SaveAsync();

            return jogador.Id;
        }
    }
}
