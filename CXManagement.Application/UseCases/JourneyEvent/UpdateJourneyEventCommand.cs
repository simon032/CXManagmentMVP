using CXManagement.Application.DTOs.CX_JourneyEvent;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Enums;
using MediatR;

namespace CXManagement.Application.UseCases.JourneyEvent
{
    public class UpdateJourneyEventCommand : IRequest<bool>
    {
        public UpdateJourneyEventDto JourneyEventDto { get; set; }
    }

    public class UpdateJourneyEventCommandHandler : IRequestHandler<UpdateJourneyEventCommand, bool>
    {
        private readonly IJourneyEventRepository _repository;

        public UpdateJourneyEventCommandHandler(IJourneyEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateJourneyEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.JourneyEventDto.CXCJEID);
            if (entity == null) return false;

            entity.CXASID = request.JourneyEventDto.CXASID;
            entity.CXJEKeywordIDs = request.JourneyEventDto.CXJEKeywordIDs;
            entity.CXJEStage = Enum.TryParse<JourneyEventStage>(request.JourneyEventDto.CXJEStage, out var stage) ? stage : null;
            entity.CXJEScoreSnapshot = (float?)request.JourneyEventDto.CXJEScoreSnapshot;
            entity.CXJERequestedDate = request.JourneyEventDto.CXJERequestedDate;
            entity.CXJEFromDate = request.JourneyEventDto.CXJEFromDate;
            entity.CXJEToDate = request.JourneyEventDto.CXJEToDate;
            entity.ModifyAt = request.JourneyEventDto.ModifyAt;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
