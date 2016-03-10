using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.Domain.Punchout.Services;
using System.Linq;
using System;

namespace Coupa.PunchoutModule.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [RoutePrefix("api/punchout/coupa")]
    public class CoupaPunchoutController : ApiController
    {
        private readonly IPunchoutService _punchoutService;

        public CoupaPunchoutController(IPunchoutService punchoutService)
        {
            _punchoutService = punchoutService;
        }

        [HttpPost]
        [Route("setup")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> PunchoutSetup()
        {
            var setupRequest = await Request.Content.ReadAsStringAsync();
            var punchoutGateways = _punchoutService.GetAllPunchoutGateways();
            if (punchoutGateways != null && punchoutGateways.Any(x => x.Name.Equals("Coupa", StringComparison.InvariantCultureIgnoreCase)))
            {
                var coupaGateway = punchoutGateways.First(x => x.Name.Equals("Coupa", StringComparison.InvariantCultureIgnoreCase));
                var retVal = coupaGateway.PunchoutSetup(setupRequest);
                
                return Ok(retVal);
            }
            return NotFound();
        }

        /// <summary>
        /// Update shopping cart
        /// </summary>
        /// <param name="cart">Shopping cart model</param>
        [HttpGet]
        [Route("ordermessage")]
        [AllowAnonymous]
        public IHttpActionResult SendOrderMessage(string cartId)
        {
            var punchoutGateways = _punchoutService.GetAllPunchoutGateways();
            if (punchoutGateways != null && punchoutGateways.Any(x => x.Name.Equals("Coupa", StringComparison.InvariantCultureIgnoreCase)))
            {
                var coupaGateway = punchoutGateways.First(x => x.Name.Equals("Coupa", StringComparison.InvariantCultureIgnoreCase));
                var retVal = coupaGateway.PunchoutOrder(cartId);
                if (!string.IsNullOrEmpty(retVal))
                    return Ok(retVal);
            }

            return NotFound();
        }
    }
}