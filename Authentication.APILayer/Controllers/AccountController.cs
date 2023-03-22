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

        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            this.jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost]
        public ActionResult<AuthenticationResponseModel> Login(AuthenticationRequestModel model) { 
        var response = jwtTokenHandler.GenerateJwtToken(model);
            if(response== null)
            {
                return Unauthorized();
            }
            return response;
        
        }
    }
}
