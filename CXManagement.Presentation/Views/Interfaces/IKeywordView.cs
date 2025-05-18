using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Keyword;

namespace CXManagement.Presentation.Views.Interfaces
{
    public interface IKeywordView
    {
        void ShowKeyword(KeywordDto keyword);
        void ShowKeywords(IEnumerable<KeywordDto> keywords);
        void ShowError(string message);
        void ShowApplications(IEnumerable<ApplicationDto> applications);
    }
}
