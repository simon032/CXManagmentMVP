using CXManagement.Application.DTOs.ApplicationSystem;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationSystem
{
    public class UpdateApplicationSystemCommand : IRequest<bool>
    {
        public UpdateApplicationSystemDto UpdateDto { get; set; }

        public UpdateApplicationSystemCommand(UpdateApplicationSystemDto updateDto)
        {
            UpdateDto = updateDto;
        }
    }
    public class UpdateApplicationSystemCommandHandler : IRequestHandler<UpdateApplicationSystemCommand, bool>
    {
        private readonly IApplicationSystemRepository _repository;

        public UpdateApplicationSystemCommandHandler(IApplicationSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateApplicationSystemCommand request, CancellationToken cancellationToken)
        {
            var applicationSystem = await _repository.GetByIdAsync(request.UpdateDto.CXASID);
            if (applicationSystem == null)
                return false;

            applicationSystem.CXASName = request.UpdateDto.CXASName;
            applicationSystem.ModifyAt = DateTime.UtcNow;
            applicationSystem.CreateBy = request.UpdateDto.CreateBy;

            await _repository.UpdateAsync(applicationSystem);
            return true;
        }
    }
}
