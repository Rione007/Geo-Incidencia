using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string hashedPassword, string password);
    }
}
