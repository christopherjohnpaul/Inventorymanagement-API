using InterfaceLayer;
using InterfaceLayer.JWTAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using ModelLayer.UIModels;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace InventoryManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly IUserLogic<UserInfo> logicLayer;

        public UserController(IJWTAuth jwtAuth, IConfiguration configuration, IUserLogic<UserInfo> userLogic)
        {
            this._jwtAuth = jwtAuth;
            this._configuration = configuration;
            this.logicLayer = userLogic;
        }
        // [ValidateModel()]
        [AllowAnonymous]
        [HttpPost("LoginAync")]
        public async Task<IActionResult> LoginAync([FromBody] LoginModel details)
        {
            // if(ModelState.val(details))
            var retVal = await logicLayer.LoginAsync(details.Email, details.Password, false);
            return GenerateToken(retVal);
        }
        [AllowAnonymous]
        [HttpPost("GoogleLoginAync")]
        public async Task<IActionResult> GoogleLoginAync([FromBody] GoogleLoginModel details)
        {
            // if(ModelState.val(details))
            var retVal = await logicLayer.LoginAsync(details.Email, string.Empty, true);
            return GenerateToken(retVal);
        }

        private IActionResult GenerateToken(Result<UserInfo> retVal)
        {
            if (retVal.Success)
            {
                var token = _jwtAuth.GenerateToken(retVal.Data);
                if (token == null)
                    return Unauthorized();
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    result = retVal,
                    // userName = retVal.Data.ContactInfo.Email,
                    success = true
                });
            }
            else
            {
                return Ok(new
                {
                    result = retVal
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("Test")]
        // [Route("api/User/Test")]
        public async Task<IActionResult> Test()
        {
            //var retVal = await logicLayer.RegisterUserAsync((UserInfo)userCredential);
            return Ok(new
            {
                result = "This is a test data"
            });
        }

        [Authorize]
        [HttpPost("RegisterAsync")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserInfoModel userCredential)
        {
            userCredential.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await logicLayer.RegisterUserAsync((UserInfo)userCredential);
            return Ok(new
            {
                result = retVal
            });
        }
        [Authorize]
        [HttpGet("GetAllByContactTypeAsync")]
        public async Task<IActionResult> GetAllByContactTypeAsync(long contactTypeId)
        {
            var retVal = await logicLayer.GetAllByContactTypeAsync(contactTypeId);
            return Ok(new
            {
                result = retVal
            });
        }
        // DELETE api
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var retVal = await logicLayer.DeleteAsync(id);
            return Ok(new
            {
                result = retVal
            });
        }
    }
}
