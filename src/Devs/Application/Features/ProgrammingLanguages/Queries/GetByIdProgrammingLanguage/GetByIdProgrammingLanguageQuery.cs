using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery:IRequest<GetProgrammingLanguageDto>
    {
        public Guid Id { get; set; }
        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, GetProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository programmingLanguageRepo;
            private readonly IMapper _mapper;

            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                programmingLanguageRepo = programmingLanguageRepository;
                _mapper = mapper;
            }
            public async Task<GetProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await programmingLanguageRepo.GetAsync(x => x.Id == request.Id);
                if (programmingLanguage == null)
                    throw new EntityNotFoundException(nameof(ProgrammingLanguage));
                var getProgrammingLanguageDto = _mapper.Map<GetProgrammingLanguageDto>(programmingLanguage);
                return getProgrammingLanguageDto;
            }
        }
    }
}
