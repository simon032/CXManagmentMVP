using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Score;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordScore
{
    public class UpdateCustomerAppKeywordScoreCommand : IRequest<bool>
    {
        public UpdateCustomerAppKeywordScoreDto ScoreDto { get; set; }
    }

    public class UpdateCustomerAppKeywordScoreCommandHandler : IRequestHandler<UpdateCustomerAppKeywordScoreCommand, bool>
    {
        private readonly IRepository<CX_Customer_AppKeyword_Score> _repository;

        public UpdateCustomerAppKeywordScoreCommandHandler(IRepository<CX_Customer_AppKeyword_Score> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCustomerAppKeywordScoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ScoreDto.CXCAKScoreID);
            if (entity == null) return false;

            entity.CXCustomerID = request.ScoreDto.CXCustomerID;
            entity.CXASKID = request.ScoreDto.CXASKID;
            entity.CXCAKCalculatedScore = (float?)request.ScoreDto.CXCAKCalculatedScore;
            entity.CXCAKCalculatedDate = request.ScoreDto.CXCAKCalculatedDate;
            entity.ModifyAt = request.ScoreDto.ModifyAt;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
