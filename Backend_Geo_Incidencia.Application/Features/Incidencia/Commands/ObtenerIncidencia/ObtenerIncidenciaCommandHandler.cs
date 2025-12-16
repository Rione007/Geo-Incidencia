using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ObtenerIncidencia
{
    public class ObtenerIncidenciaCommandHandler : IRequestHandler<ObtenerIncidenciaCommand, ObtenerIncidenciaResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ObtenerIncidenciaCommandHandler> _logger;
        private readonly IIncidenciaRepository _incidenciaRepository;

        public ObtenerIncidenciaCommandHandler(
            IMapper mapper,
            ILogger<ObtenerIncidenciaCommandHandler> logger,
            IIncidenciaRepository incidenciaRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _incidenciaRepository = incidenciaRepository;
        }

        public async Task<ObtenerIncidenciaResponse> Handle(ObtenerIncidenciaCommand request, CancellationToken cancellationToken)
        {
            var response = new ObtenerIncidenciaResponse();

            try
            {
                _logger.LogInformation("Obteniendo incidencia por Id: {Id}", request.Id);

                var incidencia = await _incidenciaRepository.ObtenerInciedenciaIdAsync(request.Id);

                if (incidencia != null)
                {
                    response.Incidencia = _mapper.Map<IncidenciaDto>(incidencia);
                    response.CodigoRespuesta = 0;
                    response.Mensaje = "Consulta realizada correctamente";
                }
                else
                {
                    response.CodigoRespuesta = -1;
                    response.Mensaje = "Incidencia no encontrada";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo incidencia");

                response.CodigoRespuesta = -1;
                response.Mensaje = $"Error: {ex.Message}";
            }

            return response;
        }
    }
}
