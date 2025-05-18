using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationKeyword
{
    public class DeleteByKeywordIdApplicationIdCommand : IRequest<bool>
    {
        public int KeywordId { get; set; }
        public int ApplicationId { get; set; }
    }
    public class DeleteByKeywordIdApplicationIdCommandHandler : IRequestHandler<DeleteByKeywordIdApplicationIdCommand, bool>
    {
        private readonly IApplicationKeywordRepository _repository;

        public DeleteByKeywordIdApplicationIdCommandHandler(IApplicationKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteByKeywordIdApplicationIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByKeywordIdApplicationIdAsync(request.KeywordId, request.ApplicationId);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
