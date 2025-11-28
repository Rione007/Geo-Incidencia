using AutoMapper;
using Backend_Geo_Incidencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Features.Incidencia.Dtos
{
    public class IncidenciaProfile : Profile
    {
        public IncidenciaProfile()
        {
            CreateMap<IncidenciaEntity, IncidenciaDto>().ReverseMap();
        }
    }
}
