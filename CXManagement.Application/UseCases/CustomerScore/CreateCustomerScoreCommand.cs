using CXManagement.Application.DTOs.CustomerScore;
using CXManagmentMVP.Domain.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.CustomerScore
{
    public class CreateCustomerScoreCommand : IRequest<int>
    {
        public CreateCustomerScoreDto CreateDto { get; set; }

        public CreateCustomerScoreCommand(CreateCustomerScoreDto createDto)
        {
            CreateDto = createDto;
        }
    }
    public class CreateCustomerScoreCommandHandler : IRequestHandler<CreateCustomerScoreCommand, int>
    {
        private readonly ICustomerScoreRepository _repository;

        public CreateCustomerScoreCommandHandler(ICustomerScoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCustomerScoreCommand request, CancellationToken cancellationToken)
        {
            var customerScore = new CXManagmentMVP.Domain.Entities.CustomerScore
            {
                CXCustomerID = request.CreateDto.CXCustomerID,
                CXKeywordID = request.CreateDto.CXKeywordID,
                CXCustomerScoreCalculatedScore = request.CreateDto.CXCustomerScoreCalculatedScore,
                CreateBy = request.CreateDto.CreateBy,
                CreateAt = DateTime.UtcNow
            };

            await _repository.AddAsync(customerScore);
            return customerScore.CXCustomerScoreID;
        }
    }

}
