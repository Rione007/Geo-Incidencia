using Backend_Geo_Incidencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Interfaces
{
    public interface ISubtipoRepository
    {
        Task<List<SubtipoEntity>> ListarSubtipoAsync();
        Task<SubtipoEntity?> ObtenerSubtipoPorIdAsync(int id);

    }
}
