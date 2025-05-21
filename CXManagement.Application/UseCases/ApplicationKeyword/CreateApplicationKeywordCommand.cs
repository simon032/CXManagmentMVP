using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.Interfaces;
using CXManagmentMVP.Domain.Entities;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationKeyword
{
    public class CreateApplicationKeywordCommand : IRequest<int>
    {
        public CreateApplicationKeywordDto ApplicationKeyword { get; set; }
    }

    public class CreateApplicationKeywordCommandHandler : IRequestHandler<CreateApplicationKeywordCommand, int>
    {
        private readonly IApplicationKeywordRepository _repository;

        public CreateApplicationKeywordCommandHandler(IApplicationKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateApplicationKeywordCommand request, CancellationToken cancellationToken)
        {
            var entity = new CX_Application_Keyword
            {
                CXASID = request.ApplicationKeyword.CXASID,
                CXKeywordID = (int)request.ApplicationKeyword.CXKeywordID,
                CXAKWeight = (float?)request.ApplicationKeyword.CXAKWeight
            };
            try
            {
                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save CX_Application_Keyword: " + ex.Message);
                throw;
            }

            return entity.CXAKID;
        }
    }
}
