using Mapster;
using Microsoft.AspNetCore.Mvc;
using Planningame_Api.Commands;
using Planningame_Api.Dtos;
using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;

namespace Planningame_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidaController(IPartidaService partidaService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreatePartidaCommand command, CancellationToken cancellation)
        {
            return Ok(await partidaService.Criar(command.Adapt<Partida>(), cancellation));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellation)
        {
            try
            {
                return Ok((await partidaService.GetById(id, cancellation)).Adapt<PartidaDto>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
