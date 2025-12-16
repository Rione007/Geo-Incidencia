using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Geo_Incidencia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicenciaController : MiControllerBase
    {


        // 🔹 LISTAR INCIDENCIAS (Android)
        // GET: api/incidencia/listar?tipo=1&subtipo=2&fechaDesde=2025-09-01
        [HttpGet("listar")]
        public async Task<IActionResult> ListarIncidencias(
            [FromQuery] int? tipo,
            [FromQuery] int? subtipo,
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta,
            [FromQuery] int limit = 50)
        {
            var result = await Mediator.Send(new ListarIncidenciasCommand
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
