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
        Task<List<IncidenciaEntity>> ListarIncidenciasPorUsuarioIdAsync(int usuarioId);
        Task<IncidenciaEntity?> ObtenerInciedenciaIdAsync(int id);

        // FUNCIONES PARA EL MAPA
        //------------------------------

        Task<List<IncidenciaEntity>> BuscarPorAreaAsync(
                decimal minLat, decimal maxLat,
                decimal minLng, decimal maxLng,
                List<int>? tipos = null,
                List<int>? subtipos = null,
                int? dias = null
        );

        Task<List<IncidenciaEntity>> BuscarPorRadioAsync(
            decimal lat,
            decimal lng,
            double metros,
            List<int>? tipos = null,
            List<int>? subtipos = null,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null
        );

        Task<List<HeatmapCeldaModel>> ObtenerHeatmapCeldasAsync(
            decimal minLat, decimal maxLat,
            decimal minLng, decimal maxLng,
            int gridSize,
            List<int>? tipos = null,
            List<int>? subtipos = null,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null
        );
    }
}
