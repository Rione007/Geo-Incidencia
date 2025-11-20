using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ListarTipos;
using Backend_Geo_Incidencia.Application.Features.SubTipo.Dtos;
using Backend_Geo_Incidencia.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.SubTipo.Commands.ListarSubtipos
{
    public class ListarSubtipoCommandsHandler : IRequestHandler<ListarSubtipoCommand, List<ListarSubtipoResponse>>
    {
        private readonly ISubtipoRepository _subtipoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ListarSubtipoCommandsHandler> _logger;

        public ListarSubtipoCommandsHandler(ISubtipoRepository subtipoRepository, IMapper mapper, ILogger<ListarSubtipoCommandsHandler> logger)
        {
            _subtipoRepository = subtipoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ListarSubtipoResponse>> Handle(ListarSubtipoCommand request , CancellationToken cancellationToken)
        {
            try
            {
                var entidades = await _subtipoRepository.ListarSubtipoAsync();
                var dtos = _mapper.Map<List<SubtipoDto>>(entidades ?? new List<Backend_Geo_Incidencia.Domain.Entities.SubtipoEntity>());

                var respuesta = new ListarSubtipoResponse
                {
                    Subtipos = dtos,
                    Mensaje = "OK",
                    CodigoRespuesta = 0
                };

                return new List<ListarSubtipoResponse> { respuesta };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error listando Subtipos");
                var respuestaError = new ListarSubtipoResponse
                {
                    Subtipos = new List<SubtipoDto>(),
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
                return new List<ListarSubtipoResponse> { respuestaError };
            }
        }
    }
}
