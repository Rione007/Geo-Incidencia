using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        public Task<List<TipoEntity>> ListarTiposAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TipoEntity?> ObtenerTipoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
