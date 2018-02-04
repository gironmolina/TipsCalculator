using System;
using System.Threading.Tasks;
using System.Web.Http;
using TipsCalculator.Application.Interfaces;

namespace TipsCalculator.API.Controllers
{
    public class RatesController : ApiController
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
                var response = await this.ratesAppService.GetRatesAdapter().ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }
    }
}