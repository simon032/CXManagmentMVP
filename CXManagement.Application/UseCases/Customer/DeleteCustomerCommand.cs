using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int CXCustomerID { get; set; }
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
            var entity = await _repository.GetByIdAsync(request.CXCustomerID);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
