namespace TDD_Sample;

public class IRRial : Money
{
    public IRRial(float amount) : base(amount, Currency.IRR) { }

    public override IMoney Divide(int divisor) => new IRRial(Amount / divisor);

    public override IMoney Times(int multipler) => new IRRial(Amount * multipler);
}