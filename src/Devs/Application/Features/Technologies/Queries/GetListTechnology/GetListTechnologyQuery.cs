using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery : IRequest<GetTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, GetTechnologyListModel>
        {
            private readonly ITechnologyRepository technologyRepository;
            private readonly IMapper _mapper;

            public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepo, IMapper mapper)
            {
                technologyRepository = technologyRepo;
                _mapper = mapper;
            }

            public async Task<GetTechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> programmingLanguages = await technologyRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,include: x=>x.Include(y=>y.ProgrammingLanguage),
                    cancellationToken: cancellationToken);
                if (!programmingLanguages.Items.Any())
                    return new GetTechnologyListModel();

                return _mapper.Map<GetTechnologyListModel>(programmingLanguages);
            }
        }
    }
}
