namespace TDD_Sample;

public readonly struct RateProvider
{
    private static Dictionary<string, float> exchangeRates;

    public RateProvider()
    {
        exchangeRates = new Dictionary<string, float>();
    }

    public void AddExchangeRate(Currency currencyFrom, Currency currencyTo, float rate)
    {
        var key = GetKey(currencyFrom, currencyTo);
        exchangeRates.Add(key, rate);
    }

    public (float rate, bool isExist) GetExchangeRate(Currency currencyFrom, Currency currencyTo)
    {
        var key = GetKey(currencyFrom, currencyTo);
        if (exchangeRates.TryGetValue(key, out var rate))
            return (rate, true);
        else
            return (0, false);
    }

    private static string GetKey(Currency currencyFrom, Currency currencyTo)
    {
        return currencyFrom + "->" + currencyTo;
    }
}