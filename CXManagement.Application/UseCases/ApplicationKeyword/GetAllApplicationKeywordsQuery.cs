using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationKeyword
{
    public class GetAllApplicationKeywordsQuery : IRequest<IEnumerable<ApplicationKeywordDto>> { }

    public class GetAllApplicationKeywordsQueryHandler : IRequestHandler<GetAllApplicationKeywordsQuery, IEnumerable<ApplicationKeywordDto>>
    {
        private readonly IApplicationKeywordRepository _repository;

        public GetAllApplicationKeywordsQueryHandler(IApplicationKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ApplicationKeywordDto>> Handle(GetAllApplicationKeywordsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(entity => new ApplicationKeywordDto
            {
                CXAKID = entity.CXAKID,
                CXASID = entity.CXASID,
                CXKeywordID = entity.CXKeywordID,
                CXAKWeight = entity.CXAKWeight
            });
        }
    }
}
