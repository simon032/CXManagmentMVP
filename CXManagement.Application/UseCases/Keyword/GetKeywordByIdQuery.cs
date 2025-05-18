using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Keyword
{
    public class GetKeywordByIdQuery : IRequest<KeywordDto>
    {
        public int CXKeywordID { get; set; }
    }

    public class GetKeywordByIdQueryHandler : IRequestHandler<GetKeywordByIdQuery, KeywordDto>
    {
        private readonly IKeywordRepository _repository;

        public GetKeywordByIdQueryHandler(IKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<KeywordDto> Handle(GetKeywordByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXKeywordID);
            if (entity == null) return null;

            return new KeywordDto
            {
                CXKeywordID = entity.CXKeywordID,
                CXKeywordName = entity.CXKeywordName,
                CXKeywordDescription = entity.CXKeywordDescription,
                CXKeywordDataType = entity.CXKeywordDataType,
                CXKeywordScoringFormula = entity.CXKeywordScoringFormula,
                CXKeywordIsActive = (bool)entity.CXKeywordIsActive,
                ApplicationKeywords = entity.ApplicationKeywords?
                .Select(ak => new ApplicationKeywordDto
                {
                    CXAKID = ak.CXAKID,
                    CXASID = ak.CXASID,
                    CXKeywordID = ak.CXKeywordID,
                    CXAKWeight = ak.CXAKWeight
                })
                .ToList(),
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            };
        }
    }
}
