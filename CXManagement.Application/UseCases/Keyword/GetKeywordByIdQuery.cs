using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Keyword
{
    public class GetKeywordByIdQuery : IRequest<KeywordDto>
    {
        public int CXKeywordID { get; set; }
    }

    public class GetKeywordByIdQueryHandler : IRequestHandler<GetKeywordByIdQuery, KeywordDto>
    {
        private readonly IRepository<CX_Keyword> _repository;

        public GetKeywordByIdQueryHandler(IRepository<CX_Keyword> repository)
        {
            _repository = repository;
        }

        public async Task<KeywordDto> Handle(GetKeywordByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXKeywordID);
            if (entity == null) return null;

            return new KeywordDto
            {
                CXKeywordID = entity.CXKeywordID,
                CXKeywordName = entity.CXKeywordName,
                CXKeywordDescription = entity.CXKeywordDescription,
                CXKeywordDataType = entity.CXKeywordDataType,
                CXKeywordScoringFormula = entity.CXKeywordScoringFormula,
                CXKeywordIsActive = entity.CXKeywordIsActive,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            };
        }
    }
}
