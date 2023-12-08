namespace TDD_Sample;

public struct Portfolio
{
    private List<Money> moneys;
    private List<string> failures;
    private readonly Dictionary<string, float> exchangeRates;

    public Portfolio()
    {
        moneys = new List<Money>();
        failures = new List<string>();

        exchangeRates = new Dictionary<string, float>
        {
            { "EUR->USD", (float)1.2 },
            { "USD->EUR", (float)0.82 },
            { "USD->KRW", 1100 },
            { "KRW->USD", (float)0.00090 },
            { "EUR->KRW", 1344 },
            { "KRW->EUR", (float)0.00073 },
            { "USD->IRR", 550000 },
            { "IRR->USD" , (float)0.00000181}
        };
    }

    public readonly void Add(Money money) => moneys.Add(money);

    private readonly float Convert(Money money, string currency)
    {
        if (money.Currency.Equals(currency))
            return money.Amount;

        var key = money.Currency + "->" + currency;
        float rate = 0;
        var rateExist = exchangeRates.ContainsKey(key);

        if (rateExist)
            rate = exchangeRates[key];
        else
            failures.Add(key);

        return money.Amount * rate;
    }

    public readonly Money Evaluate(string currency)
    {
        float total = 0;
        foreach (Money money in moneys)
        {
            var amount = Convert(money, currency);
            total += amount;
        }

        if (failures.Any()) throw new Exception($"Missing exchange rate(s):[{string.Join(",", failures)}]");

        return new Money(total, currency);
    }
}