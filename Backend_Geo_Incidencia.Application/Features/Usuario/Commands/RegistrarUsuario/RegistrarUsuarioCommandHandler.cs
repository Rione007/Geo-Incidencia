using AutoMapper;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.RegistrarUsuario
{
    public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, RegistrarUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistrarUsuarioCommandHandler> _logger;

        public RegistrarUsuarioCommandHandler(IUsuarioRepository usuarioRepository,IMapper mapper, ILogger<RegistrarUsuarioCommandHandler> logger)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<RegistrarUsuarioResponse> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Iniciando registro de usuario");
                var respuesta = await _usuarioRepository.CrearAsync(new Domain.Entities.UsuarioEntity
                {
                    NOMBRE = request.NOMBRE,
                    EMAIL = request.EMAIL,
                    CONTRASENA_HASH = request.CONTRASENA_HASH
                });

                _logger.LogInformation("Usuario registrado exitosamente con ID: {UserId}", respuesta.Id);
                return new RegistrarUsuarioResponse
                {
                    id = respuesta.Id,
                    Mensaje = respuesta.Mensaje,
                    CodigoRespuesta = respuesta.Error
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar usuario");
                return new RegistrarUsuarioResponse
                {
                    id = 0,
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
            }
        }
    }
}
