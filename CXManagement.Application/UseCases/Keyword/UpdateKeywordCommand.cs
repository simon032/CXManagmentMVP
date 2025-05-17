using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Keyword
{
    public class UpdateKeywordCommand : IRequest<bool>
    {
        public UpdateKeywordDto Keyword { get; set; }
    }

    public class UpdateKeywordCommandHandler : IRequestHandler<UpdateKeywordCommand, bool>
    {
        private readonly IRepository<CX_Keyword> _repository;

        public UpdateKeywordCommandHandler(IRepository<CX_Keyword> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateKeywordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Keyword.CXKeywordID);
            if (entity == null) return false;

            entity.CXKeywordName = request.Keyword.CXKeywordName;
            entity.CXKeywordDescription = request.Keyword.CXKeywordDescription;
            entity.CXKeywordDataType = request.Keyword.CXKeywordDataType;
            entity.CXKeywordScoringFormula = request.Keyword.CXKeywordScoringFormula;
            entity.CXKeywordIsActive = request.Keyword.CXKeywordIsActive;
            entity.ModifyAt = request.Keyword.ModifyAt ?? DateTime.UtcNow;
            entity.CreateBy = request.Keyword.ModifyBy;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }

}
