using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Shared.HeadMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Interfaces
{
    public interface IIncidenciaRepository
    {
        Task<Respuesta> RegistrarIncidenciaAsync(IncidenciaEntity entity);
        Task<IEnumerable<IncidenciaEntity>> ListarIncidenciasPorUsuarioIdAsync(int usuarioId);
        Task<IncidenciaEntity?> ObtenerInciedenciaIdAsync(int id);

        // FUNCIONES PARA EL MAPA
        //------------------------------

        Task<IEnumerable<IncidenciaEntity>> BuscarPorAreaAsync(
                decimal minLat, decimal maxLat,
                decimal minLng, decimal maxLng,
                int? tipoId = null,
                int? subtipoId = null,
                DateTime? fechaDesde = null,
                DateTime? fechaHasta = null
            );
        Task<IEnumerable<IncidenciaEntity>> BuscarPorRadioAsync(
            decimal lat,
            decimal lng,
            double metros,
            int? tipoId = null,
            int? subtipoId = null,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null
        );
        Task<IEnumerable<HeatmapCeldaModel>> ObtenerHeatmapCeldasAsync(
            decimal minLat, decimal maxLat,
            decimal minLng, decimal maxLng,
            int gridSize,
            int? tipoId = null,
            int? subtipoId = null,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null
        );
    }
}
