using ReatsTracker.Api.Enums;

namespace ReatsTracker.Api.Models;

public class Vacancy
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    
    public int? SalaryStart { get; set; }
    public int? SalaryEnd { get; set; }
    
    public ApplicationStatus? Status { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? AppliedAt { get; set; }
    public DateTime? RespondedAt { get; set; }
    
    public int? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public Vacancy()
    {
    }
}