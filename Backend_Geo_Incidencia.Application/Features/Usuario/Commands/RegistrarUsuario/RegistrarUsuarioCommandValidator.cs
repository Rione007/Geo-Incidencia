using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Usuario.Commands.RegistrarUsuario
{
    public class RegistrarUsuarioCommandValidator : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioCommandValidator()
        {
            RuleFor(x => x.NOMBRE)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");
            RuleFor(x => x.EMAIL)
                .NotEmpty()
                .EmailAddress().WithMessage("El correo electrónico no es válido.");
            RuleFor(x => x.CONTRASENA_HASH)
                .NotEmpty()
                .MaximumLength(8).WithMessage("La contraseña no puede exceder los 8 caracteres.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
        }
    }
}
