using Backend_Geo_Incidencia.Domain.Entities;
using Backend_Geo_Incidencia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<Respuesta> CrearAsync(UsuarioEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> LoginAsync(UsuarioEntity cuenta)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity?> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> UpdateAsync(UsuarioEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
