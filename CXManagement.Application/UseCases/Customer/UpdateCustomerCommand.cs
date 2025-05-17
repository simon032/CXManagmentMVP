using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public UpdateCustomerDto Customer { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IRepository<CX_Customer> _repository;

        public UpdateCustomerCommandHandler(IRepository<CX_Customer> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Customer.CXCustomerID);
            if (entity == null) return false;

            entity.CXCustomerFullName = request.Customer.CXCustomerFullName;
            entity.CXCustomerEmail = request.Customer.CXCustomerEmail;
            entity.CXCustomerPhone = request.Customer.CXCustomerPhone;
            entity.ModifyAt = request.Customer.ModifyAt ?? DateTime.UtcNow;
            entity.CreateBy = request.Customer.ModifyBy;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}