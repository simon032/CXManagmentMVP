using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Keyword
{
    public class DeleteKeywordCommand : IRequest<bool>
    {
        public int CXKeywordID { get; set; }
    }

    public class DeleteKeywordCommandHandler : IRequestHandler<DeleteKeywordCommand, bool>
    {
        private readonly IKeywordRepository _repository;

        public DeleteKeywordCommandHandler(IKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteKeywordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXKeywordID);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
