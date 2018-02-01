using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TipsCalculator.API.Controllers
{
    public class RatesController
    {
        private readonly IRatesAppService ratesAppService;

        public RatesController(IRatesAppService ratesAppService)
        {
            this.ratesAppService = ratesAppService ?? throw new ArgumentNullException(nameof(ratesAppService));
        }

        [HttpGet]
        [Route("api/v1/rates")]
        public async Task<IHttpActionResult> GetRates()
        {
            try
            {
                var response = await this.tipsAppService.GetTipsCalculatorAdapter().ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }
    
    }
}