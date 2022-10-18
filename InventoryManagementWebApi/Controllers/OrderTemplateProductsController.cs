using InterfaceLayer.Business;
using InterfaceLayer.JWTAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using ModelLayer.UIModels;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderTemplateProductsController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly IOrderTemplateProductsLogic<OrderTemplateProducts> _logic;

        public OrderTemplateProductsController(IJWTAuth jwtAuth, IConfiguration configuration, IOrderTemplateProductsLogic<OrderTemplateProducts> logic)
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

        [HttpGet("GetAllByTemplateIdAsyn")]
        public async Task<IActionResult> GetAllByTemplateIdAsyn(long id)
        {
            var retVal = await _logic.GetAllByTemplateIdAsyn(id);
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

        [HttpGet("GenerateOrderTemplateProducts")]
        public async Task<IActionResult> GenerateOrderTemplateProducts(long orderTemplateId, long supplierId)
        {
            var retVal = await _logic.GenerateOrderTemplateProducts(orderTemplateId, supplierId);
            return Ok(new
            {
                result = retVal
            });
        }

        // POST api
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] OrderTemplateProductsModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.CreateAsync((OrderTemplateProducts)entity);
            return Ok(new
            {
                result = retVal
            });
        }

        [HttpPost("AddProducts")]
        public async Task<IActionResult> AddProducts([FromBody] AddProductsModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.AddProducts((AddProducts)entity);
            return Ok(new
            {
                result = retVal
            });
        }

        [HttpPost("PostTemplateProducts")]
        public async Task<IActionResult> PostTemplateProducts([FromBody] OrderTempltProductsArrModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.PostTemplateProducts(entity.Data.Select(p => (OrderTemplateProducts)p).ToList());
            return Ok(new
            {
                result = retVal
            });
        }

        // PUT api/
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] OrderTemplateProductsModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpdateAsync((OrderTemplateProducts)entity, entity.ID);
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
        [HttpPost("SaveProductQuantity")]
        public async Task<IActionResult> SaveProductQuantity(QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.SaveProductQuantity(entity.ID, entity.Quantity, entity.CreatedBy);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("SaveSequenceNumber")]
        public async Task<IActionResult> SaveSequenceNumber(QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.SaveSequenceNumber(entity.ID, entity.RefId, entity.SequenceNumber, entity.CreatedBy);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("SaveSalesDay")]
        public async Task<IActionResult> SaveSalesDay(QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.SaveSalesDay(entity.ID, entity.RefId, entity.SalesDay, entity.CreatedBy);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("EnableDisable")]
        public async Task<IActionResult> EnableDisable(QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.EnableDisable(entity.ID, entity.RefId, entity.IsActive, entity.CreatedBy);
            return Ok(new
            {
                result = retVal
            });
        }
    }
}
