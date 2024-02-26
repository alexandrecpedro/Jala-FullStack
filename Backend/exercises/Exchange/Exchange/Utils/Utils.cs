namespace Exchange.Utils;

static class Utils
{
    public static decimal CurrencyConverter(decimal amount, string currentCurrency, string targetCurrency)
    {
        if (currentCurrency == "Dollar" && targetCurrency == "Euro")
        {
            return Math.Round(amount / 1.08m, 2);
        }
        
        if (currentCurrency == "Euro" && targetCurrency == "Dollar")
        {
            return Math.Round(amount * 1.08m, 2);
        }

        return amount;
    }
}