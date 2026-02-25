using System.ComponentModel.DataAnnotations;

namespace ReatsTracker.Api.DTOs;

public class CompanyCreateDto
{
    [Required] [MaxLength(50)] [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    [Url]
    public string? Website { get; set; }
}