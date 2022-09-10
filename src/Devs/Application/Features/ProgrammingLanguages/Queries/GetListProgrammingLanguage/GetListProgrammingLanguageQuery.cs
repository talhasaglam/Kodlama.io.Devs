using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery: IRequest<GetProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, GetProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository programmingLanguageRepo;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                programmingLanguageRepo = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<GetProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> programmingLanguages = await programmingLanguageRepo.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
                if (!programmingLanguages.Items.Any())
                    return new GetProgrammingLanguageListModel();

                return _mapper.Map<GetProgrammingLanguageListModel>(programmingLanguages);
            }
        }
    }
}
