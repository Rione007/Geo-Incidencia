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
    public class SubtipoRepository : ISubtipoRepository
    {
        private readonly IFactoryConnection _factoryConnection;

        public SubtipoRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        public async Task<List<SubtipoEntity>> ListarSubtipoAsync(int tipoId)
        {
            IEnumerable<SubtipoEntity> resultado = Enumerable.Empty<SubtipoEntity>();
            var storeProcedure = DbConstantes.SpListarSubtipos;
            try
            {
                var connection = _factoryConnection.GetConnection();
                resultado = await connection.QueryAsync<SubtipoEntity>(storeProcedure, commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<SubtipoEntity?> ObtenerSubtipoPorIdAsync(int id)
        {
            SubtipoEntity? resultado = null;
            var storeProcedure = DbConstantes.SpObtenerSubtipoPorId;
            try
            {
                var connection = _factoryConnection.GetConnection();
                resultado = await connection.QueryFirstOrDefaultAsync<SubtipoEntity>(storeProcedure, new { ID_SUBTIPO = id },
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
