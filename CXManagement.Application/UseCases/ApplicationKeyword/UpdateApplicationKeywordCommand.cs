﻿using CXManagement.Application.DTOs.CX_Application_Keyword;
using CXManagement.Application.Interfaces;
using MediatR;

namespace CXManagement.Application.UseCases.ApplicationKeyword
{
    public class UpdateApplicationKeywordCommand : IRequest<bool>
    {
        public UpdateApplicationKeywordDto ApplicationKeyword { get; set; }
    }

    public class UpdateApplicationKeywordCommandHandler : IRequestHandler<UpdateApplicationKeywordCommand, bool>
    {
        private readonly IApplicationKeywordRepository _repository;

        public UpdateApplicationKeywordCommandHandler(IApplicationKeywordRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateApplicationKeywordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ApplicationKeyword.CXAKID);
            if (entity == null) return false;

            entity.CXASID = request.ApplicationKeyword.CXASID;
            entity.CXKeywordID = request.ApplicationKeyword.CXKeywordID;
            entity.CXAKWeight = (float?)request.ApplicationKeyword.CXAKWeight;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
