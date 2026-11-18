using CRUDAPI.Model;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace CRUDAPI.Controllers
{
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CountriesController : ControllerBase
{
    private readonly string _connectionString;

    public CountriesController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        // Using TOP 1000 as requested
        var sql = "SELECT TOP (1000) Id, Name, CountryCode FROM Countries";
        var countries = await db.QueryAsync<Country>(sql);
        return Ok(countries);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Country>> GetCountry(int id)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        var sql = "SELECT Id, Name, CountryCode FROM Countries WHERE Id = @Id";
        var country = await db.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });

        if (country == null) return NotFound();
        return Ok(country);
    }

    // POST: api/Countries
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(Country country)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        var sql = @"INSERT INTO Countries (Name, CountryCode) 
                    VALUES (@Name, @CountryCode);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

        var id = await db.QuerySingleAsync<int>(sql, country);
        country.Id = id;

        return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
    }

    // PUT: api/Countries/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, Country country)
    {
        if (id != country.Id) return BadRequest();

        using IDbConnection db = new SqlConnection(_connectionString);
        var sql = "UPDATE Countries SET Name = @Name, CountryCode = @CountryCode WHERE Id = @Id";

        var rowsAffected = await db.ExecuteAsync(sql, country);
        if (rowsAffected == 0) return NotFound();

        return NoContent();
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        var sql = "DELETE FROM Countries WHERE Id = @Id";
        var rowsAffected = await db.ExecuteAsync(sql, new { Id = id });

        if (rowsAffected == 0) return NotFound();
        return NoContent();
    }
}
}