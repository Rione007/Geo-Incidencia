using Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ListarTipos;
using Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ObtenerTipo;
using Backend_Geo_Incidencia.Application.Features.Tipo.Dtos;
using Backend_Geo_Incidencia.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Geo_Incidencia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TipoController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> ListarTipos()
        {
            var result = await _mediator.Send(new ListarTipoCommand());
            var respuesta = result?.FirstOrDefault() ?? new ListarTipoResponse
            {
                Tipos = new List<TipoDto>(),
                Mensaje = "Error al obtener tipos",
                CodigoRespuesta = 500
            };

            if (respuesta.Exito)
                return Ok(ApiResponse<List<TipoDto>>.Ok(respuesta.Tipos, "Listado de tipos"));

            return BadRequest(ApiResponse<object>.Fail(respuesta.Mensaje, respuesta.CodigoRespuesta));
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerTipo(int id)
        {
            var result = await _mediator.Send(new ObtenerTipoCommand { ID_TIPO = id });

            if (result.Exito)
                return Ok(ApiResponse<TipoDto>.Ok(result.Tipo, "Tipo obtenido"));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }
    }
}
