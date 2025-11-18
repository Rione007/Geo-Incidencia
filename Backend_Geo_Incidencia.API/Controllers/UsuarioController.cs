using Backend_Geo_Incidencia.Application.Features.Usuario.Commands.ActualizarUsuario;
using Backend_Geo_Incidencia.Application.Features.Usuario.Commands.RegistrarUsuario;
using Backend_Geo_Incidencia.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Geo_Incidencia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator Mediator;
        public UsuarioController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> CrearUsuario([FromBody] RegistrarUsuarioCommand request)
        {
            var dto = request;

            var command = new RegistrarUsuarioCommand{
                NOMBRE = dto.NOMBRE,
                EMAIL = dto.EMAIL,
                CONTRASENA_HASH = dto.CONTRASENA_HASH
            };
            var result = await Mediator.Send(command);
            if (result.Exito)
            {
                return Ok(ApiResponse<RegistrarUsuarioResponse>.Ok(result,"Registro Exitoso"));
            }
            else
            {
                return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
            }
           
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] ActualizarUsuarioCommand request)
        {
            var result = await Mediator.Send(request);
            if (result.Exito)
                return Ok(ApiResponse<ActualizarUsuarioResponse>.Ok(result, "Actualización exitosa"));

            return BadRequest(ApiResponse<object>.Fail(result.Mensaje, result.CodigoRespuesta));
        }
    }
}
