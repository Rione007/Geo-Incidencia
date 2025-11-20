using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Dtos
{
    public class UsuarioDto
    {
        public int ID_USUARIO { get; set; }
        public string TOKEN { get; set; }
        public string? NOMBRE { get; set; }
        public string? EMAIL { get; set; }
        public string? ROL { get; set; }
    }
}
