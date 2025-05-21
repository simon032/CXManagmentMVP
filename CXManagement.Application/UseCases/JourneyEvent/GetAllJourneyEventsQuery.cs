using CXManagement.Application.DTOs.CX_JourneyEvent;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.JourneyEvent
{
    public class GetAllJourneyEventsQuery : IRequest<IEnumerable<JourneyEventDto>> { }

    public class GetAllJourneyEventsQueryHandler : IRequestHandler<GetAllJourneyEventsQuery, IEnumerable<JourneyEventDto>>
    {
        private readonly IJourneyEventRepository _repository;

        public GetAllJourneyEventsQueryHandler(IJourneyEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JourneyEventDto>> Handle(GetAllJourneyEventsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(e => new JourneyEventDto
            {
                CXCJEID = e.CXCJEID,
                CXASID = e.CXASID,
                CXJEKeywordIDs = e.CXJEKeywordIDs,
                CXJEStage = e.CXJEStage?.ToString(),
                CXJEScoreSnapshot = e.CXJEScoreSnapshot,
                CXJERequestedDate = e.CXJERequestedDate,
                CXJEFromDate = e.CXJEFromDate,
                CXJEToDate = e.CXJEToDate,
                CreateAt = e.CreateAt,
                ModifyAt = e.ModifyAt,
                CreateBy = e.CreateBy
            });
        }
    }
}
