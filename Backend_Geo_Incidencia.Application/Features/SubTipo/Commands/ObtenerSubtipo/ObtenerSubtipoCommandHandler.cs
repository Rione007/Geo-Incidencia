using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.SubTipo.Dtos;
using Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ObtenerTipo;
using Backend_Geo_Incidencia.Application.Features.Tipo.Dtos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.SubTipo.Commands.ObtenerSubtipo
{
    public class ObtenerSubtipoCommandHandler : IRequestHandler<ObtenerSubtipoCommand, SubtipoResponse>
    {

        private readonly ISubtipoRepository _subtipoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ObtenerSubtipoCommandHandler> _logger;

        public ObtenerSubtipoCommandHandler(ISubtipoRepository subtipoRepository, IMapper mapper, ILogger<ObtenerSubtipoCommandHandler> logger)
        {
            _subtipoRepository = subtipoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SubtipoResponse> Handle(ObtenerSubtipoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entidad = await _subtipoRepository.ObtenerSubtipoPorIdAsync(request.ID_SUBTIPO);

                if (entidad == null)
                {
                    return new SubtipoResponse
                    {
                        Subtipo = new SubtipoDto(),
                        Mensaje = "Subtipo no encontrado.",
                        CodigoRespuesta = 1
                    };
                }

                var dto = _mapper.Map<SubtipoDto>(entidad);

                return new SubtipoResponse
                {
                    Subtipo = dto,
                    Mensaje = "OK",
                    CodigoRespuesta = 0
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo Subtipo con id {TipoId}", request.ID_SUBTIPO);
                return new SubtipoResponse
                {
                    Subtipo = new SubtipoDto(),
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
            }
        
        }
    }
}
