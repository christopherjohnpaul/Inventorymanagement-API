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
    public class StoreGroupStoreMappingController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly IStoreGroupStoreMappingLogic<StoreGroupStoreMapping> _logic;
        public StoreGroupStoreMappingController(IJWTAuth jwtAuth, IConfiguration configuration, IStoreGroupStoreMappingLogic<StoreGroupStoreMapping> logic)
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
        [HttpGet("FindAllByStoreGroupIdAsync")]
        public async Task<IActionResult> FindAllByStoreGroupIdAsync(long storeGroupeId)
        {
            var retVal = await _logic.FindAllByStoreGroupIdAsync(storeGroupeId);
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
        public async Task<IActionResult> Post([FromBody] StoreGroupStoreMappingModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.CreateAsync((StoreGroupStoreMapping)entity);
            return Ok(new
            {
                result = retVal
            });
        }

        // PUT api/
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] StoreGroupStoreMappingModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpdateAsync((StoreGroupStoreMapping)entity, entity.ID);
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

