using Planningame_Application.Interfaces;
using Planningame_Application.Models;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace Planningame_Application.Services
{
    internal class RodadaService(IRodadaRepository rodadaRepositoy, 
        IJogadorRepositoy jogadorRepositoy, IVotoRepository votoRepository,
        IUnityOfWork unityOfWork) : IRodadaService
    {
        public async Task Brindar(Guid id, CancellationToken cancellation)
        {
            var rodada = await rodadaRepositoy.GetById(id, cancellation);

            if (rodada == null)
                throw new ApplicationException("Rodada não encontrada");

            rodada.Brindou = true;

            await unityOfWork.SaveAsync();
        }

        public async Task<double> CalcularVotos(Guid id, CancellationToken cancellation)
        {
            var votos = await votoRepository.GetByRodadaId(id, cancellation);

            var mediaVotos = votos.Select(x => x.Valor).Average();

            return mediaVotos;
        }

        public async Task<Guid> Criar(Rodada rodada, CancellationToken cancellation)
        {
            await rodadaRepositoy.Criar(rodada, cancellation);

            var jogadores = await jogadorRepositoy.GetByPartidaId(rodada.PartidaId, cancellation);

            rodada.Jogadores = jogadores.ToList();

            await unityOfWork.SaveAsync();

            return rodada.Id;
        }

        public async Task<Rodada> GetInfo(Guid id, CancellationToken cancellation)
        {
            var rodada = await rodadaRepositoy.GetById(id, cancellation);

            if (rodada == null)
                throw new ApplicationException("Rodada não encontrada");

            return rodada;
        }
    }
}
