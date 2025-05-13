using CXManagement.Application.DTOs.CustomerJourney;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerJourney
{
    public class UpdateCustomerJourneyCommand : IRequest<bool>
    {
        public UpdateCustomerJourneyDto UpdateDto { get; set; }

        public UpdateCustomerJourneyCommand(UpdateCustomerJourneyDto updateDto)
        {
            UpdateDto = updateDto;
        }
    }
    public class UpdateCustomerJourneyCommandHandler : IRequestHandler<UpdateCustomerJourneyCommand, bool>
    {
        private readonly ICustomerJourneyRepository _repository;

        public UpdateCustomerJourneyCommandHandler(ICustomerJourneyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCustomerJourneyCommand request, CancellationToken cancellationToken)
        {
            var customerJourney = await _repository.GetByIdAsync(request.UpdateDto.CXCustomerJourneyID);
            if (customerJourney == null)
                return false;

            customerJourney.CXCustomerID = request.UpdateDto.CXCustomerID;
            customerJourney.CXCustomerJourneyKeywordIDs = request.UpdateDto?.CXCustomerJourneyKeywordIDs;
            customerJourney.CXCustomerJourneyStage = request.UpdateDto.CXCustomerJourneyStage;
            customerJourney.CXCustomerJourneyScoreSnapshot = request.UpdateDto.CXCustomerJourneyScoreSnapshot;
            customerJourney.ModifyAt = DateTime.UtcNow;
            customerJourney.CreateBy = request.UpdateDto.CreateBy;

            await _repository.UpdateAsync(customerJourney);
            return true;
        }
    }
}

