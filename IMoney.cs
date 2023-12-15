namespace TDD_Sample;

public interface IMoney
{
    public float Amount { get; set; }
    public Currency Currency { get; set; }

    public IMoney Times(int multipler);
    public IMoney Divide(int divisor);
    public (IMoney money, bool canConvert) Convert(Currency currencyTo);
}