using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerAppKeywordValue
{
    public class CreateCustomerAppKeywordValueCommand : IRequest<int>
    {
        public CreateCustomerAppKeywordValueDto CustomerAppKeywordValue { get; set; }
    }

    public class CreateCustomerAppKeywordValueCommandHandler : IRequestHandler<CreateCustomerAppKeywordValueCommand, int>
    {
        private readonly ICustomerAppKeywordValueRepository _repository;

        public CreateCustomerAppKeywordValueCommandHandler(ICustomerAppKeywordValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCustomerAppKeywordValueCommand request, CancellationToken cancellationToken)
        {
            var entity = new CX_Customer_AppKeyword_Value
            {
                CXCustomerID = request.CustomerAppKeywordValue.CXCustomerID,
                CXASKID = request.CustomerAppKeywordValue.CXASKID,
                CXCAKVValueString = request.CustomerAppKeywordValue.CXCAKVValueString,
                CXCAKVAssignedDate = request.CustomerAppKeywordValue.CXCAKVAssignedDate,
                CreateAt = request.CustomerAppKeywordValue.CreateAt,
                CreateBy = request.CustomerAppKeywordValue.CreateBy
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.CXCAKVID;
        }
    }
}
