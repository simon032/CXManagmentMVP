using CXManagement.Application.DTOs.CX_Application;
using System.ComponentModel.DataAnnotations;

namespace CXManagement.Presentation.Models
{
    public class ApplicationModel
    {
        public int CXAID { get; set; }

        [Required(ErrorMessage = "Application Name is required")]
        [StringLength(100, ErrorMessage = "Application Name cannot exceed 100 characters")]
        public string CXAName { get; set; }

        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }

        public int? CreateBy { get; set; }

        // Map from DTO to Model
        public static ApplicationModel FromDto(ApplicationDto dto)
        {
            if (dto == null) return null;

            return new ApplicationModel
            {
                CXAID = dto.CXAID,
                CXAName = dto.CXAName,
                CreateAt = dto.CreateAt,
                ModifyAt = dto.ModifyAt,
                CreateBy = dto.CreateBy,
            };
        }

        // Map from Model to DTO
        public ApplicationDto ToDto()
        {
            return new ApplicationDto
            {
                CXAID = this.CXAID,
                CXAName = this.CXAName,
                CreateAt = this.CreateAt,
                ModifyAt = this.ModifyAt,
                CreateBy = this.CreateBy,
            };
        }
    }
}
