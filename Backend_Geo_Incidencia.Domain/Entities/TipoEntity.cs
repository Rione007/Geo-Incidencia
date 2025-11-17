using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Entities
{
    public class TipoEntity
    {
        public int ID_TIPO { get; set; }
        public string? NOMBRE { get; set; }
        public string? DESCRIPCION { get; set; }
    }
}
