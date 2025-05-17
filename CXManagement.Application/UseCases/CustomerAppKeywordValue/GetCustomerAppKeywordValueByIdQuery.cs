using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordValue
{
    public class GetCustomerAppKeywordValueByIdQuery : IRequest<CustomerAppKeywordValueDto>
    {
        public int CXCAKVID { get; set; }
    }

    public class GetCustomerAppKeywordValueByIdQueryHandler : IRequestHandler<GetCustomerAppKeywordValueByIdQuery, CustomerAppKeywordValueDto>
    {
        private readonly IRepository<CX_Customer_AppKeyword_Value> _repository;

        public GetCustomerAppKeywordValueByIdQueryHandler(IRepository<CX_Customer_AppKeyword_Value> repository)
        {
            _repository = repository;
        }

        public async Task<CustomerAppKeywordValueDto> Handle(GetCustomerAppKeywordValueByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXCAKVID);
            if (entity == null) return null;

            return new CustomerAppKeywordValueDto
            {
                CXCAKVID = entity.CXCAKVID,
                CXCustomerID = entity.CXCustomerID,
                CXASKID = entity.CXASKID,
                CXCAKVValueString = entity.CXCAKVValueString,
                CXCAKVAssignedDate = entity.CXCAKVAssignedDate,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            };
        }
    }
}
