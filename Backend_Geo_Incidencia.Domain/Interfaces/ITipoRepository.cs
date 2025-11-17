using Backend_Geo_Incidencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Interfaces
{
    public interface ITipoRepository
    {
        Task<List<TipoEntity>>ListarTiposAsync();
        Task<TipoEntity?> ObtenerTipoPorIdAsync(int id);

    }
}
