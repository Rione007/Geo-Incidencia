using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Usuario.Commands.RegistrarUsuario;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

public class RegistrarUsuarioCommandHandler
    : IRequestHandler<RegistrarUsuarioCommand, RegistrarUsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<RegistrarUsuarioCommandHandler> _logger;
    private readonly IPasswordHasher _passwordHasher;

    public RegistrarUsuarioCommandHandler(
        IUsuarioRepository usuarioRepository,
        IMapper mapper,
        ILogger<RegistrarUsuarioCommandHandler> logger,
        IPasswordHasher passwordHasher)
    {
        _logger = logger;
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegistrarUsuarioResponse> Handle(
        RegistrarUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Iniciando registro de usuario");

            string hash = _passwordHasher.Hash(request.CONTRASENA);

            var respuesta = await _usuarioRepository.CrearAsync(
                new Backend_Geo_Incidencia.Domain.Entities.UsuarioEntity
                {
                    NOMBRE = request.NOMBRE,
                    EMAIL = request.EMAIL,
                    CONTRASENA_HASH = hash      
                });

            _logger.LogInformation(
                "Usuario registrado exitosamente con ID: {UserId}",
                respuesta.Id
            );

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
