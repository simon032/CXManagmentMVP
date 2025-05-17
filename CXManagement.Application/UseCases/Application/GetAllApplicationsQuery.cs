using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.Application
{
    public class GetAllApplicationsQuery : IRequest<IEnumerable<ApplicationDto>>
    {
    }

    public class GetAllApplicationsQueryHandler : IRequestHandler<GetAllApplicationsQuery, IEnumerable<ApplicationDto>>
    {
        private readonly IRepository<CX_Application> _repository;

        public GetAllApplicationsQueryHandler(IRepository<CX_Application> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ApplicationDto>> Handle(GetAllApplicationsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(entity => new ApplicationDto
            {
                CXAID = entity.CXAID,
                CXAName = entity.CXAName,
                CreateAt = entity.CreateAt,
                ModifyAt = entity.ModifyAt,
                CreateBy = entity.CreateBy
            });
        }
    }
}
