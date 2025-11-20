using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Tipo.Dtos
{
    public class TipoProfile : Profile
    {
        public TipoProfile()
        {
            CreateMap<Domain.Entities.TipoEntity, TipoDto>().ReverseMap();
        }
    }
}
