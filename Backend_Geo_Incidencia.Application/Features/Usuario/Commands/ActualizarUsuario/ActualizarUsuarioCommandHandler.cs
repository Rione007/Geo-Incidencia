using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Usuario.Commands.RegistrarUsuario;
using Backend_Geo_Incidencia.Domain.Entities;
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
        private readonly IPasswordHasher _passwordHasher;

        public ActualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper, ILogger<ActualizarUsuarioCommandHandler> logger, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }

        public async Task<ActualizarUsuarioResponse> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string? hash = null;

                if (!string.IsNullOrWhiteSpace(request.CONTRASENA))
                {
                    hash = _passwordHasher.Hash(request.CONTRASENA);
                }
                var usuarioActualizar = new UsuarioEntity
                {
                    ID_USUARIO = request.ID_USUARIO,
                    NOMBRE = string.IsNullOrWhiteSpace(request.NOMBRE) ? null : request.NOMBRE,
                    CONTRASENA_HASH = string.IsNullOrWhiteSpace(request.CONTRASENA) ? null : hash
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
