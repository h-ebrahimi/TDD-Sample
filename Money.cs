namespace TDD_Sample;

public abstract class Money : IMoney
{
    private float amount;
    private Currency currency;
    private readonly RateProvider rateProvider;

    public Money(float amount, Currency currency)
    {
        this.amount = amount;
        this.currency = currency;
        rateProvider = new RateProvider();
    }

    public float Amount { set => amount = value; get => amount; }
    public Currency Currency { set => currency = value; get => currency; }


    public abstract IMoney Divide(int divisor);

    public abstract IMoney Times(int multipler);

    public virtual (IMoney money, bool canConvert) Convert(Currency currencyTo)
    {
        if (Currency.Equals(currencyTo))
            return (this, true);

        var (rate, isExist) = rateProvider.GetExchangeRate(currency, currencyTo);
        if (isExist)
        {
            var newMoney = Moneyfactory.GetMoney(currencyTo);
            newMoney.Amount = amount * rate;
            return (newMoney, isExist);
        }
        else
        {
            return (this, false);
        }
    }
}