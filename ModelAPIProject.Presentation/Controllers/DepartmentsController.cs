using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenAPI.Domain.Entities;
using TokenAPI.Infra.Contracts;
using TokenAPI.Infra.Repositories;
using TokenAPI.Presentation.Models.DepartmentModels;

namespace TokenAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromServices] IDepartmentRepository repository, CreateDepartmentModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

               
                if(await repository.GetByName(model.Name) == null)
                {
                    var department = new Department();

                    var result = repository.Create(department = new()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name.Trim().ToUpper()
                    });                  

                    return CreatedAtAction(nameof(GetById), new { department.Id }, department);
                }
                else
                {
                    return BadRequest("A Department with the entered name already exists in the database.");
                }
               
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll([FromServices] IDepartmentRepository repository)
        {
            try
            {
                var result = await repository.GetAll();
                if (result == null) return NotFound(new { Message = "No Departments found in the database." });


                return Ok(result);


            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetById([FromServices] IDepartmentRepository repository, Guid id)
        {
            var result = await repository.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> Delete([FromServices] IDepartmentRepository repository, Guid id)
        {
            var result = await repository.GetById(id);
            if(result != null)
            {
                await repository.Delete(id);
                return Ok("Department entry successfully deleted.");
            }
            else
            {
                return BadRequest("No matches found for the supplied Department ID.");
            }
        }
    }
}
