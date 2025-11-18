using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.RegistrarUsuario
{
    public class RegistrarUsuarioCommand : IRequest<RegistrarUsuarioResponse>
    {
        public string? NOMBRE { get; set; }
        public string? EMAIL { get; set; }
        public string? CONTRASENA_HASH { get; set; }
    }
    public class RegistrarUsuarioResponse
    {
        public int id { get; set; }
        public string Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }

}
