using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Tipo.Dtos;
using Backend_Geo_Incidencia.Application.Features.Usuario.Commands.ActualizarUsuario;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ListarTipos
{
    public class ListarTipoCommandHandler : IRequestHandler<ListarTipoCommand, List<ListarTipoResponse>>
    {

        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ListarTipoCommandHandler> _logger;

        public ListarTipoCommandHandler(ITipoRepository tipoRepository, IMapper mapper, ILogger<ListarTipoCommandHandler> logger)
        {
            _tipoRepository = tipoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ListarTipoResponse>> Handle(ListarTipoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entidades = await _tipoRepository.ListarTiposAsync();
                var dtos = _mapper.Map<List<TipoDto>>(entidades ?? new List<Backend_Geo_Incidencia.Domain.Entities.TipoEntity>());

                var respuesta = new ListarTipoResponse
                {
                    Tipos = dtos,
                    Mensaje = "OK",
                    CodigoRespuesta = 0
                };

                return new List<ListarTipoResponse> { respuesta };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error listando tipos");
                var respuestaError = new ListarTipoResponse
                {
                    Tipos = new List<TipoDto>(),
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
                return new List<ListarTipoResponse> { respuestaError };
            }
        
    
        }
    }
}
