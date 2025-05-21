using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.JourneyEvent
{
    public class DeleteJourneyEventCommand : IRequest<bool>
    {
        public int CXCJEID { get; set; }
    }

    public class DeleteJourneyEventCommandHandler : IRequestHandler<DeleteJourneyEventCommand, bool>
    {
        private readonly IJourneyEventRepository _repository;

        public DeleteJourneyEventCommandHandler(IJourneyEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteJourneyEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXCJEID);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
