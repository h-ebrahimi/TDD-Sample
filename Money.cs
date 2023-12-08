namespace TDD_Sample;

public struct Money
{
    public Money(float amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public float Amount { get; }
    public string Currency { get; }

    public readonly Money Times(int multipler) => new Money(Amount * multipler, Currency);

    public readonly Money Divide(int divisor) => new Money(Amount / divisor, Currency);
}
