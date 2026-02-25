using System.ComponentModel.DataAnnotations;
using ReatsTracker.Api.Enums;
using ReatsTracker.Api.Models;

namespace ReatsTracker.Api.DTOs;

public class VacancyCreateDto:IValidatableObject
{
    [Required] [MaxLength(100)] [MinLength(2)]
    public string Title { get; set; } = string.Empty;
    [Url] [MaxLength(2048)]
    public string? Link { get; set; }
    
    [Range(0, 1000000)]
    public int? SalaryStart { get; set; }
    [Range(0, 1000000)]
    public int? SalaryEnd { get; set; }
    
    [EnumDataType(typeof(ApplicationStatus))]
    public ApplicationStatus? Status { get; set; }
    
    public DateTime? AppliedAt { get; set; }
    public DateTime? RespondedAt { get; set; }
    
    [Range(1, int.MaxValue)]
    public int? CompanyId { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SalaryStart.HasValue && SalaryEnd.HasValue &&
            SalaryEnd < SalaryStart)
        {
            yield return new ValidationResult(
                "SalaryEnd must be greater than or equal to SalaryStart",
                new[] { nameof(SalaryEnd) });
        }
        
        if (AppliedAt.HasValue && RespondedAt.HasValue &&
            RespondedAt < AppliedAt)
        {
            yield return new ValidationResult(
                "RespondedAt cannot be earlier than AppliedAt",
                new[] { nameof(RespondedAt) });
        }
        
        if (AppliedAt.HasValue && AppliedAt > DateTime.UtcNow)
        {
            yield return new ValidationResult(
                "AppliedAt cannot be in the future",
                new[] { nameof(AppliedAt) });
        }
        
        if (RespondedAt.HasValue && RespondedAt > DateTime.UtcNow)
        {
            yield return new ValidationResult(
                "RespondedAt cannot be in the future",
                new[] { nameof(RespondedAt) });
        }
    }
}