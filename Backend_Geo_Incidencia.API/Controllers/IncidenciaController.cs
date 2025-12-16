using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.RegistrarIncidencia;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Geo_Incidencia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidenciaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IncidenciaController> _logger;

        public IncidenciaController(IMediator mediator, ILogger<IncidenciaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<RegistrarIncidenciaResponse>> Registrar(
            [FromBody] RegistrarIncidenciaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await _mediator.Send(command, cancellationToken);

                if (respuesta == null)
                    return StatusCode(500, "Respuesta nula del handler.");

                if (respuesta.Exito)
                    return Ok(respuesta); 

                return StatusCode(500, respuesta);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar incidencia.");
                return StatusCode(500, new RegistrarIncidenciaResponse
                {
                    id = 0,
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                });
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarIncidencias(
            [FromQuery] int? tipo,
            [FromQuery] int? subtipo,
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta,
            [FromQuery] int limit = 50)
        {
            var result = await _mediator.Send(new ListarIncidenciasCommand
            {
                Tipo = tipo,
                Subtipo = subtipo,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta,
                Limit = limit
            });

            if (result.Exito)
                return Ok(ApiResponse<List<IncidenciaDto>>.Ok(
                    result.incidencias,
                    result.Mensaje
                ));

            return BadRequest(ApiResponse<object>.Fail(
                result.Mensaje,
                result.CodigoRespuesta
            ));
        }
    }
}