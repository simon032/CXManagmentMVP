using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
    }

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(entity => new CustomerDto
            {
                CXCustomerID = entity.CXCustomerID,
                CXCustomerFullName = entity.CXCustomerFullName,
                CXCustomerEmail = entity.CXCustomerEmail,
                CXCustomerPhone = entity.CXCustomerPhone,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            });
        }
    }
}
