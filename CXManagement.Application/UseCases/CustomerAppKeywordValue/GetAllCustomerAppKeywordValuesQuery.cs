using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordValue
{
    public class GetAllCustomerAppKeywordValuesQuery : IRequest<IEnumerable<CustomerAppKeywordValueDto>> { }

    public class GetAllCustomerAppKeywordValuesQueryHandler : IRequestHandler<GetAllCustomerAppKeywordValuesQuery, IEnumerable<CustomerAppKeywordValueDto>>
    {
        private readonly ICustomerAppKeywordValueRepository _repository;

        public GetAllCustomerAppKeywordValuesQueryHandler(ICustomerAppKeywordValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerAppKeywordValueDto>> Handle(GetAllCustomerAppKeywordValuesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(e => new CustomerAppKeywordValueDto
            {
                CXCAKVID = e.CXCAKVID,
                CXCustomerID = e.CXCustomerID,
                CXASKID = e.CXASKID,
                CXCAKVValueString = e.CXCAKVValueString,
                CXCAKVAssignedDate = e.CXCAKVAssignedDate,
                CreateAt = e.CreateAt,
                ModifyAt = e.ModifyAt,
                CreateBy = e.CreateBy
            });
        }
    }
}
