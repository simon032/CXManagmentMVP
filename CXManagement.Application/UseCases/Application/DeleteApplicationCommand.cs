using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class DeleteApplicationCommand : IRequest<bool>
    {
        public int CXAID { get; set; }
    }

    public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, bool>
    {
        private readonly IApplicationRepository _repository;

        public DeleteApplicationCommandHandler(IApplicationRepository repository)
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
