using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAPIProject.Cryptography;
using ModelAPIProject.Infra.Contracts;
using ModelAPIProject.Presentation.Configurations;
using ModelAPIProject.Presentation.Models.LoginModel;
using TokenAPI.Domain.Value_Objects;

namespace ModelAPIProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromServices] IUserRepository repository,
            [FromServices] TokenSettings tokenSettings, LoginModel model)
        {
            try
            {
                throw new NotImplementedException();

                /*
                if (await repository.GetCredentials(new Email(model.Email), 
                    SHA256Cryptography.Encrypt(model.Password)) == null)
                {
                    return StatusCode(401, "Access denied. Invalid email and/or password.");
                }

                return Ok(new
                {
                    Message = "Authentication completed successfully.",
                    AccessToken = tokenSettings.GenerateToken(model.Email)
                });
                */

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
