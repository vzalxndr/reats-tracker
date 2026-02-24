using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatsTracker.Api.Data;
using ReatsTracker.Api.DTOs;
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
}