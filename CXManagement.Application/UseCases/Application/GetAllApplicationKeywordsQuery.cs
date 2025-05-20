using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class GetAllApplicationKeywordsQuery : IRequest<IEnumerable<ApplicationDto>>
    {
    }
    public class GetAllApplicationKeywordsQueryHandler : IRequestHandler<GetAllApplicationKeywordsQuery, IEnumerable<ApplicationDto>>
    {
        private readonly IApplicationRepository _repository;

        public GetAllApplicationKeywordsQueryHandler(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ApplicationDto>> Handle(GetAllApplicationKeywordsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllApplicationKeywords();

            return entities.Select(entity => new ApplicationDto
            {
                CXAID = entity.CXAID,
                CXAName = entity.CXAName,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy,
                ApplicationKeywords = entity.ApplicationKeywords?
                .Select(ak => new ApplicationKeywordDto
                {
                    CXAKID = ak.CXAKID,
                    CXASID = ak.CXASID,
                    CXKeywordID = ak.CXKeywordID,
                    CXAKWeight = ak.CXAKWeight
                })
                .ToList(),
            });
        }
    }
}
