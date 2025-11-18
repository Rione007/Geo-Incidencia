using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Backend_Geo_Incidencia.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public UsuarioRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }
        public async Task<Respuesta> CrearAsync(UsuarioEntity entity)
        {
            Respuesta respuesta = null;
            var storeProcedure = DbConstantes.SpCrearCuenta;
            try
            {
                var connection = _factoryConnection.GetConnection();
                respuesta = await connection.QueryFirstAsync<Respuesta>(storeProcedure, new
                {
                    NOMBRE = entity.NOMBRE,
                    EMAIL = entity.EMAIL,
                    CONTRASENA_HASH = entity.CONTRASENA_HASH,

                }, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<Respuesta> LoginAsync(UsuarioEntity cuenta)
        {
            Respuesta respuesta = null;
            var storeProcedure = DbConstantes.SpActualizarCuenta;
            try
            {
                var connection = _factoryConnection.GetConnection();
                respuesta = await connection.QueryFirstAsync<Respuesta>(storeProcedure, new
                {
                    EMAIL = cuenta.EMAIL,                    
                    CONTRASENA_HASH = cuenta.CONTRASENA_HASH,

                }, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<UsuarioEntity?> ObtenerPorIdAsync(int id)
        {
            UsuarioEntity respuesta = null;
            var storeProcedure = DbConstantes.SpObtenerCuentaId;
            try
            {
                var connection = _factoryConnection.GetConnection();
                respuesta = await connection.QueryFirstAsync<UsuarioEntity>(storeProcedure, new
                {
                    ID_USUARIO = id

                }, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<Respuesta> UpdateAsync(UsuarioEntity entity)
        {
            Respuesta respuesta = null;
            var storeProcedure = DbConstantes.SpActualizarCuenta;
            try
            {
                var connection = _factoryConnection.GetConnection();
                respuesta = await connection.QueryFirstAsync<Respuesta>(storeProcedure, new
                {
                    ID_USUARIO = entity.ID_USUARIO,
                    NOMBRE = entity.NOMBRE,
                    CONTRASENA_HASH = entity.CONTRASENA_HASH,

                }, commandType: System.Data.CommandType.StoredProcedure);

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
