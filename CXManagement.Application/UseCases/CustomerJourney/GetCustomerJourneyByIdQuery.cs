using CXManagement.Application.DTOs.CustomerJourney;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerJourney
{
    public class GetCustomerJourneyByIdQuery : IRequest<CustomerJourneyDto>
    {
        public int Id { get; set; }

        public GetCustomerJourneyByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetCustomerJourneyByIdQueryHandler : IRequestHandler<GetCustomerJourneyByIdQuery, CustomerJourneyDto>
    {
        private readonly ICustomerJourneyRepository _repository;

        public GetCustomerJourneyByIdQueryHandler(ICustomerJourneyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerJourneyDto> Handle(GetCustomerJourneyByIdQuery request, CancellationToken cancellationToken)
        {
            var customerJourney = await _repository.GetByIdAsync(request.Id);
            if (customerJourney == null)
                return null;

            return new CustomerJourneyDto
            {
                CXCustomerJourneyID = customerJourney.CXCustomerJourneyID,
                CXCustomerID = customerJourney.CXCustomerID,
                CXCustomerJourneyKeywordIDs = customerJourney?.CXCustomerJourneyKeywordIDs,
                CXCustomerJourneyStage = customerJourney.CXCustomerJourneyStage,
                CXCustomerJourneyScoreSnapshot = customerJourney.CXCustomerJourneyScoreSnapshot,
                CreateAt = customerJourney.CreateAt,
                ModifyAt = customerJourney.ModifyAt,
                CreateBy = customerJourney.CreateBy,
            };
        }
    }
}
