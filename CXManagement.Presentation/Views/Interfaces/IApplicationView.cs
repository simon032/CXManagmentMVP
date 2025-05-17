using CXManagement.Application.DTOs.CX_Application;

namespace CXManagement.Presentation.Views.Interfaces
{
    public interface IApplicationView
    {
        void ShowApplications(IEnumerable<ApplicationDto> applications);
        void ShowApplication(ApplicationDto application);
        void ShowError(string message);
    }
}
