using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias
{
    public class ListarIncidenciasCommand :IRequest<ListarIncidenciasResponse>
    {
        public int? Tipo { get; set; }
        public int? Subtipo { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int Limit { get; set; } = 50;
    }
    public class ListarIncidenciasResponse
    {
        public List<IncidenciaListadoDto> incidencias { get; set; } // si es objeto el objeto
        public string Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
