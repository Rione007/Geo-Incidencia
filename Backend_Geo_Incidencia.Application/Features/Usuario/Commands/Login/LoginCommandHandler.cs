using AutoMapper;
using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Infrastructure.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.Login
{
    public class LoginCommandHandler
        (
        IUsuarioRepository _usuarioRepository,
        IMapper mapper,
        IConfiguration configuration,
        IJwtService jwtService,
        IMediator mediator,
        IPasswordHasher passwordHasher
        ) : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loginData = await _usuarioRepository.LoginAsync(request.EMAIL!);
                if (loginData == null)
                {
                    return new LoginCommandResponse
                    {
                        Usuario = null!,
                        Mensaje = "Usuario no encontrado",
                        CodigoRespuesta = 404
                    };
                }
                var isPasswordValid = passwordHasher.Verify(loginData.CONTRASENA_HASH!, request.CONTRASENA_HASH!);
                if (!isPasswordValid)
                {
                    return new LoginCommandResponse
                    {
                        Usuario = null!,
                        Mensaje = "Contraseña incorrecta",
                        CodigoRespuesta = 401
                    };
                }
                var cuenta = await _usuarioRepository.ObtenerPorIdAsync(loginData.ID_USUARIO);

                var cuentaDto = mapper.Map<Domain.Entities.UsuarioEntity, Dtos.UsuarioDto>(cuenta!);

                cuentaDto.TOKEN = jwtService.GenerateJwtToken(new Domain.Configuration.Session
                {
                    IdUsuario = cuentaDto.ID_USUARIO,
                    Email = cuentaDto.EMAIL!
                });

                return new LoginCommandResponse
                {
                    Usuario = cuentaDto,
                    Mensaje = "Inicio de sesión exitoso",
                    CodigoRespuesta = 0
                };

            }
            catch (Exception ex)
            {
                return new LoginCommandResponse
                {
                    Usuario = null!,
                    CodigoRespuesta = 500,
                    Mensaje = $"Error al iniciar sesión: {ex.Message}"
                };

            }
        }
    }
}
