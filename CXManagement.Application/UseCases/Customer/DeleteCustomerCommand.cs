using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var applicationSystem = await _repository.GetByIdAsync(request.Id);
            if (applicationSystem == null)
                return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
