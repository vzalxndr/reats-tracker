using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatsTracker.Api.Data;
using ReatsTracker.Api.DTOs;
using ReatsTracker.Api.Models;

namespace ReatsTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController:ControllerBase
{
    private readonly AppDbContext _db;
    
    public CompaniesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<CompanyReadDto>>> Get()
    {
        var companies = await _db.Companies
            .Select(c => new CompanyReadDto
            {
                Id = c.Id,
                Name = c.Name,
                Website = c.Website,
                VacanciesCount = c.Vacancies.Count
            })
            .ToListAsync();
        
        return Ok(companies);
    }
}