using TDD_Sample;

namespace TDDTest;

public class PortfolioTest
{
    [Fact]
    public void portfolio_test_fact()
    {
        // Arrange
        var fiveDollars = new Money(5, "USD");
        var tenEuros = new Money(10, "EUR");
        var portfolio = new Portfolio();
        var expectedValue = new Money(17, "USD");
        var bank = new Bank();
        bank.AddExchangeRate("EUR", "USD", (float)1.2);

        // Act
        portfolio.Add(fiveDollars);
        portfolio.Add(tenEuros);
        var actualValue = portfolio.Evaluate(bank, "USD");

        // Assert         
        Assert.Equal(expectedValue.Amount, actualValue.Amount);
        Assert.Equal(expectedValue.Currency, actualValue.Currency);
    }


    [Theory]
    [InlineData(5, "USD", 10, "EUR", "USD", 17, "USD")]
    [InlineData(1, "USD", 1100, "KRW", "KRW", 2200, "KRW")]
    [InlineData(1, "USD", 550000, "IRR", "USD", 1.9955, "USD")]
    public void portfolio_test_inline_data(float money1Amount, string money1Currency,
                                       float money2Amount, string money2Currency,
                                       string evaluatedCurrency,
                                       float expectedAmount, string expectedCurrency)
    {
        // Arrange
        var money1 = new Money(money1Amount, money1Currency);
        var money2 = new Money(money2Amount, money2Currency);
        var portfolio = new Portfolio();
        var expectedValue = new Money(expectedAmount, expectedCurrency);
        var bank = new Bank();
        bank.AddExchangeRate("EUR", "USD", (float)1.2);
        bank.AddExchangeRate("USD", "KRW", 1100);
        bank.AddExchangeRate("IRR", "USD", (float)0.00000181);

        // Act
        portfolio.Add(money1);
        portfolio.Add(money2);
        var actualValue = portfolio.Evaluate(bank, evaluatedCurrency);

        // Assert         
        Assert.Equal(expectedValue.Amount, actualValue.Amount);
        Assert.Equal(expectedValue.Currency, actualValue.Currency);
    }

    [Fact]
    public void test_addition_with_multiple_missing_exchange_rates()
    {
        // Arrang
        var oneDollar = new Money(1, "USD");
        var oneEuro = new Money(1, "EUR");
        var oneWon = new Money(1, "KRW");
        var portfolio = new Portfolio();
        var expectedErrorMessage = "Missing exchange rate(s):[USD->Kalganid,EUR->Kalganid,KRW->Kalganid]";

        var bank = new Bank();
        bank.AddExchangeRate("EUR", "USD", (float)1.2);
        bank.AddExchangeRate("USD", "KRW", 1100);
        bank.AddExchangeRate("IRR", "USD", (float)0.00000181);

        // Act
        portfolio.Add(oneDollar);
        portfolio.Add(oneEuro);
        portfolio.Add(oneWon);
        var action = () => portfolio.Evaluate(bank, "Kalganid");

        // Assert
        var exception = Assert.ThrowsAny<Exception>(() => action());
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}