using CXManagement.Application.DTOs.ApplicationSystem;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationSystem
{
    public class GetApplicationSystemByIdQuery : IRequest<ApplicationSystemDto>
    {
        public int Id { get; set; }

        public GetApplicationSystemByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetApplicationSystemByIdQueryHandler : IRequestHandler<GetApplicationSystemByIdQuery, ApplicationSystemDto>
    {
        private readonly IApplicationSystemRepository _repository;

        public GetApplicationSystemByIdQueryHandler(IApplicationSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationSystemDto> Handle(GetApplicationSystemByIdQuery request, CancellationToken cancellationToken)
        {
            var applicationSystem = await _repository.GetByIdAsync(request.Id);
            if (applicationSystem == null)
                return null;

            return new ApplicationSystemDto
            {
                CXASID = applicationSystem.CXASID,
                CXASName = applicationSystem.CXASName,
                CreateAt = applicationSystem.CreateAt,
                ModifyAt = applicationSystem.ModifyAt,
                CreateBy = applicationSystem.CreateBy
            };
        }
    }
}
