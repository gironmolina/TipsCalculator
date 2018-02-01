﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using TipsCalculator.Application.Interfaces;

namespace TipsCalculator.API.Controllers
{
    public class TipsCalculatorController : ApiController
    {
        private readonly ITipsAppService tipsAppService;

        public TipsCalculatorController(ITipsAppService tipsAppService)
        {
            this.tipsAppService = tipsAppService ?? throw new ArgumentNullException(nameof(tipsAppService));
        }

        [HttpGet]
        [Route("api/v1/tips")]
        public async Task<IHttpActionResult> GetTipsOrder([FromUri] string sku, [FromUri] string currency)
        {
            try
            {
                var response = await this.tipsAppService.GetTipsOrderAdapter(sku, currency).ConfigureAwait(false);
                return this.Ok(response);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }
    }
}