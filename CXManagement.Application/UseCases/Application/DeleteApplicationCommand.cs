using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class DeleteApplicationCommand : IRequest<bool>
    {
        public int CXAID { get; set; }
    }

    public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, bool>
    {
        private readonly IRepository<CX_Application> _repository;

        public DeleteApplicationCommandHandler(IRepository<CX_Application> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXAID);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
