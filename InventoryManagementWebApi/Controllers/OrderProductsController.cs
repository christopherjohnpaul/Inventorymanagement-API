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
    public class OrderProductsController : ControllerBase
    {
        private readonly IJWTAuth _jwtAuth;
        private readonly IConfiguration _configuration;
        private readonly IOrderProductsLogic<OrderProducts> _logic;

        public OrderProductsController(IJWTAuth jwtAuth, IConfiguration configuration, IOrderProductsLogic<OrderProducts> logic)
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

        [HttpGet("GetAllByOrderIdAsyn")]
        public async Task<IActionResult> GetAllByOrderIdAsyn(long id)
        {
            var retVal = await _logic.GetAllByOrderIdAsyn(id);
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


        [HttpGet("GenerateOrderProducts")]
        public async Task<IActionResult> GenerateOrderProducts(long orderId, long supplierId, long templateId)
        {
            var retVal = await _logic.GenerateOrderProducts(orderId, supplierId, templateId);
            return Ok(new
            {
                result = retVal
            });
        }

        // POST api
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] OrderProductsModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.CreateAsync((OrderProducts)entity);
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

        [HttpPost("UpsertByOrderTemplateId")]
        public async Task<IActionResult> UpsertByOrderTemplateId([FromBody] UpsertOrderProductModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpsertByOrderTemplateId(entity.OrderId, entity.TemplateId);
            return Ok(new
            {
                result = retVal
            });
        }

        // PUT api/
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] OrderProductsModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.UpdateAsync((OrderProducts)entity, entity.ID);
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
        [HttpPost("ChangeOrderTemplate")]
        public async Task<IActionResult> ChangeOrderTemplate(QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.ChangeOrderTemplate(entity.ID, entity.RefId, entity.CreatedBy);
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
        [HttpPost("SendMailToSupplier")]
        public async Task<IActionResult> SendMailToSupplier(QuickUpdateModel entity)
        {
            var retVal = await _logic.SendMailToSupplier(entity.ID, entity.RefId, entity.SecondRefId);
            return Ok(new
            {
                result = retVal
            });
        }
        [HttpPost("SendMailToSuppliersByOrderId")]
        public async Task<IActionResult> SendMailToSuppliersByOrderId(QuickUpdateModel entity)
        {
            entity.CreatedBy = ((UserInfo)Request.HttpContext.Items["User"]).ID;
            var retVal = await _logic.SendMailToSuppliersByOrderId(entity.ID, entity.CreatedBy);
            return Ok(new
            {
                result = retVal
            });
        }
    }
}
