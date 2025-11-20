using Backend_Geo_Incidencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> LoginAsync(string correo);
        Task<UsuarioEntity?> ObtenerPorIdAsync(int id);
        Task<Respuesta> CrearAsync(UsuarioEntity entity);
        Task<Respuesta> UpdateAsync(UsuarioEntity entity);
    }
}
