using CXManagement.Application.DTOs.ApplicationSystem;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationSystem
{
    public class GetAllApplicationSystemQuery : IRequest<List<ApplicationSystemDto>>
    {
        public GetAllApplicationSystemQuery() { }
    }
    public class GetAllApplicationSystemQueryHandler : IRequestHandler<GetAllApplicationSystemQuery, List<ApplicationSystemDto>>
    {
        private readonly IApplicationSystemRepository _repository;

        public GetAllApplicationSystemQueryHandler(IApplicationSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ApplicationSystemDto>> Handle(GetAllApplicationSystemQuery request, CancellationToken cancellationToken)
        {
            var applicationSystems = await _repository.GetAllAsync();

            if (applicationSystems == null || !applicationSystems.Any())
                return new List<ApplicationSystemDto>();

            var dtoList = applicationSystems.Select(x => new ApplicationSystemDto
            {
                CXASID = x.CXASID,
                CXASName = x.CXASName,
                CreateAt = x.CreateAt,
                ModifyAt = x.ModifyAt,
                CreateBy = x.CreateBy
            }).ToList();

            return dtoList;
        }
    }
}
