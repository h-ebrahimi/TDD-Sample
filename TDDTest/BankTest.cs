namespace TDDTest;

public class BankTest
{
    [Fact]
    public void test_conversion()
    {
        // Arrange
        var bank = new Bank();
        bank.AddExchangeRate("EUR", "USD", (float)1.2);

        var tenEuros = new Money(10, "EUR");
        var twelveDollars = new Money(12, "USD");
        var thirteenDollars = new Money(12, "USD");

        // Act
        var convertedResult1 = bank.Convert(tenEuros, "USD");
        var convertedMoney1 = convertedResult1.convertedMoney;

        bank.AddExchangeRate("EUR", "USD", (float)1.3);
        var convertedResult2 = bank.Convert(tenEuros, "USD");
        var convertedMoney2 = convertedResult2.convertedMoney;

        // Assert
        Assert.True(twelveDollars.Currency == convertedMoney1.Currency);
        Assert.True(twelveDollars.Amount == convertedMoney1.Amount);

        Assert.True(thirteenDollars.Currency == convertedMoney2.Currency);
        Assert.True(thirteenDollars.Amount == convertedMoney2.Amount);
    }
}