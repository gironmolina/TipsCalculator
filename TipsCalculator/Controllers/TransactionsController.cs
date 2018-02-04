using System;
using System.Threading.Tasks;
using System.Web.Http;
using TipsCalculator.Application.Interfaces;

namespace TipsCalculator.API.Controllers
{
    public class TransactionsController : ApiController
    {
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
                return this.InternalServerError(e);
            }
        }
    }
}