using Azure;
using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Shared;
using Backend_Geo_Incidencia.Shared.HeadMap;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Repositories
{
    public class IncidenciaRepository : IIncidenciaRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public IncidenciaRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }
        public async Task<List<IncidenciaEntity>> BuscarPorAreaAsync(decimal minLat, decimal maxLat, decimal minLng, decimal maxLng, List<int>? tipos = null, List<int>? subtipos = null, int? dias = null)
        {
            List<IncidenciaEntity> response = new List<IncidenciaEntity>();
            var storedProcedure = DbConstantes.SpBuscarIncidenciasPorArea;
            try
            {
                var connection = _factoryConnection.GetConnection();
                var result = await connection.QueryAsync<IncidenciaEntity>(
                    storedProcedure,
                    new
                    {
                        MIN_LATITUD = minLat,
                        MAX_LATITUD = maxLat,
                        MIN_LONGITUD = minLng,
                        MAX_LONGITUD = maxLng,
                        TIPOS = tipos != null && tipos.Any() ? string.Join(",", tipos) : null,
                        SUBTIPOS = subtipos != null && subtipos.Any() ? string.Join(",", subtipos) : null,
                        DIAS = dias
                    },
                    commandType: CommandType.StoredProcedure
                );
                response = result.ToList();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
            return response;
        }

        public async Task<List<IncidenciaEntity>> BuscarPorRadioAsync(decimal lat, decimal lng, double metros, List<int>? tipos = null, List<int>? subtipos = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            var storedProcedure = DbConstantes.SpBuscarIncidenciasPorRadio;
            List<IncidenciaEntity> response = new();

            try
            {
                var connection = _factoryConnection.GetConnection();

                var result = await connection.QueryAsync<IncidenciaEntity>(
                    storedProcedure,
                    new
                    {
                        LAT = lat,
                        LNG = lng,
                        METROS = metros,
                        TIPOS = tipos != null && tipos.Any() ? string.Join(",", tipos) : null,
                        SUBTIPOS = subtipos != null && subtipos.Any() ? string.Join(",", subtipos) : null,
                        FECHA_DESDE = fechaDesde,
                        FECHA_HASTA = fechaHasta
                    },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return response;
        }

        public async Task<List<IncidenciaEntity>> ListarIncidenciasAsync()
        {
            var storedProcedure = DbConstantes.SpListarIncidencias;
            List<IncidenciaEntity> response = new();

            try
            {
                var connection = _factoryConnection.GetConnection();

                var result = await connection.QueryAsync<IncidenciaEntity>(
                    storedProcedure,
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return response;
        }


        public async Task<List<IncidenciaEntity>> ListarIncidenciasPorUsuarioIdAsync(int usuarioId)
        {
            var storedProcedure = DbConstantes.SpListarIncidenciasPorUsuarioId;
            List<IncidenciaEntity> response = new();

            try
            {
                var connection = _factoryConnection.GetConnection();

                var result = await connection.QueryAsync<IncidenciaEntity>(
                    storedProcedure,
                    new { UsuarioId = usuarioId },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return response;
        }

        public async Task<List<HeatmapCeldaModel>> ObtenerHeatmapCeldasAsync(decimal minLat, decimal maxLat, decimal minLng, decimal maxLng, int gridSize, List<int>? tipos = null, List<int>? subtipos = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            var storedProcedure = DbConstantes.SpObtenerHeatmap;
            List<HeatmapCeldaModel> response = new();

            try
            {
                var connection = _factoryConnection.GetConnection();

                var result = await connection.QueryAsync<HeatmapCeldaModel>(
                    storedProcedure,
                    new
                    {
                        MIN_LATITUD = minLat,
                        MAX_LATITUD = maxLat,
                        MIN_LONGITUD = minLng,
                        MAX_LONGITUD = maxLng,
                        GRIDSIZE = gridSize,
                        TIPOS = tipos != null && tipos.Any() ? string.Join(",", tipos) : null,
                        SUBTIPOS = subtipos != null && subtipos.Any() ? string.Join(",", subtipos) : null,
                        FECHA_DESDE = fechaDesde,
                        FECHA_HASTA = fechaHasta
                    },
                    commandType: CommandType.StoredProcedure
                );

                response = result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return response;
        }

        public async Task<IncidenciaEntity?> ObtenerInciedenciaIdAsync(int id)
        {
            var storedProcedure = DbConstantes.SpObtenerIncidenciaPorId;
            IncidenciaEntity? response = null;

            try
            {
                var connection = _factoryConnection.GetConnection();

                response = await connection.QueryFirstOrDefaultAsync<IncidenciaEntity>(
                    storedProcedure,
                    new { IdIncidencia = id },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return response;
        }

        public async Task<Respuesta> RegistrarIncidenciaAsync(IncidenciaEntity entity)
        {
            var storedProcedure = DbConstantes.SpRegistrarIncidencia;
            Respuesta? respuesta = null;

            try
            {
                var connection = _factoryConnection.GetConnection();

                // Ejecutamos el SP y esperamos una fila con (Fila, Mensaje, Id) 
                respuesta = await connection.QueryFirstOrDefaultAsync<Respuesta>(
                    storedProcedure,
                    new
                    {
                        IdUsuario = entity.ID_USUARIO,
                        Latitud = entity.LATITUD,
                        Longitud = entity.LONGITUD,
                        TipoId = entity.ID_TIPO,
                        SubtipoId = entity.ID_SUBTIPO,
                        Descripcion = entity.DESCRIPCION,
                        FechaIncidencia = entity.FECHA_INCIDENCIA
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return respuesta;
        }
    }
}
