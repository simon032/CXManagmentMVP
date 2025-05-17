using CXManagement.Application.DTOs.CX_JourneyEvent;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.JourneyEvent
{
    public class GetJourneyEventByIdQuery : IRequest<JourneyEventDto>
    {
        public int CXCJEID { get; set; }
    }

    public class GetJourneyEventByIdQueryHandler : IRequestHandler<GetJourneyEventByIdQuery, JourneyEventDto>
    {
        private readonly IRepository<CX_JourneyEvent> _repository;

        public GetJourneyEventByIdQueryHandler(IRepository<CX_JourneyEvent> repository)
        {
            _repository = repository;
        }

        public async Task<JourneyEventDto> Handle(GetJourneyEventByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXCJEID);
            if (entity == null) return null;

            return new JourneyEventDto
            {
                CXCJEID = entity.CXCJEID,
                CXASID = entity.CXASID,
                CXJEKeywordIDs = entity.CXJEKeywordIDs,
                CXJEStage = entity.CXJEStage?.ToString(),
                CXJEScoreSnapshot = entity.CXJEScoreSnapshot,
                CXJERequestedDate = entity.CXJERequestedDate,
                CXJEFromDate = entity.CXJEFromDate,
                CXJEToDate = entity.CXJEToDate,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            };
        }
    }
}
