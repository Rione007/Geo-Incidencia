using MediatR;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ObtenerIncidencia
{
    public class ObtenerIncidenciaCommand : IRequest<ObtenerIncidenciaResponse>
    {
        public int Id { get; set; }
    }

    public class ObtenerIncidenciaResponse
    {
        public IncidenciaDto? Incidencia { get; set; }
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
