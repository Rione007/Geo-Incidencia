using MediatR;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using System.Collections.Generic;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarPorUsuario
{
    public class ListarPorUsuarioCommand : IRequest<ListarPorUsuarioResponse>
    {
        public int UsuarioId { get; set; }
    }

    public class ListarPorUsuarioResponse
    {
        public List<IncidenciaDto> Incidencias { get; set; } = new();
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
