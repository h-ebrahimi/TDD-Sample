namespace TDD_Sample;

public struct Bank
{
    private readonly Dictionary<string, float> exchangeRates;
    public Bank()
    {
        exchangeRates = new Dictionary<string, float>();
    }

    public void AddExchangeRate(string currencyFrom, string currencyTo, float rate)
    {
        var key = currencyFrom + "->" + currencyTo;
        exchangeRates.Add(key, rate);
    }

    public (Money convertedMoney, bool canConvert) Convert(Money money, string currencyTo)
    {
        if (money.Currency.Equals(currencyTo))
            return (money, true);

        var key = money.Currency + "->" + currencyTo;
        float rate = 0;
        var rateExist = exchangeRates.ContainsKey(key);

        if (rateExist)
            rate = exchangeRates[key];

        return (new Money(money.Amount * rate, currencyTo), rateExist);
    }

    //exchangeRates = new Dictionary<string, float>
    //    {
    //        { "EUR->USD", (float)1.2 },
    //        { "USD->EUR", (float)0.82 },
    //        { "USD->KRW", 1100 },
    //        { "KRW->USD", (float)0.00090 },
    //        { "EUR->KRW", 1344 },
    //        { "KRW->EUR", (float)0.00073 },
    //        { "USD->IRR", 550000 },
    //        { "IRR->USD" , (float)0.00000181}
    //    };


}


