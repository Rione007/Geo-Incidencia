using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Repositories
{
    public class SubtipoRepository : ISubtipoRepository
    {
        public Task<List<SubtipoEntity>> ListarSubtipoPorTipoIdAsync(int tipoId)
        {
            throw new NotImplementedException();
        }

        public Task<SubtipoEntity?> ObtenerSubtipoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
