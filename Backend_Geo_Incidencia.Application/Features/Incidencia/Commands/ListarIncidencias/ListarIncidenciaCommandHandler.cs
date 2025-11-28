using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos;
using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.ListarIncidencias
{
    public class ListarIncidenciaCommandHandler : IRequestHandler<ListarIncidenciaCommand, List<ListarIncidenciaResponse>>
    {
        private readonly IIncidenciaRepository _incidenciaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ListarIncidenciaCommandHandler> _logger;

        public ListarIncidenciaCommandHandler(IIncidenciaRepository incidenciaRepository, IMapper mapper, ILogger<ListarIncidenciaCommandHandler> logger)
        {
            _incidenciaRepository = incidenciaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ListarIncidenciaResponse>> Handle(ListarIncidenciaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entidades = await _incidenciaRepository.ListarIncidenciasAsync();
                var dtos = _mapper.Map<List<IncidenciaDto>>(entidades ?? new List<IncidenciaEntity>());

                var response = new ListarIncidenciaResponse
                {
                    Incidencias = dtos,
                    Mensaje = "Incidencias listadas correctamente.",
                    CodigoRespuesta = 0
                };

                return new List<ListarIncidenciaResponse> { response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error listando incidencias");
                var errorResponse = new ListarIncidenciaResponse
                {
                    Incidencias = new List<IncidenciaDto>(),
                    Mensaje = "Error listando incidencias: " + ex.Message,
                    CodigoRespuesta = 500
                };

                return new List<ListarIncidenciaResponse> { errorResponse };
            }
        }
    }
}
