namespace TDD_Sample;

// Singlton
public class Moneyfactory
{
    public static IMoney GetMoney(Currency currency)
    {
        switch (currency)
        {
            case Currency.USD:
                return new Dollar(0);
            case Currency.EUR:
                return new Euro(0);
            case Currency.IRR:
                return new IRRial(0);
            case Currency.KRW:
                return new SouthKoreanWon(0);
            default:
                throw new Exception("Can't find of money currency !!!!");
        }
    }
}