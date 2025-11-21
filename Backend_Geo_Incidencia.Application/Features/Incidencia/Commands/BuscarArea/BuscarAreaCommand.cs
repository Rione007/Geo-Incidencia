using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.BuscarArea
{
    public class BuscarAreaCommand: IRequest<BuscarAreaResponse>
    {
        public decimal MinLat { get; set; }
        public decimal MaxLat { get; set; }
        public decimal MinLng { get; set; }
        public decimal MaxLng { get; set; }
        public List<int>? Tipos { get; set; }
        public List<int>? Subtipos { get; set; }
        public int? Dias { get; set; }

    }
    public class BuscarAreaResponse
    {
        public List<IncidenciaDto> Incidencias { get; set; } = [];
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
