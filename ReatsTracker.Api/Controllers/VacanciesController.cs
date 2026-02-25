using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatsTracker.Api.Data;
using ReatsTracker.Api.DTOs;
using ReatsTracker.Api.Enums;
using ReatsTracker.Api.Models;

namespace ReatsTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacanciesController:ControllerBase
{
    private readonly AppDbContext _db;

    public VacanciesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<VacancyReadDto>>> Get()
    {
        var vacancies = await _db.Vacancies
            .Select(v => new VacancyReadDto
            {
                Id = v.Id,
                Title = v.Title,
                Link = v.Link,
                SalaryStart = v.SalaryStart,
                SalaryEnd = v.SalaryEnd,
                Status = v.Status,
                CreatedAt = v.CreatedAt,
                AppliedAt = v.AppliedAt,
                RespondedAt = v.RespondedAt,
                CompanyName = v.Company.Name,
                CompanyId = v.CompanyId
            })
            .ToListAsync();
        
        return Ok(vacancies);
    }

    [HttpPost]
    public async Task<ActionResult<VacancyReadDto>> Post(VacancyCreateDto dto)
    {
        var vacancy = new Vacancy
        {
            Title = dto.Title,
            Link = dto.Link,
            SalaryStart = dto.SalaryStart,
            SalaryEnd = dto.SalaryEnd,
            Status = dto.Status,
            CreatedAt = DateTime.UtcNow,
            AppliedAt = dto.AppliedAt,
            RespondedAt = dto.RespondedAt,
            CompanyId = dto.CompanyId
        };
   
        await _db.Vacancies.AddAsync(vacancy);
        await _db.SaveChangesAsync();
        
        var companyName = await _db.Companies
            .Where(c => c.Id == vacancy.CompanyId)
            .Select(c => c.Name)
            .FirstOrDefaultAsync();

        var readDto = new VacancyReadDto
        {
            Id = vacancy.Id,
            Title = vacancy.Title,
            Link = vacancy.Link,
            SalaryStart = vacancy.SalaryStart,
            SalaryEnd = vacancy.SalaryEnd,
            Status = vacancy.Status,
            CreatedAt = vacancy.CreatedAt,
            AppliedAt = vacancy.AppliedAt,
            RespondedAt = vacancy.RespondedAt,
            CompanyId = vacancy.CompanyId,
            CompanyName = companyName
        };

        return Ok(readDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] ApplicationStatus newStatus)
    {
        var vacancy = await _db.Vacancies.FindAsync(id);
        if (vacancy == null)
        {
            return NotFound();
        }

        if (newStatus != ApplicationStatus.Sent)
        {
            vacancy.RespondedAt = DateTime.UtcNow;
        }

        vacancy.Status = newStatus;
        
        await  _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vacancy = await _db.Vacancies.FindAsync(id);
        if (vacancy == null)
        {
            return NotFound();
        }
        
        _db.Remove(vacancy);
        await _db.SaveChangesAsync();
        return NoContent();
    }

}