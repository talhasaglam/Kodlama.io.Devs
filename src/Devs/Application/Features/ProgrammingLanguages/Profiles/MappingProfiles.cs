using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage,CreateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage,CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, GetProgrammingLanguageDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, GetProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetProgrammingLanguageListDto>().ReverseMap();
        }
    }
}
