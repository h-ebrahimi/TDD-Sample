namespace TDD_Sample;

public class Euro : Money
{
    public Euro(float amount) : base(amount, Currency.EUR) { }

    public override IMoney Divide(int divisor) => new Euro(Amount / divisor);

    public override IMoney Times(int multipler) => new Euro(Amount * multipler);
}
