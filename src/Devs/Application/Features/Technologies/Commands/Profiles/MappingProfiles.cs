using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Technologies.Commands.CreateTechnology.CreateTechnology;
using Application.Features.Technologies.Commands.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Technologies.Commands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, CreateTechnologyCommandDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
        }
    }
}
