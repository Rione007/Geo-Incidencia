using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.BuscarRadio
{
    public class BuscarRadioCommand : IRequest<BuscarRadioResponse>
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public double Metros { get; set; }
        public List<int>? Tipos { get; set; }
        public List<int>? Subtipos { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
    public class BuscarRadioResponse
    {
        public List<IncidenciaDto> Incidencias { get; set; } = [];
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
