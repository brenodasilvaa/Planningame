using Mapster;
using Microsoft.AspNetCore.Mvc;
using Planningame_Api.Commands;
using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;

namespace Planningame_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RodadaController(IRodadaService rodadaService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateRodadaCommand command, CancellationToken cancellation)
        {
            return Ok(await rodadaService.Criar(command.Adapt<Rodada>(), cancellation));
        }

        [HttpGet("CalculoVoto/{id}")]
        public async Task<IActionResult> CalcularVotos(Guid id, CancellationToken cancellation)
        {
            try
            {
                return Ok(await rodadaService.CalcularVotos(id, cancellation));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
