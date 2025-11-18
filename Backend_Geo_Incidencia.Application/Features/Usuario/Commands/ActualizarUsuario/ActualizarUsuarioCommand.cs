using Backend_Geo_Incidencia.Application.Features.Usuario.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.ActualizarUsuario
{
    public class ActualizarUsuarioCommand : IRequest<ActualizarUsuarioResponse>
    {
        public int ID_USUARIO { get; set; }
        public string? NOMBRE { get; set; }
        public string? CONTRASENA_HASH { get; set; }
    }
    public class ActualizarUsuarioResponse
    {
        public int id { get; set; }
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
