using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class CreateApplicationCommand : IRequest<int>
    {
        public CreateApplicationDto Application { get; set; }
    }
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, int>
    {
        private readonly IApplicationRepository _repository;

        public CreateApplicationCommandHandler(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity = new CX_Application
            {
                CXAName = request.Application.CXAName,
                CreateAt = DateTime.UtcNow,
                CreateBy = request.Application.CreateBy
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.CXAID;
        }
    }
}