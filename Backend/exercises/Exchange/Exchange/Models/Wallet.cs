namespace Exchange.Classes;

public class Wallet<TCurrency> where TCurrency : Currency
{
    private decimal balance;

    public Wallet(decimal funds = 0)
    {
        balance = funds;
    }

    public void AddFunds(decimal funds)
    {
        balance += funds;
        Console.WriteLine($"Added {funds} {typeof(TCurrency).Name}");
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public void ExchangeFunds<TargetWallet>(decimal amount, Wallet<TargetWallet> targetWallet) where TargetWallet : Currency
    {
        if (balance < amount)
        {
            Console.WriteLine("Insufficient funds for the exchange!");
            return;
        }

        balance -= amount;
        targetWallet.AddFunds(Utils.Utils.CurrencyConverter(amount, typeof(TCurrency).Name, typeof(TargetWallet).Name));
    }
}