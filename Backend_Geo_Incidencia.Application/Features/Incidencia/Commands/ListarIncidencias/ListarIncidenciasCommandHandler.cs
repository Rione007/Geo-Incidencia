using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Handlers
{
    public class ListarIncidenciasCommandHandler
        : IRequestHandler<ListarIncidenciasCommand, ListarIncidenciasResponse>
    {
        private readonly IIncidenciaRepository _incidenciaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ListarIncidenciasCommandHandler> _logger;

        public ListarIncidenciasCommandHandler(
            IIncidenciaRepository incidenciaRepository,
            IMapper mapper,
            ILogger<ListarIncidenciasCommandHandler> logger)
        {
            _incidenciaRepository = incidenciaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ListarIncidenciasResponse> Handle(
            ListarIncidenciasCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Listando incidencias con filtros {@request}", request);

                var incidencias = await _incidenciaRepository.ListarIncidenciasAsync(
                    request.Tipo,
                    request.Subtipo,
                    request.FechaDesde,
                    request.FechaHasta,
                    request.Limit
                );

                var dtoList = _mapper.Map<List<IncidenciaDto>>(incidencias);

                return new ListarIncidenciasResponse
                {
                    incidencias = dtoList,
                    Mensaje = "Incidencias obtenidas correctamente",
                    CodigoRespuesta = 0
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar incidencias");

                return new ListarIncidenciasResponse
                {
                    incidencias = new List<IncidenciaDto>(),
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
            }
        }
    }
}
