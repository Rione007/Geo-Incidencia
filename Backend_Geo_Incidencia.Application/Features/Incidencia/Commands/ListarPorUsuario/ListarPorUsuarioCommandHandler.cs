using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarPorUsuario
{
    public class ListarPorUsuarioCommandHandler : IRequestHandler<ListarPorUsuarioCommand, ListarPorUsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ListarPorUsuarioCommandHandler> _logger;
        private readonly IIncidenciaRepository _incidenciaRepository;

        public ListarPorUsuarioCommandHandler(
            IMapper mapper,
            ILogger<ListarPorUsuarioCommandHandler> logger,
            IIncidenciaRepository incidenciaRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _incidenciaRepository = incidenciaRepository;
        }

        public async Task<ListarPorUsuarioResponse> Handle(ListarPorUsuarioCommand request, CancellationToken cancellationToken)
        {
            var response = new ListarPorUsuarioResponse();

            try
            {
                _logger.LogInformation("Listando incidencias por usuario Id: {UsuarioId}", request.UsuarioId);

                var lista = await _incidenciaRepository.ListarIncidenciasPorUsuarioIdAsync(request.UsuarioId);

                response.Incidencias = _mapper.Map<List<IncidenciaDto>>(lista);
                response.CodigoRespuesta = 0;
                response.Mensaje = "Consulta realizada correctamente";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error listando incidencias por usuario");

                response.CodigoRespuesta = -1;
                response.Mensaje = $"Error: {ex.Message}";
            }

            return response;
        }
    }
}
