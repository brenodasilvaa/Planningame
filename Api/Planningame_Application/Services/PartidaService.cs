using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Application.Services
{
    internal class PartidaService(IPartidaRepository repository, IUnityOfWork unityOfWork) : IPartidaService
    {
        public async Task<Guid> Criar(Partida partida, CancellationToken cancellation)
        {
            await repository.Criar(partida, cancellation);

            await unityOfWork.SaveAsync();

            return partida.Id;
        }

        public async Task<Partida> GetById(Guid id, CancellationToken cancellation)
        {
            var partida = await repository.GetById(id, cancellation);

            if (partida == null)
                throw new ApplicationException("Partida não encontrada");

            return partida;
        }
    }
}
