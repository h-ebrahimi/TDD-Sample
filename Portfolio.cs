namespace TDD_Sample;

public struct Portfolio
{
    private List<IMoney> moneys;
    private List<string> failures;

    public Portfolio()
    {
        moneys = new List<IMoney>();
        failures = new List<string>();
    }

    public readonly void Add(IMoney money) => moneys.Add(money);

    public readonly IMoney Evaluate(Currency currency)
    {
        IMoney? evaluatedMoney = null;
        foreach (IMoney money in moneys)
        {
            var (convertedMoney, canConvert) = money.Convert(currency);
            if (!canConvert)
            {
                failures.Add($"{money.Currency}->{currency}");
                continue;
            }
            switch (evaluatedMoney)
            {
                case null:
                    evaluatedMoney = convertedMoney;
                    break;
                default:
                    evaluatedMoney.Amount += convertedMoney.Amount;
                    break;
            }
        }

        if (failures.Any()) throw new Exception($"Missing exchange rate(s):[{string.Join(",", failures)}]");

        return evaluatedMoney!;
    }
}