using InMemoryCaching.Data;
using InMemoryCaching.Models;
using InMemoryCaching.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCaching.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{
    private readonly ICacheService _cacheService;
    private readonly ApiDbContext _dbContext;
    public DriverController(ICacheService cacheService, ApiDbContext dbContext)
    {
        _cacheService = cacheService;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Driver>> Get()
    {
        var cacheDrivers = _cacheService.GetData<IEnumerable<Driver>>("drivers");
        if (cacheDrivers != null && cacheDrivers.Count() > 0)
            return cacheDrivers;

        var drivers = await _dbContext.Drivers.ToListAsync();
        var expiryTime = DateTimeOffset.Now.AddMinutes(2);
        _cacheService.SetData<IEnumerable<Driver>>("drivers", drivers, expiryTime);
        return drivers;
    }

    [HttpPost]
    public virtual async Task<ActionResult<Driver>> Post(Driver driver)
    {
        var create = await _dbContext.Drivers.AddAsync(driver);
        _dbContext.SaveChanges();
        return CreatedAtAction("Get", new { id = driver.Id }, create);
    }
}
