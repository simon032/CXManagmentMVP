using CXManagement.Application.DTOs.Customer;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Customer
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public UpdateCustomerDto UpdateDto { get; set; }

        public UpdateCustomerCommand(UpdateCustomerDto updateDto)
        {
            UpdateDto = updateDto;
        }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.UpdateDto.CXCustomerID);

            if (customer == null) return false;

            customer.CXCustomerFullName = request.UpdateDto.CXCustomerFullName;
            customer.CXCustomerEmail = request.UpdateDto.CXCustomerEmail;
            customer.CXCustomerPhone = request.UpdateDto.CXCustomerPhone;
            customer.CXCustomerExternalCustomerId = request.UpdateDto.CXCustomerExternalCustomerId;
            customer.ModifyAt = DateTime.UtcNow;
            customer.CreateBy = request.UpdateDto.CreateBy;

            var success = await _repository.UpdateAsync(customer);
            return success;
        }
    }
}