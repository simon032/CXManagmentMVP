using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordScore
{
    public class DeleteCustomerAppKeywordScoreCommand : IRequest<bool>
    {
        public int CXCAKScoreID { get; set; }
    }

    public class DeleteCustomerAppKeywordScoreCommandHandler : IRequestHandler<DeleteCustomerAppKeywordScoreCommand, bool>
    {
        private readonly ICustomerAppKeywordScoreRepository _repository;

        public DeleteCustomerAppKeywordScoreCommandHandler(ICustomerAppKeywordScoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCustomerAppKeywordScoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXCAKScoreID);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
