using CXManagement.Application.DTOs.CX_JourneyEvent;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using CXManagmentMVP.Domain.Enums;
using MediatR;

namespace CXManagement.Application.UseCases.JourneyEvent
{
    public class CreateJourneyEventCommand : IRequest<int>
    {
        public CreateJourneyEventDto JourneyEventDto { get; set; }
    }

    public class CreateJourneyEventCommandHandler : IRequestHandler<CreateJourneyEventCommand, int>
    {
        private readonly IRepository<CX_JourneyEvent> _repository;

        public CreateJourneyEventCommandHandler(IRepository<CX_JourneyEvent> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateJourneyEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new CX_JourneyEvent
            {
                CXASID = request.JourneyEventDto.CXASID,
                CXJEKeywordIDs = request.JourneyEventDto.CXJEKeywordIDs,
                CXJEStage = Enum.TryParse<JourneyEventStage>(request.JourneyEventDto.CXJEStage, out var stage) ? stage : null,
                CXJEScoreSnapshot = (float?)request.JourneyEventDto.CXJEScoreSnapshot,
                CXJERequestedDate = request.JourneyEventDto.CXJERequestedDate,
                CXJEFromDate = request.JourneyEventDto.CXJEFromDate,
                CXJEToDate = request.JourneyEventDto.CXJEToDate,
                CreateAt = request.JourneyEventDto.CreateAt,
                CreateBy = request.JourneyEventDto.CreateBy
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.CXCJEID;
        }
    }
}
