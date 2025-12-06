using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos
{
    public class IncidenciaDto
    {
        public int ID_INCIDENCIA { get; set; }
        public int ID_TIPO { get; set; }
        public int ID_SUBTIPO { get; set; }
        public int ID_USUARIO { get; set; }
        public DateTime FECHA_INCIDENCIA { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public decimal LATITUD { get; set; }
        public decimal LONGITUD { get; set; }
        public string? DESCRIPCION { get; set; }
        public string? FOTO_URL1 { get; set; }
        public string? FOTO_URL2 { get; set; }
        public string? FOTO_URL3 { get; set; }
        public string? DIRECCION_REFERENCIA { get; set; }
        public bool ESTADO { get; set; }
        public string? DISTANCIA { get; set; } // Usado solo en busqueda por radio
    }
}
