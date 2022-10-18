using InterfaceLayer.Business;
using InterfaceLayer.JWTAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using ModelLayer.UIModels;
using System.Threading.Tasks;

namespace InventoryManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerTypeController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly ICustomerTypeLogic<CustomerType> _logic;

        public CustomerTypeController(IJWTAuth jwtAuth, IConfiguration configuration, ICustomerTypeLogic<CustomerType> logic)
        {
            this._jwtAuth = jwtAuth;
            this._configuration = configuration;
            this._logic = logic;
        }
        // GET: api
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var retVal = await _logic.FindAllAsync();
            return Ok(new
            {
                result = retVal
            });
        }

        // GET api
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var retVal = await _logic.FindAsync(id);
            return Ok(new
            {
                result = retVal
            });
        }

        // POST api
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] CustomerTypeModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.CreateAsync((CustomerType)entity);
            return Ok(new
            {
                result = retVal
            });
        }

        // PUT api/
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] CustomerTypeModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpdateAsync((CustomerType)entity, entity.ID);
            return Ok(new
            {
                result = retVal
            });
        }

        // DELETE api
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var retVal = await _logic.DeleteAsync(id);
            return Ok(new
            {
                result = retVal
            });
        }
    }
}
