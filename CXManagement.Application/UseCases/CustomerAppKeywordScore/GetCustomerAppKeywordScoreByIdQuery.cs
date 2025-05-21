using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Score;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordScore
{
    public class GetCustomerAppKeywordScoreByIdQuery : IRequest<CustomerAppKeywordScoreDto>
    {
        public int CXCAKScoreID { get; set; }
    }

    public class GetCustomerAppKeywordScoreByIdQueryHandler : IRequestHandler<GetCustomerAppKeywordScoreByIdQuery, CustomerAppKeywordScoreDto>
    {
        private readonly ICustomerAppKeywordScoreRepository _repository;

        public GetCustomerAppKeywordScoreByIdQueryHandler(ICustomerAppKeywordScoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerAppKeywordScoreDto> Handle(GetCustomerAppKeywordScoreByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXCAKScoreID);
            if (entity == null) return null;

            return new CustomerAppKeywordScoreDto
            {
                CXCAKScoreID = entity.CXCAKScoreID,
                CXCustomerID = entity.CXCustomerID,
                CXASKID = entity.CXASKID,
                CXCAKCalculatedScore = entity.CXCAKCalculatedScore,
                CXCAKCalculatedDate = entity.CXCAKCalculatedDate,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            };
        }
    }
}
