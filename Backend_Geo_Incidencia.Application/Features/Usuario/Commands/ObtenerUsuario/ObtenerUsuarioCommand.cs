using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.ObtenerUsuario
{
    public class ObtenerUsuarioCommand
    {
        public int ID_USUARIO { get; set; }
    }
    public class ObtenerUsuarioResponse
    {
        public int id { get; set; }
        public string? NOMBRE { get; set; }
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
    }
}
