using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerJourney
{
    public class DeleteCustomerJourneyCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCustomerJourneyCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteCustomerJourneyCommandHandler : IRequestHandler<DeleteCustomerJourneyCommand, bool>
    {
        private readonly ICustomerJourneyRepository _repository;

        public DeleteCustomerJourneyCommandHandler(ICustomerJourneyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCustomerJourneyCommand request, CancellationToken cancellationToken)
        {
            var customerJourney = await _repository.GetByIdAsync(request.Id);
            if (customerJourney == null)
                return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
