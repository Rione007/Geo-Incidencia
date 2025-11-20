using Backend_Geo_Incidencia.Application.Features.Tipo.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ObtenerTipo
{
    public class ObtenerTipoCommand : IRequest<TipoResponse>
    {
        public int ID_TIPO { get; set; }
    }

    public class TipoResponse
    {
        public TipoDto Tipo { get; set; } 
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
