﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
using TipsCalculator.Application.Interfaces;

namespace TipsCalculator.API.Controllers
{
    public class TransactionsController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TransactionsController));
        private readonly ITransactionsAppService transactionAppService;

        public TransactionsController(ITransactionsAppService transactionAppService)
        {
            this.transactionAppService = transactionAppService ?? throw new ArgumentNullException(nameof(transactionAppService));
        }

        [HttpGet]
        [Route("api/v1/transactions")]
        public async Task<IHttpActionResult> GetTransactions()
        {
            try
            {
                var response = await this.transactionAppService.GetTransactionAdapter().ConfigureAwait(false);
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