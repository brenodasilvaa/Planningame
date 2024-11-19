using Mapster;
using Microsoft.AspNetCore.Mvc;
using Planningame_Api.Commands;
using Planningame_Api.Dtos;
using Planningame_Application.Interfaces;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces.Repositorios;

namespace Planningame_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidaController(IPartidaService partidaService, IPartidaRepository partidaRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreatePartidaCommand command, CancellationToken cancellation)
        {
            var partidaId = await partidaService.Criar(command.Adapt<Partida>(), cancellation);

            return Ok(partidaId );
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

        [HttpGet("RodadaAtiva/{id}")]
        public async Task<IActionResult> GetRodadaAtiva(Guid id, CancellationToken cancellation)
        {
            try
            {
                var rodadaId = await partidaRepository.GetRodadaAtiva(id, cancellation);

                return Ok(new {rodadaId});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
