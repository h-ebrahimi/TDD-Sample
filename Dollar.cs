namespace TDD_Sample;

public class Dollar : Money
{
    public Dollar(float amount) : base(amount, Currency.USD) { }

    public override IMoney Divide(int divisor) => new Dollar(Amount / divisor);

    public override IMoney Times(int multipler) => new Dollar(Amount * multipler);
}
