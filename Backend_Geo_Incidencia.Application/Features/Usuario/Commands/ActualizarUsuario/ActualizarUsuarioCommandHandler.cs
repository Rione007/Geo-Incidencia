using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Usuario.Commands.RegistrarUsuario;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.ActualizarUsuario
{
    public class ActualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper, ILogger<RegistrarUsuarioCommandHandler> logger) : IRequestHandler<ActualizarUsuarioCommand, ActualizarUsuarioResponse>
    {
        public Task<ActualizarUsuarioResponse> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
        {

            //AQUI VAN EL PROCESO DE ACTUALIZACION
            throw new NotImplementedException();
        }
    }
}
