using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Score;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordScore
{
    public class GetAllCustomerAppKeywordScoresQuery : IRequest<IEnumerable<CustomerAppKeywordScoreDto>> { }

    public class GetAllCustomerAppKeywordScoresQueryHandler : IRequestHandler<GetAllCustomerAppKeywordScoresQuery, IEnumerable<CustomerAppKeywordScoreDto>>
    {
        private readonly ICustomerAppKeywordScoreRepository _repository;

        public GetAllCustomerAppKeywordScoresQueryHandler(ICustomerAppKeywordScoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerAppKeywordScoreDto>> Handle(GetAllCustomerAppKeywordScoresQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(e => new CustomerAppKeywordScoreDto
            {
                CXCAKScoreID = e.CXCAKScoreID,
                CXCustomerID = e.CXCustomerID,
                CXASKID = e.CXASKID,
                CXCAKCalculatedScore = e.CXCAKCalculatedScore,
                CXCAKCalculatedDate = e.CXCAKCalculatedDate,
                CreateAt = e.CreateAt,
                ModifyAt = e.ModifyAt,
                CreateBy = e.CreateBy
            });
        }
    }
}
