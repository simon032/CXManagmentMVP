using CXManagement.Application.DTOs.Customer;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int CustomerId { get; set; }

        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.CustomerId);

            if (customer == null) return null;

            return new CustomerDto
            {
                CXCustomerID = customer.CXCustomerID,
                CXCustomerFullName = customer.CXCustomerFullName,
                CXCustomerEmail = customer.CXCustomerEmail,
                CXCustomerPhone = customer.CXCustomerPhone,
                CXCustomerExternalCustomerId = customer.CXCustomerExternalCustomerId,
                CreateAt = customer.CreateAt,
                ModifyAt = customer.ModifyAt,
                CreateBy = customer.CreateBy
            };
        }
    }
}