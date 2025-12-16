using AutoMapper;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.Heatmap
{
    public class HeatMapCommandHandler : IRequestHandler<HeatMapCommand, HeatMapResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<HeatMapCommandHandler> _logger;
        private readonly IIncidenciaRepository _incidenciaRepository;

        public HeatMapCommandHandler(
            IMapper mapper,
            ILogger<HeatMapCommandHandler> logger,
            IIncidenciaRepository incidenciaRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _incidenciaRepository = incidenciaRepository;
        }

        public async Task<HeatMapResponse> Handle(HeatMapCommand request, CancellationToken cancellationToken)
        {
            var response = new HeatMapResponse();

            try
            {
                _logger.LogInformation("Iniciando generación de heatmap");

                var celdas = await _incidenciaRepository.ObtenerHeatmapCeldasAsync(
                    request.MinLat,
                    request.MaxLat,
                    request.MinLng,
                    request.MaxLng,
                    request.GridSize,
                    request.Tipos,
                    request.Subtipos,
                    request.FechaDesde,
                    request.FechaHasta
                );

                response.Celdas = celdas;
                response.CodigoRespuesta = 0;
                response.Mensaje = "Heatmap generado correctamente";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generando heatmap");

                response.CodigoRespuesta = -1;
                response.Mensaje = $"Error: {ex.Message}";
            }

            return response;
        }
    }
}
