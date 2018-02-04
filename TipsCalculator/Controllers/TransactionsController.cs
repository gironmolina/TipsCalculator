using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using log4net;
using TipsCalculator.Application.Dtos;
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

        /// <summary>Get Transactions.</summary>>
        /// <response code="200">Returns Transactions.</response>
        /// <response code="500">Server found an unexpected error.</response>
        [HttpGet]
        [Route("api/v1/transactions")]
        [ResponseType(typeof(IList<TransactionDto>))]
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