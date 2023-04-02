using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public record BookDtoForUpdate : BookDtoForManipulation
    {
        [Required]
        public int Id { get; set; }
    }
}