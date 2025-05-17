using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationKeyword
{
    public class DeleteApplicationKeywordCommand : IRequest<bool>
    {
        public int CXAKID { get; set; }
    }

    public class DeleteApplicationKeywordCommandHandler : IRequestHandler<DeleteApplicationKeywordCommand, bool>
    {
        private readonly IRepository<CX_Application_Keyword> _repository;

        public DeleteApplicationKeywordCommandHandler(IRepository<CX_Application_Keyword> repository)
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
