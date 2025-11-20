using Backend_Geo_Incidencia.Application.Features.Usuario.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string? EMAIL { get; set; }
        public string? CONTRASENA_HASH { get; set; }
    }
    public class LoginCommandResponse
    {
        public UsuarioDto Usuario { get; set; }
        public string Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
