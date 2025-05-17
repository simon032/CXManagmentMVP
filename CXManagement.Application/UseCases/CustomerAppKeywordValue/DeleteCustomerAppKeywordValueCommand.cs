using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordValue
{
    public class DeleteCustomerAppKeywordValueCommand : IRequest<bool>
    {
        public int CXCAKVID { get; set; }
    }

    public class DeleteCustomerAppKeywordValueCommandHandler : IRequestHandler<DeleteCustomerAppKeywordValueCommand, bool>
    {
        private readonly IRepository<CX_Customer_AppKeyword_Value> _repository;

        public DeleteCustomerAppKeywordValueCommandHandler(IRepository<CX_Customer_AppKeyword_Value> repository)
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
