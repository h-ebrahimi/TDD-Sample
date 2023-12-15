namespace TDD_Sample;

public class SouthKoreanWon : Money
{
    public SouthKoreanWon(float amount) : base(amount, Currency.KRW)
    {
    }

    public override IMoney Divide(int divisor) => new SouthKoreanWon(Amount / divisor);

    public override IMoney Times(int multipler) => new SouthKoreanWon(Amount * multipler);
}