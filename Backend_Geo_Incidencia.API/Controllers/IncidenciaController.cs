using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.RegistrarIncidencia;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
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

        [HttpGet]
        public async Task<ActionResult<ListarIncidenciaResponse>> Listar(CancellationToken cancellationToken)
        {
            try
            {
                var respuestaLista = await _mediator.Send(new ListarIncidenciaCommand(), cancellationToken);

                if (respuestaLista == null)
                    return StatusCode(500, "Respuesta nula del handler.");

                var respuesta = respuestaLista.FirstOrDefault();

                if (respuesta == null)
                {
                    return Ok(new ListarIncidenciaResponse
                    {
                        Incidencias = new List<IncidenciaDto>(),
                        Mensaje = "No hay incidencias.",
                        CodigoRespuesta = 0
                    });
                }

                if (respuesta.CodigoRespuesta == 0 || respuesta.Exito)
                    return Ok(respuesta);

                return StatusCode(500, respuesta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar incidencias.");
                return StatusCode(500, new ListarIncidenciaResponse
                {
                    Incidencias = new List<IncidenciaDto>(),
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                });
            }
        }
    }
}