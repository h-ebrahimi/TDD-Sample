using TDD_Sample;
namespace TDDTest;

public class MoneyTest
{
    [Fact]
    public void times_test_fact()
    {
        // Arrange
        var fiver = new Money(amount: 5, currency: "USD");
        var expectedResult = new Money(amount: 10, currency: "USD");

        // Act
        var actualResult = fiver.Times(2);

        // Assert
        Assert.Equal(expectedResult.Amount, actualResult.Amount);
        Assert.Equal(expectedResult.Currency, actualResult.Currency);
    }

    [Theory]
    [InlineData(5, "USD", 2, 10, "USD")]
    [InlineData(10, "IRR", 2, 20, "IRR")]
    public void times_test_inline_data(float amount, string currency, int times, float expectedAmount, string expectedCurrency)
    {
        // Arrange
        var money = new Money(amount: amount, currency: currency);
        var expectedResult = new Money(amount: expectedAmount, currency: expectedCurrency);

        // Act
        var actualResult = money.Times(times);

        // Assert
        Assert.Equal(expectedResult.Amount, actualResult.Amount);
        Assert.Equal(expectedResult.Currency, actualResult.Currency);
    }
}
