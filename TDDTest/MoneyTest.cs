namespace TDDTest;

public class MoneyTest
{
    [Fact]
    public void times_test_fact()
    {
        // Arrange
        var fiver = new Dollar(amount: 5);
        var expectedResult = new Dollar(amount: 10);

        // Act
        var actualResult = fiver.Times(2);

        // Assert
        Assert.Equal(expectedResult.Amount, actualResult.Amount);
        Assert.Equal(expectedResult.Currency, actualResult.Currency);
    }

    [Theory]
    [InlineData(5, Currency.USD, 2, 10, Currency.USD)]
    [InlineData(10, Currency.IRR, 2, 20, Currency.IRR)]
    public void times_test_inline_data(float amount, Currency currency, int times, float expectedAmount, Currency expectedCurrency)
    {
        // Arrange
        var money = Moneyfactory.GetMoney(currency: currency);
        money.Amount = amount;
        var expectedResult = Moneyfactory.GetMoney(expectedCurrency);
        expectedResult.Amount = expectedAmount;

        // Act
        var actualResult = money.Times(times);

        // Assert
        Assert.Equal(expectedResult.Amount, actualResult.Amount);
        Assert.Equal(expectedResult.Currency, actualResult.Currency);
    }
}
