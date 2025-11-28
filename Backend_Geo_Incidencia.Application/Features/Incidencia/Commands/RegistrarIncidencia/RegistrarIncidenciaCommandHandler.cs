using AutoMapper;
using Backend_Geo_Incidencia.Application.Features.Usuario.Commands.ActualizarUsuario;
using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Commands.RegistrarIncidencia
{
    public class RegistrarIncidenciaCommandHandler : IRequestHandler<RegistrarIncidenciaCommand, RegistrarIncidenciaResponse>
    {
        private readonly IIncidenciaRepository _incidenciaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistrarIncidenciaCommandHandler> _logger;

        public RegistrarIncidenciaCommandHandler(IIncidenciaRepository incidenciaRepository, IMapper mapper, ILogger<RegistrarIncidenciaCommandHandler> logger)
        {
            _incidenciaRepository = incidenciaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RegistrarIncidenciaResponse> Handle(RegistrarIncidenciaCommand request, CancellationToken cancellationToken)
        {
           
            try
            {
                _logger.LogInformation("Iniciando registro de incidencia");
               
                var respuesta = await _incidenciaRepository.RegistrarIncidenciaAsync(new IncidenciaEntity
                {
                    ID_USUARIO = request.IdUsuario,
                    ID_TIPO = request.IdTipo,
                    ID_SUBTIPO = request.IdSubtipo,
                    LATITUD = request.Latitud,
                    LONGITUD = request.Longitud,
                    DESCRIPCION = request.Descripcion,
                    FECHA_INCIDENCIA = request.FechaIncidencia,
                    FECHA_REGISTRO = DateTime.UtcNow

                });

                _logger.LogInformation("Incidencia registrada con ID: {Id}", respuesta?.Id ?? 0);

                return new RegistrarIncidenciaResponse
                {
                    id = respuesta?.Id ?? 0,
                    Mensaje = respuesta?.Mensaje ?? string.Empty,
                    CodigoRespuesta = respuesta?.Error ?? 500
                };
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar incidencia");
                return new RegistrarIncidenciaResponse
                {
                    id = 0,
                    Mensaje = ex.Message,
                    CodigoRespuesta = 500
                };
            }
        }
    }


    

   
}
