using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.SubTipo.Dtos
{
    public class SubtipoDto
    {
        public int ID_SUBTIPO { get; set; }
        public int ID_TIPO { get; set; }

        public string? NOMBRE { get; set; }
    }
}
