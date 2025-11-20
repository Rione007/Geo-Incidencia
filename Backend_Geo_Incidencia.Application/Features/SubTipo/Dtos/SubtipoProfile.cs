using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.SubTipo.Dtos
{
    public class SubtipoProfile : Profile
    {
        public SubtipoProfile()
        {
            CreateMap<Domain.Entities.SubtipoEntity, SubtipoDto>().ReverseMap();
        }
    }
}
