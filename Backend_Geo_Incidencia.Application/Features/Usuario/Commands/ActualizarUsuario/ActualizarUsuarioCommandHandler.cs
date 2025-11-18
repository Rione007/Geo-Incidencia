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
    public class ActualizarUsuarioCommandHandler : IRequestHandler<ActualizarUsuarioCommand, ActualizarUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ActualizarUsuarioCommandHandler> _logger;

        public ActualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper, ILogger<ActualizarUsuarioCommandHandler> logger)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ActualizarUsuarioResponse> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarioActualizar = new Backend_Geo_Incidencia.Domain.Entities.UsuarioEntity
                {
                    ID_USUARIO = request.ID_USUARIO,
                    NOMBRE = request.NOMBRE,
                    CONTRASENA_HASH = request.CONTRASENA_HASH
                };

                var respuesta = await _usuarioRepository.UpdateAsync(usuarioActualizar);

                return new ActualizarUsuarioResponse
                {
                    id = respuesta?.Id ?? 0,
                    Mensaje = respuesta?.Mensaje,
                    CodigoRespuesta = respuesta?.Error ?? 500
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar usuario {UserId}", request.ID_USUARIO);
                return new ActualizarUsuarioResponse
                {
                    id = 0,
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
            }
        }
    }
}
