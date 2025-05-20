using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordValue
{
    public class DeleteCustomerAppKeywordValueCommand : IRequest<bool>
    {
        public int CXCAKVID { get; set; }
    }

    public class DeleteCustomerAppKeywordValueCommandHandler : IRequestHandler<DeleteCustomerAppKeywordValueCommand, bool>
    {
        private readonly ICustomerAppKeywordValueRepository _repository;

        public DeleteCustomerAppKeywordValueCommandHandler(ICustomerAppKeywordValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCustomerAppKeywordValueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXCAKVID);
            if (entity == null) return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
