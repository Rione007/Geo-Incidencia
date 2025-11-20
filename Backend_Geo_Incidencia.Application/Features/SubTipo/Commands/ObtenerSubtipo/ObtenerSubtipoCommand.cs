using Backend_Geo_Incidencia.Application.Features.SubTipo.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.SubTipo.Commands.ObtenerSubtipo
{
    public class ObtenerSubtipoCommand :IRequest<SubtipoResponse>
    {
        public int ID_SUBTIPO { get; set; }
    }


    public class SubtipoResponse
    {
        public SubtipoDto Subtipo { get; set; } 
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
