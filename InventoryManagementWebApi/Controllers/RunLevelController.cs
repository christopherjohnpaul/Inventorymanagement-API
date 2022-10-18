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
    public class RunLevelController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly IRunLevelLogic<RunLevel> _logic;
        public RunLevelController(IJWTAuth jwtAuth, IConfiguration configuration, IRunLevelLogic<RunLevel> logic)
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
        [HttpGet("FindAllByOrderIdAsync")]
        public async Task<IActionResult> FindAllByOrderIdAsync(long orderId)
        {
            var retVal = await _logic.FindAllByOrderIdAsync(orderId);
            return Ok(new
            {
                result = retVal
            });
        }

        // POST api
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] RunLevelModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.CreateAsync((RunLevel)entity);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("GenerateAndSendRunMail")]
        public async Task<IActionResult> GenerateAndSendRunMail([FromBody] QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.GenerateAndSendRunMail(entity.ID);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("GenerateRunAsync")]
        public async Task<IActionResult> GenerateRunAsync([FromBody] QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.GenerateRunAsync(entity.ID, entity.CreatedBy);
            return Ok(new
            {
                result = retVal
            });
        }

        // PUT api/
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] RunLevelModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpdateAsync((RunLevel)entity, entity.ID);
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
