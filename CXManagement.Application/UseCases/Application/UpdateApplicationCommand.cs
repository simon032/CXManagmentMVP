using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class UpdateApplicationCommand : IRequest<bool>
    {
        public UpdateApplicationDto Application { get; set; }
    }
    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, bool>
    {
        private readonly IRepository<CX_Application> _repository;

        public UpdateApplicationCommandHandler(IRepository<CX_Application> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Application.CXAID);
            if (entity == null) return false;

            entity.CXAName = request.Application.CXAName;
            entity.ModifyAt = request.Application.ModifyAt ?? DateTime.UtcNow;
            entity.CreateBy = request.Application.ModifyBy;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}