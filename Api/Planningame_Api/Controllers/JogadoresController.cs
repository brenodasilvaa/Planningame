using Mapster;
using Microsoft.AspNetCore.Mvc;
using Planningame_Api.Commands;
using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;

namespace Planningame_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadoresController(IJogadoresService jogadores) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateJogadorCommand command, CancellationToken cancellation)
        {
            return Ok(await jogadores.Criar(command.Adapt<Jogador>(), cancellation));
        }
    }
}
