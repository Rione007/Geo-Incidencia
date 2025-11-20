using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ListarTipos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Application.Features.Tipo.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ObtenerTipo
{
    public class ObtenerTipoCommandHandler : IRequestHandler<ObtenerTipoCommand, TipoResponse>
    {
        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ObtenerTipoCommandHandler> _logger;

        public ObtenerTipoCommandHandler(ITipoRepository tipoRepository, IMapper mapper, ILogger<ObtenerTipoCommandHandler> logger)
        {
            _tipoRepository = tipoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TipoResponse> Handle(ObtenerTipoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entidad = await _tipoRepository.ObtenerTipoPorIdAsync(request.ID_TIPO);

                if (entidad == null)
                {
                    return new TipoResponse
                    {
                        Tipo = new TipoDto(),
                        Mensaje = "Tipo no encontrado.",
                        CodigoRespuesta = 1
                    };
                }

                var dto = _mapper.Map<TipoDto>(entidad);

                return new TipoResponse
                {
                    Tipo = dto,
                    Mensaje = "OK",
                    CodigoRespuesta = 0
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo tipo con id {TipoId}", request.ID_TIPO);
                return new TipoResponse
                {
                    Tipo = new TipoDto(),
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
            }
        }
    }
}
