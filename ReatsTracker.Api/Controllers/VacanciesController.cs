using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatsTracker.Api.Data;
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
    public async Task<List<Vacancy>> Get()
    {
        var vacancies = await _db.Vacancies.ToListAsync();
        return vacancies;
    }
}