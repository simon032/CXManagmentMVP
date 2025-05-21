using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class GetApplicationByIdQuery : IRequest<ApplicationDto>
    {
        public int CXAID { get; set; }
    }

    public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, ApplicationDto>
    {
        private readonly IApplicationRepository _repository;

        public GetApplicationByIdQueryHandler(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationDto> Handle(GetApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CXAID);
            if (entity == null) return null;

            return new ApplicationDto
            {
                CXAID = entity.CXAID,
                CXAName = entity.CXAName,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            };
        }
    }
}
