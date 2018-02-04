using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TipsCalculator.Application.Dtos;
using TipsCalculator.Application.Interfaces;
using TipsCalculator.Domain.Interfaces;

namespace TipsCalculator.Application.Services
{
    public class TransactionsAppService : ITransactionsAppService
    {
        private readonly ITransactionsService transactionsService;

        public TransactionsAppService(ITransactionsService transactionsService)
        {
            this.transactionsService = transactionsService ?? throw new ArgumentNullException(nameof(transactionsService));
        }

        public async Task<IList<TransactionDto>> GetTransactionAdapter()
        {
            var result = await this.transactionsService.GetTransactions().ConfigureAwait(false);
            return Mapper.Map<List<TransactionDto>>(result);
        }
    }
}
