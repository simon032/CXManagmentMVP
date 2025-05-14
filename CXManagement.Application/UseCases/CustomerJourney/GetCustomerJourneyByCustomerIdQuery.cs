using CXManagement.Application.DTOs.CustomerJourney;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerJourney
{
    public class GetCustomerJourneyByCustomerIdQuery : IRequest<List<CustomerJourneyDto>>
    {

        public int CustomerId { get; set; }

        public GetCustomerJourneyByCustomerIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
    public class GetCustomerJourneyByCustomerIdQueryHandler : IRequestHandler<GetCustomerJourneyByCustomerIdQuery, List<CustomerJourneyDto>>
    {
        private readonly ICustomerJourneyRepository _repository;

        public GetCustomerJourneyByCustomerIdQueryHandler(ICustomerJourneyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerJourneyDto>> Handle(GetCustomerJourneyByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customerJourney = await _repository.GetByCustomerIdAsync(request.CustomerId);
            if (customerJourney == null || !customerJourney.Any())
                return new List<CustomerJourneyDto>();

            var dtoList = customerJourney.Select(x => new CustomerJourneyDto
            {
                CXCustomerJourneyID = x.CXCustomerJourneyID,
                CXCustomerID = x.CXCustomerID,
                CXCustomerJourneyKeywordIDs = x?.CXCustomerJourneyKeywordIDs,
                CXCustomerJourneyStage = x.CXCustomerJourneyStage,
                CXCustomerJourneyScoreSnapshot = x.CXCustomerJourneyScoreSnapshot,
                CreateAt = x.CreateAt,
                ModifyAt = x.ModifyAt,
                CreateBy = x.CreateBy,

            }).ToList();

            return dtoList;
        }
    }
}
