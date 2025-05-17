using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class GetApplicationByIdQuery : IRequest<ApplicationDto>
    {
        public int CXAID { get; set; }
    }

    public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, ApplicationDto>
    {
        private readonly IRepository<CX_Application> _repository;

        public GetApplicationByIdQueryHandler(IRepository<CX_Application> repository)
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
