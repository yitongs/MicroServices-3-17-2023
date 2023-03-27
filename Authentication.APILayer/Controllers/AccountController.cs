using System.Reflection.Metadata.Ecma335;
using Authentication.APILayer.Data;
using Authentication.APILayer.Repository;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler jwtTokenHandler;
        private readonly IAccountRepositoryAsync accountRepositoryAsync;

        public AccountController(JwtTokenHandler jwtTokenHandler, IAccountRepositoryAsync accountRepositoryAsync)
        {
            this.jwtTokenHandler = jwtTokenHandler;
            this.accountRepositoryAsync = accountRepositoryAsync;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResponseModel>> Login(SignInModel model) { 
            var result = await accountRepositoryAsync.LoginAsync(model);
            if (result.Succeeded)
            {
                AuthenticationRequestModel arModel = new AuthenticationRequestModel() {
                
                Username = model.Email,
                Password= model.Password
                };
                var response = jwtTokenHandler.GenerateJwtToken(arModel);

                if (response == null)
                {
                    return Unauthorized();
                }
                return response;
            }
            return Unauthorized("Invalid Username and password");
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        { 
       var result = await accountRepositoryAsync.SignUpAsync(model);
            if (result.Succeeded)
                return Ok(result.Succeeded);
            return BadRequest(result.Errors);
        }
        

    }
}
