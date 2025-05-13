using CXManagement.Application.DTOs.Customer;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public CreateCustomerDto CreateDto { get; set; }

        public CreateCustomerCommand(CreateCustomerDto createDto)
        {
            CreateDto = createDto;
        }
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new CXManagmentMVP.Domain.Entities.Customer
            {
                CXCustomerFullName = request.CreateDto.CXCustomerFullName,
                CXCustomerEmail = request.CreateDto.CXCustomerEmail,
                CXCustomerPhone = request.CreateDto.CXCustomerPhone,
                CXCustomerExternalCustomerId = request.CreateDto.CXCustomerExternalCustomerId,
                CreateBy = request.CreateDto.CreateBy,
                CreateAt = DateTime.UtcNow
            };

            await _repository.AddAsync(customer);
            return customer.CXCustomerID;
        }
    }
}
