using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias
{
    public class ListarIncidenciaCommand : IRequest<List<ListarIncidenciaResponse>>
    {
        
    }

    public class ListarIncidenciaResponse
    {
        public List<IncidenciaDto> Incidencias { get; set; } = new List<IncidenciaDto>();
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
