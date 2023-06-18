using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public record BookDtoForInsertion : BookDtoForManipulation
{
    [Required(ErrorMessage = "CategoryId is required.")]
    public int CategoryId { get; init; }
}