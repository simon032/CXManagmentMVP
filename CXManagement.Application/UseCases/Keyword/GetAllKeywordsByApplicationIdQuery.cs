using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Keyword
{
    public class GetAllKeywordsByApplicationIdQuery : IRequest<IEnumerable<KeywordDto>>
    {
        public int ApplicationId { get; set; }
    }
    public class GetAllKeywordsByApplicationIdQueryHandler : IRequestHandler<GetAllKeywordsByApplicationIdQuery, IEnumerable<KeywordDto>>
    {
        private readonly IKeywordRepository _repository;

        public GetAllKeywordsByApplicationIdQueryHandler(IKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<KeywordDto>> Handle(GetAllKeywordsByApplicationIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllKeywordsByApplicationId(request.ApplicationId);

            return entities.Select(entity => new KeywordDto
            {
                CXKeywordID = entity.CXKeywordID,
                CXKeywordName = entity.CXKeywordName,
                CXKeywordDescription = entity.CXKeywordDescription,
                CXKeywordDataType = entity.CXKeywordDataType,
                CXKeywordScoringFormula = entity.CXKeywordScoringFormula,
                CXKeywordIsActive = (bool)entity.CXKeywordIsActive,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy,
                ApplicationKeywords = entity.ApplicationKeywords?.Select(ak => new ApplicationKeywordDto
                {
                    CXAKID = ak.CXAKID,
                    CXASID = ak.CXASID,
                    CXKeywordID = ak.CXKeywordID,
                    CXAKWeight = ak.CXAKWeight,
                    Application = ak.Application != null ? new ApplicationDto
                    {
                        CXAID = ak.Application.CXAID,
                        CXAName = ak.Application.CXAName
                    } : null
                }).ToList()
            });
        }
    }
}
