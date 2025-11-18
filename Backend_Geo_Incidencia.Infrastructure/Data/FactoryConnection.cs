using Backend_Geo_Incidencia.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Data
{
    public class FactoryConnection : IFactoryConnection
    {
        private readonly IConfiguration _configuration;
        private IDbConnection? _connection;

        public FactoryConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnection(string connectionName = "DefaultBaseConnection")
        {

            var connectionString = _configuration.GetConnectionString(connectionName);

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"No se encontró la cadena de conexión: {connectionName}");

            if (_connection == null)
                _connection = new SqlConnection(connectionString);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            return _connection;
        }
        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
