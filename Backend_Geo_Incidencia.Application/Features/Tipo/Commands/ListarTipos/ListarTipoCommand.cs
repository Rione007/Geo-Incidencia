using Backend_Geo_Incidencia.Application.Features.Tipo.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Tipo.Commands.ListarTipos
{
    public class ListarTipoCommand : IRequest<List<ListarTipoResponse>>
    {
    }

    public class ListarTipoResponse
    {
        public List<TipoDto> Tipos { get; set; } = new List<TipoDto>();
        public string? Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public bool Exito => CodigoRespuesta == 0;
    }
}
