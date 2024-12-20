﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using Planningame_Api.Commands;
using Planningame_Api.Dtos;
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
                var calculoVoto = await rodadaService.CalcularVotos(id, cancellation);

                return Ok(new {voto = calculoVoto});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Brindar/{id}")]
        public async Task<IActionResult> Brindar(Guid id, CancellationToken cancellation)
        {
            try
            {
                await rodadaService.Brindar(id, cancellation);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Info/{id}")]
        public async Task<IActionResult> GetInfo(Guid id, CancellationToken cancellation)
        {
            try
            {
                return Ok((await rodadaService.GetInfo(id, cancellation)).Adapt<RodadaInfoDto>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
