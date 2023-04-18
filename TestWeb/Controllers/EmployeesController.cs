using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb.DbContexts;
using TestWeb.Dtos;
using TestWeb.Entities;

namespace TestWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _db;

    public EmployeesController(AppDbContext db) {
        _db = db;
    }

    [HttpGet]
    public async Task<IEnumerable<EmployeeRowDto>> List(string filter) {
        if (filter != null && filter != "" && filter != " ")
        {
            return await _db.Employees
               .Where(a => a.Name.Contains(filter,StringComparison.OrdinalIgnoreCase) 
               || a.Surname.Contains(filter, StringComparison.OrdinalIgnoreCase))
               .OrderBy(x => x.Name)
               .OrderBy(y => y.Surname)
               .Select(e => new EmployeeRowDto
               {
                   Id = e.Id,
                   NameSurname = e.Name + " " + e.Surname
               })
               .ToListAsync();
        }
        else 
        {
            return await _db.Employees
               .OrderBy(x => x.Name)
               .OrderBy(y => y.Surname)
               .Select(e => new EmployeeRowDto
               {
                   Id = e.Id,
                   NameSurname = e.Name + " " + e.Surname
               })
               .ToListAsync();
        }
    }

    [HttpPost]
    public async Task AddVacation(AddVacationDto dto) {
        var employee = await _db.Employees
            .SingleOrDefaultAsync();
        employee.Vacations.Add(new VacationEntity { Start = dto.Start, End = dto.End });
        await _db.SaveChangesAsync();
    }

    [HttpGet]
    public async Task<EmployeeVacationDto> GetVacationDays(int employeeId) {
        var employee = await _db.Employees
            .Include(x => x.Vacations)
            .SingleOrDefaultAsync(e => e.Id == employeeId);
        var result = employee.Vacations.Aggregate(TimeSpan.FromDays(0), (acc, curr) => acc += curr.End - curr.Start);
        return new EmployeeVacationDto {
            NameSurname = $"{employee.Name} {employee.Surname}",
            TotalVacationDays = 0
        };
    }
}
