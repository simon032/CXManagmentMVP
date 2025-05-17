using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Score;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordScore
{
    public class CreateCustomerAppKeywordScoreCommand : IRequest<int>
    {
        public CreateCustomerAppKeywordScoreDto ScoreDto { get; set; }
    }

    public class CreateCustomerAppKeywordScoreCommandHandler : IRequestHandler<CreateCustomerAppKeywordScoreCommand, int>
    {
        private readonly IRepository<CX_Customer_AppKeyword_Score> _repository;

        public CreateCustomerAppKeywordScoreCommandHandler(IRepository<CX_Customer_AppKeyword_Score> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCustomerAppKeywordScoreCommand request, CancellationToken cancellationToken)
        {
            var entity = new CX_Customer_AppKeyword_Score
            {
                CXCustomerID = request.ScoreDto.CXCustomerID,
                CXASKID = request.ScoreDto.CXASKID,
                CXCAKCalculatedScore = (float?)request.ScoreDto.CXCAKCalculatedScore,
                CXCAKCalculatedDate = request.ScoreDto.CXCAKCalculatedDate,
                CreateAt = request.ScoreDto.CreateAt,
                CreateBy = request.ScoreDto.CreateBy
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.CXCAKScoreID;
        }
    }
}
