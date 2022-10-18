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
    public class OrderController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly IOrderLogic<Order> _logic;

        public OrderController(IJWTAuth jwtAuth, IConfiguration configuration, IOrderLogic<Order> logic)
        {
            this._jwtAuth = jwtAuth;
            this._configuration = configuration;
            this._logic = logic;
        }
        // GET: api
        [HttpGet("GetNewId")]
        public async Task<IActionResult> GetNewId()
        {
            Order order = new Order() { CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID };
            var retVal = await _logic.CreateAsync(order);
            return Ok(new
            {
                result = retVal
            });
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
        public async Task<IActionResult> Post([FromBody] OrderModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.CreateAsync((Order)entity);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("GenerateOrder")]
        public async Task<IActionResult> GenerateOrder()
        {
            long createdBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.GenerateOrder(createdBy);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("FinalizeOrder")]
        public async Task<IActionResult> FinalizeOrder([FromBody] QuickUpdateModel entity)
        {
            long createdBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.FinalizeOrder(entity.ID, createdBy);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("RunGenerated")]
        public async Task<IActionResult> RunGenerated([FromBody] QuickUpdateModel entity)
        {
            long createdBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.RunGenerated(entity.ID, createdBy);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("MailSendToSupplier")]
        public async Task<IActionResult> MailSendToSupplier([FromBody] QuickUpdateModel entity)
        {
            long createdBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.MailSendToSupplier(entity.ID, createdBy);
            return Ok(new
            {
                result = retVal
            });
        }

        // PUT api/
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] OrderModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpdateAsync((Order)entity, entity.ID);
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
