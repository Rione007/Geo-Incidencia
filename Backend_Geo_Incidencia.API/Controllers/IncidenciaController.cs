using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.BuscarArea;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.BuscarRadio;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.Heatmap;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarPorUsuario;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ObtenerIncidencia;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.RegistrarIncidencia;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Application.Models;
using Backend_Geo_Incidencia.Shared.HeadMap;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Geo_Incidencia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidenciaController : MiControllerBase
    {
        // Registrar incidencia
        [HttpPost("Registrar")]
        public async Task<ActionResult<RegistrarIncidenciaResponse>> Registrar(
            [FromBody] RegistrarIncidenciaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await Mediator.Send(command, cancellationToken);

                if (respuesta == null)
                    return StatusCode(500, "Respuesta nula del handler.");

                if (respuesta.Exito)
                    return Ok(respuesta);

                return StatusCode(500, respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RegistrarIncidenciaResponse
                {
                    id = 0,
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                });
            }
        }

        // Listar incidencias con filtros
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
                return Ok(ApiResponse<List<IncidenciaDto>>.Ok(result.incidencias, result.Mensaje));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }

        // Buscar por área
        [HttpGet("buscarPorArea")]
        public async Task<IActionResult> BuscarPorArea(
            [FromQuery] decimal minLat,
            [FromQuery] decimal maxLat,
            [FromQuery] decimal minLng,
            [FromQuery] decimal maxLng,
            [FromQuery] List<int>? tipos,
            [FromQuery] List<int>? subtipos,
            [FromQuery] int? dias)
        {
            var result = await Mediator.Send(new BuscarAreaCommand
            {
                MinLat = minLat,
                MaxLat = maxLat,
                MinLng = minLng,
                MaxLng = maxLng,
                Tipos = tipos,
                Subtipos = subtipos,
                Dias = dias
            });

            if (result.Exito)
                return Ok(ApiResponse<List<IncidenciaDto>>.Ok(result.Incidencias, result.Mensaje));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }

        // Buscar por radio
        [HttpGet("buscarPorRadio")]
        public async Task<IActionResult> BuscarPorRadio(
            [FromQuery] decimal lat,
            [FromQuery] decimal lng,
            [FromQuery] double metros,
            [FromQuery] List<int>? tipos,
            [FromQuery] List<int>? subtipos,
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta)
        {
            var result = await Mediator.Send(new BuscarRadioCommand
            {
                Lat = lat,
                Lng = lng,
                Metros = metros,
                Tipos = tipos,
                Subtipos = subtipos,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta
            });

            if (result.Exito)
                return Ok(ApiResponse<List<IncidenciaDto>>.Ok(result.Incidencias, result.Mensaje));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }

        // Obtener heatmap
        [HttpGet("Heatmap")]
        public async Task<IActionResult> ObtenerHeatmap(
            [FromQuery] decimal minLat,
            [FromQuery] decimal maxLat,
            [FromQuery] decimal minLng,
            [FromQuery] decimal maxLng,
            [FromQuery] decimal gridSize,
            [FromQuery] List<int>? tipos,
            [FromQuery] List<int>? subtipos,
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta)
        {
            var result = await Mediator.Send(new HeatMapCommand
            {
                MinLat = minLat,
                MaxLat = maxLat,
                MinLng = minLng,
                MaxLng = maxLng,
                GridSize = gridSize,
                Tipos = tipos,
                Subtipos = subtipos,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta
            });

            if (result.Exito)
                return Ok(ApiResponse<List<HeatmapCeldaModel>>.Ok(result.Celdas, result.Mensaje));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }

        // Listar incidencias por usuario
        [HttpGet("ListarPorUsuario/{usuarioId}")]
        public async Task<IActionResult> ListarPorUsuario([FromRoute] int usuarioId)
        {
            var result = await Mediator.Send(new ListarPorUsuarioCommand
            {
                UsuarioId = usuarioId
            });

            if (result.Exito)
                return Ok(ApiResponse<List<IncidenciaDto>>.Ok(result.Incidencias, result.Mensaje));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }

        // Obtener incidencia por Id
        [HttpGet("Obtener/{id}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute] int id)
        {
            var result = await Mediator.Send(new ObtenerIncidenciaCommand
            {
                Id = id
            });

            if (result.Exito)
                return Ok(ApiResponse<IncidenciaDto>.Ok(result.Incidencia, result.Mensaje));

            return NotFound(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }
    }
}
