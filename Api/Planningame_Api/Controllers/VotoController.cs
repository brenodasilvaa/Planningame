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
        public async Task<IActionResult> Create(CreateVotoCommand command, CancellationToken cancellation)
        {
            var votoId = await repository.Criar(command.Adapt<Voto>(), cancellation);

            await unityOfWork.SaveAsync();

            return Ok(votoId);
        }
    }
}
