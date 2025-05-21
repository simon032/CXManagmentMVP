using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Keyword
{
    public class CreateKeywordCommand : IRequest<int>
    {
        public CreateKeywordDto Keyword { get; set; }
    }

    public class CreateKeywordCommandHandler : IRequestHandler<CreateKeywordCommand, int>
    {
        private readonly IKeywordRepository _repository;

        public CreateKeywordCommandHandler(IKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateKeywordCommand request, CancellationToken cancellationToken)
        {
            var entity = new CX_Keyword
            {
                CXKeywordName = request.Keyword.CXKeywordName,
                CXKeywordDescription = request.Keyword.CXKeywordDescription,
                CXKeywordDataType = request.Keyword.CXKeywordDataType,
                CXKeywordScoringFormula = request.Keyword.CXKeywordScoringFormula,
                CXKeywordIsActive = request.Keyword.CXKeywordIsActive,
                CreateAt = request.Keyword.CreateAt ?? DateTime.UtcNow,
                CreateBy = request.Keyword.CreateBy
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.CXKeywordID;
        }
    }
}
