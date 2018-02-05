using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using NUnit.Framework;
using TipsCalculator.Application.Dtos;
using TipsCalculator.API.Controllers;
using TipsCalculator.IntegrationTests.Extensions;

namespace TipsCalculator.IntegrationTests.Controllers
{
    [TestFixture]
    public class TransactionsControllerTests
    {
        [Test]
        public async Task GetTransactions_ShouldReturnExpectedResult()
        {
            // Arrange
            var controller = TestSetup.Container.GetController<TransactionsController>();

            // Act
            var response = await controller.GetTransactions().ConfigureAwait(false);
            var actualDto = (response as OkNegotiatedContentResult<IList<TransactionDto>>)?.Content;

            var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;
            var isValidType = actualDto is IList<TransactionDto>;

            // Assert
            Assert.IsTrue(isSuccessStatusCode);
            Assert.IsTrue(isValidType);
        }
    }
}
