using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        private readonly IFactoryConnection _factoryConnection;

        public TipoRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        public async Task<List<TipoEntity>> ListarTiposAsync()
        {
            IEnumerable<TipoEntity> resultado = Enumerable.Empty<TipoEntity>();
            var storeProcedure = DbConstantes.SpListarTipos;
            try
            {
                var connection = _factoryConnection.GetConnection();
                resultado = await connection.QueryAsync<TipoEntity>(storeProcedure, commandType: System.Data.CommandType.StoredProcedure);
                return resultado.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
        }

        public async Task<TipoEntity?> ObtenerTipoPorIdAsync(int id)
        {
            TipoEntity? resultado = null;
            var storeProcedure = DbConstantes.SpObtenerTipoPorId;
            try
            {
                var connection = _factoryConnection.GetConnection();
                resultado = await connection.QueryFirstOrDefaultAsync<TipoEntity>(storeProcedure, new { ID_TIPO = id }, 
                                    commandType: System.Data.CommandType.StoredProcedure);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
        }
    }
}
