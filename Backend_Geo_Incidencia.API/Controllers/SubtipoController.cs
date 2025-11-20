using Backend_Geo_Incidencia.Application.Features.SubTipo.Commands.ListarSubtipos;
using Backend_Geo_Incidencia.Application.Features.SubTipo.Commands.ObtenerSubtipo;
using Backend_Geo_Incidencia.Application.Features.SubTipo.Dtos;
using Backend_Geo_Incidencia.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Geo_Incidencia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubtipoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubtipoController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> ListarSubtipos()
        {
            var result = await _mediator.Send(new ListarSubtipoCommand());
            var respuesta = result?.FirstOrDefault() ?? new ListarSubtipoResponse
            {
                Subtipos = new List<SubtipoDto>(),
                Mensaje = "Error al obtener subtipos",
                CodigoRespuesta = 500
            };

            if (respuesta.Exito)
                return Ok(ApiResponse<List<SubtipoDto>>.Ok(respuesta.Subtipos, "Listado de subtipos"));

            return BadRequest(ApiResponse<object>.Fail(respuesta.Mensaje, respuesta.CodigoRespuesta));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerSubtipo(int id)
        {
            var result = await _mediator.Send(new ObtenerSubtipoCommand { ID_SUBTIPO = id });

            if (result.Exito)
                return Ok(ApiResponse<SubtipoDto>.Ok(result.Subtipo, "Subtipo obtenido"));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }
    }
}
