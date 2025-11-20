using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Tipo.Dtos
{
    public class TipoDto
    {
        public int ID_TIPO { get; set; }
        public string? NOMBRE { get; set; }
        public string? DESCRIPCION { get; set; }
    }
}
