using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationKeyword
{
    public class GetApplicationKeywordByIdQuery : IRequest<ApplicationKeywordDto>
    {
        public int CXAKID { get; set; }
    }

    public class GetApplicationKeywordByIdQueryHandler : IRequestHandler<GetApplicationKeywordByIdQuery, ApplicationKeywordDto>
    {
        private readonly IApplicationKeywordRepository _repository;

        public GetApplicationKeywordByIdQueryHandler(IApplicationKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationKeywordDto> Handle(GetApplicationKeywordByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXAKID);
            if (entity == null) return null;

            return new ApplicationKeywordDto
            {
                CXAKID = entity.CXAKID,
                CXASID = entity.CXASID,
                CXKeywordID = entity.CXKeywordID,
                CXAKWeight = entity.CXAKWeight
            };
        }
    }
}
