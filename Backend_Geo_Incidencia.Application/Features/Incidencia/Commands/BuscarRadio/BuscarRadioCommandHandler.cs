using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.BuscarRadio
{
    public class BuscarRadioCommandHandler
        : IRequestHandler<BuscarRadioCommand, BuscarRadioResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BuscarRadioCommandHandler> _logger;
        private readonly IIncidenciaRepository _incidenciaRepository;

        public BuscarRadioCommandHandler(
            IMapper mapper,
            ILogger<BuscarRadioCommandHandler> logger,
            IIncidenciaRepository incidenciaRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _incidenciaRepository = incidenciaRepository;
        }

        public async Task<BuscarRadioResponse> Handle(
            BuscarRadioCommand request,
            CancellationToken cancellationToken)
        {
            var response = new BuscarRadioResponse();

            try
            {
                _logger.LogInformation("Iniciando búsqueda por radio");

                // Aquí se asume que tu command tiene propiedades como Lat, Lng, Metros, Tipos, Subtipos, FechaDesde, FechaHasta
                var lista = await _incidenciaRepository.BuscarPorRadioAsync(
                    request.Lat,
                    request.Lng,
                    request.Metros,
                    request.Tipos,
                    request.Subtipos,
                    request.FechaDesde,
                    request.FechaHasta
                );

                response.Incidencias = _mapper.Map<List<IncidenciaDto>>(lista);
                response.CodigoRespuesta = 0;
                response.Mensaje = "Consulta realizada correctamente";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error buscando incidencias por radio");

                response.CodigoRespuesta = -1;
                response.Mensaje = $"Error: {ex.Message}";
            }

            return response;
        }
    }
}
