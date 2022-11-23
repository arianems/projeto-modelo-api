using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAPIProject.Domain.Entities;
using ModelAPIProject.Infra.Contracts;
using ModelAPIProject.Presentation.Models.UserModels;
using TokenAPI.Domain.Entities;
using TokenAPI.Domain.Value_Objects;
using TokenAPI.Infra.Contracts;

namespace ModelAPIProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromServices] IUserRepository userRepository,
            [FromServices] IEmployeeRepository employeeRepository, CreateUserModel model)
        {
            try
            {
                var employee = await employeeRepository.GetById(model.EmployeeID);

                if (employee == null) return BadRequest("No employee found.");

                var user = await userRepository.GetByEmail(new Email(model.Email));

                if (user == null)
                {
                    var result = await userRepository.Create(new User
                    {
                        Id = Guid.NewGuid(),
                        Email = new Email(model.Email),
                        Password = model.Password,
                        EmployeeID = model.EmployeeID
                    });

                    return CreatedAtAction(nameof(GetById), new { result.Id }, result);
                }
                else
                {
                    return BadRequest("This email is already in use.");
                }
                

                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromServices] IUserRepository repository, Guid id)
        {
            try
            {
                if (repository.GetById == null) return BadRequest("User not found. Check the ID and try again.");

                await repository.Delete(id);

                return Ok("User successfully deleted.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromServices] IUserRepository repository, UpdateUserModel model)
        {
            var result = repository.GetByEmail(new Email(model.Email));

            if (result == null) return BadRequest("User not found. Check the ID and try again.");

            await repository.Update(new User
            {
                Id = model.Id,
                Email = new Email(model.Email),
                Password = model.Password
            });



            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById([FromServices] IUserRepository repository, Guid id)
        {
            try
            {
                var result = await repository.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
