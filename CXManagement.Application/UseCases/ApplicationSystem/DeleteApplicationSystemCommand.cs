using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationSystem
{
    public class DeleteApplicationSystemCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteApplicationSystemCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteApplicationSystemCommandHandler : IRequestHandler<DeleteApplicationSystemCommand, bool>
    {
        private readonly IApplicationSystemRepository _repository;

        public DeleteApplicationSystemCommandHandler(IApplicationSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteApplicationSystemCommand request, CancellationToken cancellationToken)
        {
            var applicationSystem = await _repository.GetByIdAsync(request.Id);
            if (applicationSystem == null)
                return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
