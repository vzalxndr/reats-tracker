using ReatsTracker.Api.Enums;
using ReatsTracker.Api.Models;

namespace ReatsTracker.Api.DTOs;

public class VacancyCreateDto
{
    public string? Title { get; set; }
    public string? Link { get; set; }
    
    public int? SalaryStart { get; set; }
    public int? SalaryEnd { get; set; }
    
    public ApplicationStatus? Status { get; set; }
    
    public DateTime? AppliedAt { get; set; }
    public DateTime? RespondedAt { get; set; }
    
    public int? CompanyId { get; set; }
}