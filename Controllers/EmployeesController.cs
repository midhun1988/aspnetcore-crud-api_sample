using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using CRUDAPI.Model;
using Dapper;

namespace CRUDAPI.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        public readonly IConfiguration _configration;
        public EmployeesController(IConfiguration configuration)
        {
            _configration = configuration;

        }
        [HttpGet]
        [Route("GetEmployeeDetails_Individual_CivilID")]
        public ActionResult<List<Employee>> GetEmployeeDetails_Individual_CivilID(string civilid)
        {
           
            string sSql = "SELECT Id, Name, CivilIDNo, Position FROM [HotelDB].[dbo].[Employees] WHERE CivilIDNo = @CivilID";

            List<Employee> employeeslist = new List<Employee>();

            using (SqlConnection cn = new SqlConnection(_configration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, cn))
                {
                    // Always use parameters for safety!
                    cmd.Parameters.AddWithValue("@CivilID", civilid);

                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeslist.Add(new Employee
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                Position = Convert.ToString(reader["Position"]),
                                CivilIDNo = Convert.ToString(reader["CivilIDNo"])
                            });
                        }
                    }
                }
            }

            // 2. Return appropriate HTTP status codes instead of a custom Response class
            if (employeeslist.Count > 0)
            {
                return Ok(employeeslist); // Returns 200 OK with the JSON list
            }
            else
            {
                return NotFound("No records found"); // Returns 404 Not Found
            }
        }


        // **POST: api/employees**
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee newEmployee)
        {
            var sql = @"
                INSERT INTO Employees (Name, CivilIDNo,Position) 
                VALUES (@Name, @CivilIDNo,@Position);
                SELECT CAST(SCOPE_IDENTITY() as bigint);"; // Returns the newly created ID

            using (var connection = new SqlConnection(_configration.GetConnectionString("DefaultConnection")))
            {
                // Dapper makes executing the query and getting the new ID simple
                var id = await connection.ExecuteScalarAsync<int>(sql, newEmployee);
                newEmployee.Id = id;
            }
           
             return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
            //return NoContent();
        }
    
        [HttpPut("{Id}")]       
        public async Task<IActionResult> UpdateEmployee(int Id, Employee updatedEmployee)
        {
              if (Id != updatedEmployee.Id)
            {
                return BadRequest("Employee ID mismatch.");
            }

            var sql = @"
            UPDATE Employees
            SET Name = @Name, 
                CivilIDNo = @CivilIDNo, 
                Position = @Position
            WHERE Id = @Id;";

            using (var connection = new SqlConnection(_configration.GetConnectionString("DefaultConnection")))
            {
                // Execute the update query asynchronously
                var rowsAffected = await connection.ExecuteAsync(sql, updatedEmployee);

                if (rowsAffected == 0)
                {
                    // If no rows were affected, the employee with the given ID wasn't found
                    return NotFound($"Employee with ID {Id} not found.");
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id";

            using (var connection = new SqlConnection(_configration.GetConnectionString("DefaultConnection")))
            {                
                var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
                if (rowsAffected == 0)
                {                   
                    return NotFound($"Employee with ID {id} not found.");
                }
            }          
            return NoContent();
        }


        [HttpGet("{id}")] // This creates the route: GET /api/employees/{id}
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var sql = "SELECT Id, Name, CivilIDNo, Position FROM Employees WHERE Id = @Id";
           
            using (var connection = new SqlConnection(_configration.GetConnectionString("DefaultConnection")))
            {
                var employee = await connection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
        }
    }
       
    }

