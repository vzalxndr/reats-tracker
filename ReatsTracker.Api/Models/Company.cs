namespace ReatsTracker.Api.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Website { get; set; }
    
    public virtual ICollection<Vacancy> Vacancies { get; set; }
    
    public Company()
    {
        Vacancies = new List<Vacancy>();
    }
}