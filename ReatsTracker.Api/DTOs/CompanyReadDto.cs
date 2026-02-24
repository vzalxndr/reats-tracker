namespace ReatsTracker.Api.DTOs;

public class CompanyReadDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Website { get; set; }
    public int VacanciesCount { get; set; }
}