using Backend_Geo_Incidencia.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Backend_Geo_Incidencia.Infrastructure.Jwt
{
    public interface IJwtService
    {
        string GenerateJwtToken(Session session);
        Session GetSessionFromToken(string token);
    }
}
