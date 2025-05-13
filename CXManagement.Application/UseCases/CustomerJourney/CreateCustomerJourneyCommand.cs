using CXManagement.Application.DTOs.CustomerJourney;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerJourney
{
    public class CreateCustomerJourneyCommand : IRequest<int>
    {
        public CreateCustomerJourneyDto CreateDto { get; set; }
        public CreateCustomerJourneyCommand(CreateCustomerJourneyDto createDto)
        {
            CreateDto = createDto;
        }
    }
    public class CreateCustomerJourneyCommandHandler : IRequestHandler<CreateCustomerJourneyCommand, int>
    {
        private readonly ICustomerJourneyRepository _repository;

        public CreateCustomerJourneyCommandHandler(ICustomerJourneyRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCustomerJourneyCommand request, CancellationToken cancellationToken)
        {
            var customerJourney = new CXManagmentMVP.Domain.Entities.CustomerJourney
            {
                CXCustomerID = request.CreateDto.CXCustomerID,
                CXCustomerJourneyKeywordIDs = request.CreateDto.CXCustomerJourneyKeywordIDs,
                CXCustomerJourneyStage = request.CreateDto.CXCustomerJourneyStage,
                CXCustomerJourneyScoreSnapshot = request.CreateDto.CXCustomerJourneyScoreSnapshot,
                CreateBy = request.CreateDto.CreateBy,
                CreateAt = DateTime.UtcNow
            };

            await _repository.AddAsync(customerJourney);
            return customerJourney.CXCustomerJourneyID;
        }
    }

}
