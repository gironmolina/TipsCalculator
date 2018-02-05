using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TipsCalculator.API.Controllers;
using TipsCalculator.IntegrationTests.Extensions;

namespace TipsCalculator.IntegrationTests.Controllers
{
    [TestFixture]
    public class TipsCalculatorControllerTests
    {
        [Test]
        public async Task GetTipsOrder_ShouldReturnExpectedResult()
        {
            // Arrange
            var controller = TestSetup.Container.GetController<TipsCalculatorController>();

            // Act
            var response = await controller.GetTipsOrder("P1409", "EUR").ConfigureAwait(false);
            var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

            // Assert
            Assert.IsTrue(isSuccessStatusCode);
        }
    }
}
