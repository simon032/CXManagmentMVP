using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerScore
{
    public class DeleteCustomerScoreCommand : IRequest<bool>
    {

        public int Id { get; set; }

        public DeleteCustomerScoreCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteCustomerScoreCommandHandler : IRequestHandler<DeleteCustomerScoreCommand, bool>
    {
        private readonly ICustomerScoreRepository _repository;

        public DeleteCustomerScoreCommandHandler(ICustomerScoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCustomerScoreCommand request, CancellationToken cancellationToken)
        {
            var customerScore = await _repository.GetByIdAsync(request.Id);
            if (customerScore == null)
                return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
