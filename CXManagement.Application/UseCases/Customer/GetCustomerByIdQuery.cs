using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int CXCustomerID { get; set; }
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
            var entity = await _repository.GetByIdAsync(request.CXCustomerID);
            if (entity == null) return null;

            return new CustomerDto
            {
                CXCustomerID = entity.CXCustomerID,
                CXCustomerFullName = entity.CXCustomerFullName,
                CXCustomerEmail = entity.CXCustomerEmail,
                CXCustomerPhone = entity.CXCustomerPhone,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy,
                Values = entity.Values?.Select(c => new CustomerAppKeywordValueDto
                {
                    CXCAKVID = c.CXCAKVID,
                    CXCustomerID = c.CXCustomerID,
                    CXASKID = c.CXASKID,
                    CXCAKVValueString = c.CXCAKVValueString,
                    CXCAKVAssignedDate = c.CXCAKVAssignedDate,
                    CreateAt = c.CreateAt,
                    ModifyAt = c.ModifyAt,
                    CreateBy = c.CreateBy,

                }).ToList()
            };
        }
    }
}
