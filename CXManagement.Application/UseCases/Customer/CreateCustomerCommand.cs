using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public CreateCustomerDto Customer { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IRepository<CX_Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<CX_Customer> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new CX_Customer
            {
                CXCustomerFullName = request.Customer.CXCustomerFullName,
                CXCustomerEmail = request.Customer.CXCustomerEmail,
                CXCustomerPhone = request.Customer.CXCustomerPhone,
                CreateAt = request.Customer.CreateAt ?? DateTime.UtcNow,
                CreateBy = request.Customer.CreateBy
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.CXCustomerID;
        }
    }
}