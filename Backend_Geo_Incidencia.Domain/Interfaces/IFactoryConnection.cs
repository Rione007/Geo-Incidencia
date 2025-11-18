using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Interfaces
{
    public interface IFactoryConnection
    {
        IDbConnection GetConnection(string connectionName = "DefaultBaseConnection");
        void CloseConnection();
    }
}
