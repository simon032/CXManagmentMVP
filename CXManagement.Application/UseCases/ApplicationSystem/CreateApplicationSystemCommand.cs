using CXManagement.Application.DTOs.ApplicationSystem;
using CXManagmentMVP.Domain.Interfaces;


using MediatR;

namespace CXManagement.Application.UseCases.ApplicationSystem
{
    public class CreateApplicationSystemCommand : IRequest<int>
    {
        public CreateApplicationSystemDto CreateDto { get; set; }

        public CreateApplicationSystemCommand(CreateApplicationSystemDto createDto)
        {
            CreateDto = createDto;
        }
    }
    public class CreateApplicationSystemCommandHandler : IRequestHandler<CreateApplicationSystemCommand, int>
    {
        private readonly IApplicationSystemRepository _repository;

        public CreateApplicationSystemCommandHandler(IApplicationSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateApplicationSystemCommand request, CancellationToken cancellationToken)
        {
            var applicationSystem = new CXManagmentMVP.Domain.Entities.ApplicationSystem
            {
                CXASName = request.CreateDto.CXASName,
                CreateBy = request.CreateDto.CreateBy,
                CreateAt = DateTime.UtcNow
            };

            await _repository.AddAsync(applicationSystem);
            return applicationSystem.CXASID;
        }
    }

}
