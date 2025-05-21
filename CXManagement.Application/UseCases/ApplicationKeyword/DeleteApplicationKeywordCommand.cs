using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationKeyword
{
    public class DeleteApplicationKeywordCommand : IRequest<bool>
    {
        public int CXAKID { get; set; }
    }

    public class DeleteApplicationKeywordCommandHandler : IRequestHandler<DeleteApplicationKeywordCommand, bool>
    {
        private readonly IApplicationKeywordRepository _repository;

        public DeleteApplicationKeywordCommandHandler(IApplicationKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteApplicationKeywordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXAKID);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
