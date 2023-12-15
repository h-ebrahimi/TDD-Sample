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
        var key = GetKey(currencyFrom, currencyTo);
        if (exchangeRates.ContainsKey(key))
            exchangeRates[key] = rate;
        else
            exchangeRates.Add(key, rate);
    }

    public (Money convertedMoney, bool canConvert) Convert(Money money, string currencyTo)
    {
        if (money.Currency.Equals(currencyTo))
            return (money, true);

        var key = GetKey(money.Currency, currencyTo);
        float rate = 0;
        var rateExist = exchangeRates.ContainsKey(key);

        if (rateExist)
            rate = exchangeRates[key];

        return (new Money(money.Amount * rate, currencyTo), rateExist);
    }

    private static string GetKey(string currencyFrom, string currencyTo)
    {
        return currencyFrom + "->" + currencyTo;
    }
}