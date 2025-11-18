using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Shared.HeadMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Repositories
{
    public class IncidenciaRepository : IIncidenciaRepository
    {
        public Task<IEnumerable<IncidenciaEntity>> BuscarPorAreaAsync(decimal minLat, decimal maxLat, decimal minLng, decimal maxLng, int? tipoId = null, int? subtipoId = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IncidenciaEntity>> BuscarPorRadioAsync(decimal lat, decimal lng, double metros, int? tipoId = null, int? subtipoId = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IncidenciaEntity>> ListarIncidenciasPorUsuarioIdAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HeatmapCeldaModel>> ObtenerHeatmapCeldasAsync(decimal minLat, decimal maxLat, decimal minLng, decimal maxLng, int gridSize, int? tipoId = null, int? subtipoId = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            throw new NotImplementedException();
        }

        public Task<IncidenciaEntity?> ObtenerInciedenciaIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> RegistrarIncidenciaAsync(IncidenciaEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
