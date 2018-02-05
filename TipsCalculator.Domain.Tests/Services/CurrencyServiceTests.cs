using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TipsCalculator.CrossCutting.Enums;
using TipsCalculator.CrossCutting.Exceptions;
using TipsCalculator.Domain.Interfaces;
using TipsCalculator.Entities;
using Unity;

namespace TipsCalculator.Domain.Tests.Services
{
    [TestFixture]
    public class CurrencyServiceTests
    {
        [Test]
        public void ConvertCurrency_InvalidCurrency_ShouldReturnRateConvertException()
        {
            // Arrange
            var currencyService = TestSetup.Container.Resolve<ICurrencyService>();
            var transactions = new List<TransactionEntity>()
            {
                new TransactionEntity {Sku = "Dummy", Amount = 7.63m, Currency = "ASD"}
            };

            // Act / Assert
            Assert.Catch<RateConvertException>(() => 
                currencyService.Convert(Currencies.Euro, transactions, GetRates()));
        }

        [Test]
        public void ConvertCurrency_ToSameCurrency_ShouldReturnSameCurrency()
        {
            // Arrange
            const string sku = "Dummy";
            const decimal amount = 7.63m;
            var currency = Currencies.Euro;

            var currencyService = TestSetup.Container.Resolve<ICurrencyService>();
            var transactions = new List<TransactionEntity>
            {
                new TransactionEntity {Sku = sku, Amount = amount, Currency = currency}
            };

            // Act
            var result = currencyService.Convert(Currencies.Euro, transactions, GetRates()).First();

            // Assert
            Assert.AreEqual(sku, result.Sku);
            Assert.AreEqual(amount, result.Amount);
            Assert.AreEqual(currency, result.Currency);
        }

        [Test]
        public void ConvertCurrency_ToSameAnotherCurrency_ShouldReturnExpectedResult()
        {
            // Arrange
            const string sku = "Dummy";
            const decimal amount = 7.63m;
            var currency = Currencies.USDollar;

            var currencyService = TestSetup.Container.Resolve<ICurrencyService>();
            var transactions = new List<TransactionEntity>
            {
                new TransactionEntity {Sku = sku, Amount = amount, Currency = currency}
            };

            // Act
            var result = currencyService.Convert(Currencies.Euro, transactions, GetRates()).First();

            // Assert
            Assert.AreEqual(sku, result.Sku);
            Assert.AreEqual(21.522704M, result.Amount);
            Assert.AreEqual("EUR", result.Currency);
        }

        private IList<RateEntity> GetRates()
        {
            return new List<RateEntity>
            {
                new RateEntity { From =  "EUR",  To = "AUD", Rate = 0.58m },
                new RateEntity { From =  "AUD",  To = "EUR", Rate = 1.72m },
                new RateEntity { From =  "EUR",  To = "CAD", Rate = 1.13m },
                new RateEntity { From =  "CAD",  To = "EUR", Rate = 0.88m },
                new RateEntity { From =  "AUD",  To = "USD", Rate = 0.61m },
                new RateEntity { From =  "USD",  To = "AUD", Rate = 1.64m }
            };
        }
    }
}
