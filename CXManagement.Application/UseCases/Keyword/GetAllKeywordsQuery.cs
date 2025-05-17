using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Keyword
{
    public class GetAllKeywordsQuery : IRequest<IEnumerable<KeywordDto>> { }

    public class GetAllKeywordsQueryHandler : IRequestHandler<GetAllKeywordsQuery, IEnumerable<KeywordDto>>
    {
        private readonly IRepository<CX_Keyword> _repository;

        public GetAllKeywordsQueryHandler(IRepository<CX_Keyword> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<KeywordDto>> Handle(GetAllKeywordsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(entity => new KeywordDto
            {
                CXKeywordID = entity.CXKeywordID,
                CXKeywordName = entity.CXKeywordName,
                CXKeywordDescription = entity.CXKeywordDescription,
                CXKeywordDataType = entity.CXKeywordDataType,
                CXKeywordScoringFormula = entity.CXKeywordScoringFormula,
                CXKeywordIsActive = entity.CXKeywordIsActive,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            });
        }
    }
}
