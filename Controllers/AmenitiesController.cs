using CRUDAPI.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly string _connectionString;
        public readonly IConfiguration _configration;
        public AmenitiesController(IConfiguration configuration)
        {
            _configration = configuration;
            _connectionString = _configration.GetConnectionString("DefaultConnection");
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Amenities";
            var amenities = await db.QueryAsync<Amenity>(sql);
            return Ok(amenities);
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Amenities WHERE AmenityID = @Id";
            var amenity = await db.QueryFirstOrDefaultAsync<Amenity>(sql, new { Id = id });

            if (amenity == null) return NotFound();
            return Ok(amenity);
        }

        // POST: api/Amenities
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = @"INSERT INTO Amenities (Name, Description, IsActive, CreatedBy, CreatedDate) 
                    VALUES (@Name, @Description, @IsActive, @CreatedBy, GETDATE());
                    SELECT CAST(SCOPE_IDENTITY() as int);";

            var id = await db.QuerySingleAsync<int>(sql, amenity);
            amenity.AmenityID = id;

            return CreatedAtAction(nameof(GetAmenity), new { id = amenity.AmenityID }, amenity);
        }

        // PUT: api/Amenities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.AmenityID) return BadRequest();

            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = @"UPDATE Amenities SET Name = @Name, Description = @Description, 
                    IsActive = @IsActive, ModifiedBy = @ModifiedBy, ModifiedDate = GETDATE() 
                    WHERE AmenityID = @AmenityID";

            var rowsAffected = await db.ExecuteAsync(sql, amenity);
            if (rowsAffected == 0) return NotFound();

            return NoContent();
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Amenities WHERE AmenityID = @Id";
            var rowsAffected = await db.ExecuteAsync(sql, new { Id = id });

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}
