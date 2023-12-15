namespace TDDTest;

public class PortfolioTest
{
    [Fact]
    public void portfolio_test_fact()
    {
        // Arrange
        var fiveDollars = new Dollar(5);
        var tenEuros = new Euro(10);
        var portfolio = new Portfolio();
        var expectedValue = new Dollar(17);
        var rateProvider = new RateProvider();
        rateProvider.AddExchangeRate(Currency.EUR, Currency.USD, (float)1.2);

        // Act
        portfolio.Add(fiveDollars);
        portfolio.Add(tenEuros);
        var actualValue = portfolio.Evaluate(Currency.USD);

        // Assert         
        Assert.Equal(expectedValue.Amount, actualValue.Amount);
        Assert.Equal(expectedValue.Currency, actualValue.Currency);
    }


    [Theory]
    [InlineData(5, Currency.USD, 10, Currency.EUR, Currency.USD, 17, Currency.USD)]
    [InlineData(1, Currency.USD, 1100, Currency.KRW, Currency.KRW, 2200, Currency.KRW)]
    [InlineData(1, Currency.USD, 550000, Currency.IRR, Currency.USD, 1.9955, Currency.USD)]
    public void portfolio_test_inline_data(float money1Amount, Currency money1Currency,
                                       float money2Amount, Currency money2Currency,
                                       Currency evaluatedCurrency,
                                       float expectedAmount, Currency expectedCurrency)
    {
        // Arrange
        var money1 = Moneyfactory.GetMoney(money1Currency);
        money1.Amount = money1Amount;

        var money2 = Moneyfactory.GetMoney(money2Currency);
        money2.Amount = money2Amount;

        var portfolio = new Portfolio();
        var expectedValue = Moneyfactory.GetMoney(expectedCurrency);
        expectedValue.Amount = expectedAmount;

        var rateProvider = new RateProvider();
        rateProvider.AddExchangeRate(Currency.EUR, Currency.USD, (float)1.2);
        rateProvider.AddExchangeRate(Currency.USD, Currency.KRW, 1100);
        rateProvider.AddExchangeRate(Currency.IRR, Currency.USD, (float)0.00000181);

        // Act
        portfolio.Add(money1);
        portfolio.Add(money2);
        var actualValue = portfolio.Evaluate(evaluatedCurrency);

        // Assert         
        Assert.Equal(expectedValue.Amount, actualValue.Amount);
        Assert.Equal(expectedValue.Currency, actualValue.Currency);
    }

    [Fact]
    public void test_addition_with_multiple_missing_exchange_rates()
    {
        // Arrang
        var oneDollar = Moneyfactory.GetMoney(Currency.USD);
        var oneEuro = Moneyfactory.GetMoney(Currency.EUR);
        var oneWon = Moneyfactory.GetMoney(Currency.KRW);
        var portfolio = new Portfolio();
        var expectedErrorMessage = "Missing exchange rate(s):[USD->Kalganid,EUR->Kalganid,KRW->Kalganid]";

        var rateProvider = new RateProvider();
        rateProvider.AddExchangeRate(Currency.EUR, Currency.USD, (float)1.2);
        rateProvider.AddExchangeRate(Currency.USD, Currency.KRW, 1100);
        rateProvider.AddExchangeRate(Currency.IRR, Currency.USD, (float)0.00000181);

        // Act
        portfolio.Add(oneDollar);
        portfolio.Add(oneEuro);
        portfolio.Add(oneWon);
        var action = () => portfolio.Evaluate(Currency.Kalganid);

        // Assert
        var exception = Assert.ThrowsAny<Exception>(() => action());
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}