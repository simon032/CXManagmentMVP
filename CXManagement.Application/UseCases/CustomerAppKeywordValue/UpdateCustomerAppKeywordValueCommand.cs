using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordValue
{
    public class UpdateCustomerAppKeywordValueCommand : IRequest<bool>
    {
        public UpdateCustomerAppKeywordValueDto CustomerAppKeywordValue { get; set; }
    }

    public class UpdateCustomerAppKeywordValueCommandHandler : IRequestHandler<UpdateCustomerAppKeywordValueCommand, bool>
    {
        private readonly ICustomerAppKeywordValueRepository _repository;

        public UpdateCustomerAppKeywordValueCommandHandler(ICustomerAppKeywordValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCustomerAppKeywordValueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CustomerAppKeywordValue.CXCAKVID);
            if (entity == null) return false;

            entity.CXCustomerID = request.CustomerAppKeywordValue.CXCustomerID;
            entity.CXASKID = request.CustomerAppKeywordValue.CXASKID;
            entity.CXCAKVValueString = request.CustomerAppKeywordValue.CXCAKVValueString;
            entity.CXCAKVAssignedDate = request.CustomerAppKeywordValue.CXCAKVAssignedDate;
            entity.ModifyAt = request.CustomerAppKeywordValue.ModifyAt;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
