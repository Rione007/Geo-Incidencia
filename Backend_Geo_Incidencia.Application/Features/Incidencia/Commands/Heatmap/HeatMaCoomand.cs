using MediatR;
using Backend_Geo_Incidencia.Shared.HeadMap;
using System;
using System.Collections.Generic;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.Heatmap
{
    public class HeatMapCommand : IRequest<HeatMapResponse>
    {
        public decimal MinLat { get; set; }
        public decimal MaxLat { get; set; }
        public decimal MinLng { get; set; }
        public decimal MaxLng { get; set; }
        public decimal GridSize { get; set; }
        public List<int>? Tipos { get; set; }
        public List<int>? Subtipos { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }

    public class HeatMapResponse
    {
        public List<HeatmapCeldaModel> Celdas { get; set; } = new();
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
