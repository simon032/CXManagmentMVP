using CXManagement.Application.DTOs.Customer;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class GetAllCustomerQuery : IRequest<List<CustomerDto>>
    {
        public GetAllCustomerQuery() { }
    }
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomerQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetAllAsync();

            if (customer == null || !customer.Any())
                return new List<CustomerDto>();

            var dtoList = customer.Select(x => new CustomerDto
            {
                CXCustomerID = x.CXCustomerID,
                CXCustomerFullName = x.CXCustomerFullName,
                CXCustomerEmail = x.CXCustomerEmail,
                CXCustomerPhone = x.CXCustomerPhone,
                CXCustomerExternalCustomerId = x.CXCustomerExternalCustomerId,
                CreateAt = x.CreateAt,
                ModifyAt = x.ModifyAt,
                CreateBy = x.CreateBy
            }).ToList();

            return dtoList;
        }
    }
}
