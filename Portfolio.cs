namespace TDD_Sample;

public struct Portfolio
{
    private List<Money> moneys;
    private List<string> failures;

    public Portfolio()
    {
        moneys = new List<Money>();
        failures = new List<string>();
    }

    public readonly void Add(Money money) => moneys.Add(money);

    public readonly Money Evaluate(Bank bank, string currency)
    {
        float total = 0;
        foreach (Money money in moneys)
        {
            var (convertedMoney, canConvert) = bank.Convert(money, currency);
            if (canConvert)
                total += convertedMoney.Amount;
            else
                failures.Add($"{money.Currency}->{currency}");
        }

        if (failures.Any()) throw new Exception($"Missing exchange rate(s):[{string.Join(",", failures)}]");

        return new Money(total, currency);
    }
}