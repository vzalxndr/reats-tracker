using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReatsTracker.Api.Data;
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
    public async Task<List<Company>> Get()
    {
        var companies = await _db.Companies.ToListAsync();
        return companies;
    }
}