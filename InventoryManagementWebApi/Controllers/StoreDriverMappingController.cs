using InterfaceLayer.JWTAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using System.Threading.Tasks;

namespace InventoryManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreDriverMappingController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly IStoreDriverMappingLogic<StoreDriverMapping> _logic;
        public StoreDriverMappingController(IJWTAuth jwtAuth, IConfiguration configuration, IStoreDriverMappingLogic<StoreDriverMapping> logic)
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
        public async Task<IActionResult> Post([FromBody] ModelLayer.UIModels.StoreGroupStoreMapping entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.CreateAsync((StoreDriverMapping)entity);
            return Ok(new
            {
                result = retVal
            });
        }

        // PUT api/
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] ModelLayer.UIModels.StoreGroupStoreMapping entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpdateAsync((StoreDriverMapping)entity, entity.ID);
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
