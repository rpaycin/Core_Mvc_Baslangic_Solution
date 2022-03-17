using App.Core.Dto;
using App.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Service.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ParamGen, ParamGenDto>().ReverseMap();
        }
    }
}
