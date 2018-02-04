using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using log4net;
using TipsCalculator.Application.Dtos;
using TipsCalculator.Application.Interfaces;

namespace TipsCalculator.API.Controllers
{
    public class TipsCalculatorController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TipsCalculatorController));
        private readonly ITipsAppService tipsAppService;

        public TipsCalculatorController(ITipsAppService tipsAppService)
        {
            this.tipsAppService = tipsAppService ?? throw new ArgumentNullException(nameof(tipsAppService));
        }

        /// <summary>Get Tips Order.</summary>>
        /// <response code="200">Returns tips order.</response>
        /// <response code="500">Server found an unexpected error.</response>
        [HttpGet]
        [Route("api/v1/tips")]
        [ResponseType(typeof(TipsOrderDto))]
        public async Task<IHttpActionResult> GetTipsOrder([FromUri] string sku, [FromUri] string currency)
        {
            try
            {
                var response = await this.tipsAppService.GetTipsOrderAdapter(sku, currency).ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message, e);
                return this.InternalServerError(e);
            }
        }
    }
}