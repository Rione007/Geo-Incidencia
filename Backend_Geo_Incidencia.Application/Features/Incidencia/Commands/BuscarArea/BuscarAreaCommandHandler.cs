using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.BuscarArea
{
    public class BuscarAreaCommandHandler
        : IRequestHandler<BuscarAreaCommand, BuscarAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BuscarAreaCommandHandler> _logger;
        private readonly IIncidenciaRepository _incidenciaRepository;

        public BuscarAreaCommandHandler(
            IMapper mapper,
            ILogger<BuscarAreaCommandHandler> logger,
            IIncidenciaRepository incidenciaRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _incidenciaRepository = incidenciaRepository;
        }

        public async Task<BuscarAreaResponse> Handle(
            BuscarAreaCommand request,
            CancellationToken cancellationToken)
        {
            var response = new BuscarAreaResponse();

            try
            {
                _logger.LogInformation("Iniciando búsqueda por área");

                var lista = await _incidenciaRepository.BuscarPorAreaAsync(
                    request.MinLat,
                    request.MaxLat,
                    request.MinLng,
                    request.MaxLng,
                    request.Tipos,
                    request.Subtipos,
                    request.Dias
                );

                response.Incidencias = _mapper.Map<List<IncidenciaDto>>(lista);
                response.CodigoRespuesta = 0;
                response.Mensaje = "Consulta realizada correctamente";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error buscando incidencias por área");

                response.CodigoRespuesta = -1;
                response.Mensaje = $"Error: {ex.Message}";
            }

            return response;
        }
    }
}
