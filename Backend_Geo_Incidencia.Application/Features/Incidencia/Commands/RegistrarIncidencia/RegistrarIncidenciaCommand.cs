using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.RegistrarIncidencia
{
    public class RegistrarIncidenciaCommand : IRequest<RegistrarIncidenciaResponse>
    {
        public int IdUsuario { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int IdTipo { get; set; }
        public int IdSubtipo { get; set; }
        public string? Descripcion { get; set; }
        public string? DIRECCION_REFERENCIA { get; set; }
        public string? FOTO_URL1 { get; set; }
        public string? FOTO_URL2 { get; set; }
        public string? FOTO_URL3 { get; set; }
        public DateTime FechaIncidencia { get; set; }
      
    }

    public class RegistrarIncidenciaResponse
    {
        public int id { get; set; }
        public string Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}

