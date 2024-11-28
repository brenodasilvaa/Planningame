using Mapster;
using Microsoft.AspNetCore.Mvc;
using Planningame_Api.Commands;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace Planningame_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotoController(IVotoRepository repository, IUnityOfWork unityOfWork) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Votar(CreateVotoCommand command, CancellationToken cancellation)
        {
            Guid votoId;
            
            var voto = await repository.GetByRodadaId(command.RodadaId, cancellation);

            if (voto == null)
                return await CriarVoto();

            var votoJogador = voto.FirstOrDefault(x => x.JogadorId == command.JogadorId);

            if (votoJogador == null)
                return await CriarVoto();

            if (votoJogador.Rodada.Brindou)
                return Ok(votoJogador.Id);

            votoJogador.Valor = command.Valor;
            await unityOfWork.SaveAsync();
            return Ok(votoJogador.Id);

            async Task<IActionResult> CriarVoto()
            {
                votoId = await repository.Criar(command.Adapt<Voto>(), cancellation);
                await unityOfWork.SaveAsync();
                return Ok(votoId);
            }
        }
    }
}
