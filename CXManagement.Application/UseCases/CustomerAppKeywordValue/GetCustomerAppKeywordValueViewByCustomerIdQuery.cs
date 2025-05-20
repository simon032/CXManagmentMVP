using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordValue
{
    public class GetCustomerAppKeywordValueViewByCustomerIdQuery : IRequest<List<CustomerAppKeywordValueViewDto>>
    {
        public int CXCustomerID { get; set; }
    }
    public class GetCustomerAppKeywordValueViewByCustomerIdQueryHandler : IRequestHandler<GetCustomerAppKeywordValueViewByCustomerIdQuery, List<CustomerAppKeywordValueViewDto>>
    {
        private readonly ICustomerAppKeywordValueRepository _repository;

        public GetCustomerAppKeywordValueViewByCustomerIdQueryHandler(ICustomerAppKeywordValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerAppKeywordValueViewDto>> Handle(GetCustomerAppKeywordValueViewByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetCustomerAppKeywordValueViewByCustomerId(request.CXCustomerID);
            if (entities == null) return null;

            return entities.Select(e => new CustomerAppKeywordValueViewDto
            {
                CXCAKVID = e.CXCAKVID,
                CXCustomerID = e.CXCustomerID,
                CXASKID = e.CXASKID,
                CXCAKVValueString = e.CXCAKVValueString,
                CXCAKVAssignedDate = e.CXCAKVAssignedDate,
                CreateAt = e.CreateAt,
                ModifyAt = e.ModifyAt,
                CreateBy = e.CreateBy,
                ApplicationID = e.ApplicationKeyword?.Application?.CXAID,
                ApplicationName = e.ApplicationKeyword?.Application?.CXAName,
                KeywordID = e.ApplicationKeyword?.Keyword?.CXKeywordID,
                KeywordName = e.ApplicationKeyword?.Keyword?.CXKeywordName

            }).ToList();
        }
    }
}
