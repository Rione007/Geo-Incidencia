using Backend_Geo_Incidencia.Application.Features.SubTipo.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.SubTipo.Commands.ListarSubtipos
{
    public class ListarSubtipoCommand : IRequest<List<ListarSubtipoResponse>>
    {
    }

    public class  ListarSubtipoResponse
    {
        public List<SubtipoDto> Subtipos { get; set; } = new List<SubtipoDto>();
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
