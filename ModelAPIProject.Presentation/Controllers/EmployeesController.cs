using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TokenAPI.Domain.Entities;
using TokenAPI.Domain.Value_Objects;
using TokenAPI.Infra.Contracts;
using TokenAPI.Presentation.Models.EmployeeModels;

namespace TokenAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromServices] IEmployeeRepository repository, CreateEmployeeModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

                if(await repository.GetByEmail(model.Email) != null)
                {
                    return BadRequest(new { Message = "The provided email is already in use." });
                }
                else
                {
                    var employee = new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name = new FullName(model.Name, model.MiddleName, model.Surname),
                        DateOfAdmission = model.DateOfAdmission,
                        DateOfBirth = model.DateOfBirth,
                        Email = new Email(model.Email),
                        DepartmentID = model.DepartmentID
                    };

                    await repository.Create(employee);
                    

                    return CreatedAtAction(nameof(GetById), new { employee.Id }, employee);
                }

                    
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete([FromServices] IEmployeeRepository repository, DeleteEmployeeModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

                if (repository.GetById(model.Id) == null) return BadRequest("The provided ID could not be found. Try again.");

                await repository.Delete(model.Id);
                return Ok("The employee was successfully deleted.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromServices] IEmployeeRepository repository, UpdateEmployeeModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

                var result = await repository.GetById(model.Id);
                if (result == null) return BadRequest("No employee found. Check the ID and try again.");
                
                await repository.Update(result);
                return Ok("Employee successfully updated.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll([FromServices] IEmployeeRepository repository)
        {
            try
            {
                var result = await repository.GetAll();
                if (result == null) return BadRequest("No employee found in the database.");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<Employee>> GetById([FromServices] IEmployeeRepository repository, Guid id)
        {
            try
            {
                var result = await repository.GetById(id);
                if (result == null) return BadRequest("No employee found with the provided ID.");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
