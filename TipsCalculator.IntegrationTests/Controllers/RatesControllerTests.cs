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
    public class RatesControllerTests
    {
        [Test]
        public async Task GetRates_ShouldReturnExpectedResult()
        {
            // Arrange
            var controller = TestSetup.Container.GetController<RatesController>();

            // Act
            var response = await controller.GetRates().ConfigureAwait(false);
            var actualDto = (response as OkNegotiatedContentResult<IList<RateDto>>)?.Content;
            var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;
            var isValidType = actualDto is IList<RateDto>;

            // Assert
            Assert.IsTrue(isSuccessStatusCode);
            Assert.IsTrue(isValidType);
            Assert.AreEqual(actualDto?.Count, 6);
        }
    }
}
