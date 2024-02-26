using System.Reflection;
using ExchangeAPI.Modules.Wallet.Entities;
using ExchangeAPI.Modules.Wallet.Services.Interfaces;

namespace ExchangeAPI.Modules.Wallet.Services;

public class WalletService<CurrentCurrency> : IWalletService where CurrentCurrency : Currency
{
    private readonly Dictionary<Type, decimal> _investments = new();

    public decimal GetBalance()
    {
        return !_investments.ContainsKey(typeof(CurrentCurrency)) ? 0 : _investments[typeof(CurrentCurrency)];
    }

    public void AddFunds(decimal amount)
    {
        this.ValidatedAmount(amount);
        
        var currencyType = typeof(CurrentCurrency);
        decimal newBalance = this.GetBalance() + amount;
        _investments[currencyType] = this.CurrencyAmountFormatter(newBalance);
    }

    public void ExchangeFunds<TargetCurrency>(decimal amount, string targetCurrencyName, 
        WalletService<TargetCurrency> targetWallet) 
        where TargetCurrency : Currency
    {
        this.ValidatedAmount(amount);
        decimal currentBalance = GetBalance();
        
        if (currentBalance < amount)
        {
            throw new BadHttpRequestException("Insufficient funds for the exchange!");
        }

        _investments[typeof(CurrentCurrency)] -= amount;
        
        var exchangeCurrencyField = typeof(TargetCurrency).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(field => field.FieldType == typeof(decimal));

        if (exchangeCurrencyField == null || exchangeCurrencyField.GetValue(null) == null)
        {
            throw new BadHttpRequestException("Invalid field type!");
        }

        var exchangeCurrencyRate = (decimal)exchangeCurrencyField.GetValue(null);
        
        this.ValidatedAmount(exchangeCurrencyRate);

        var amountTargetCurrency = this.CurrencyConverter<TargetCurrency>(amount, exchangeCurrencyRate);
        targetWallet.AddFunds(amountTargetCurrency);
    }
    
    private decimal CurrencyConverter<TargetCurrency>(decimal amount, decimal exchangeCurrencyRate) 
        where TargetCurrency : Currency
    {
        this.ValidatedAmount(amount);
        
        var currentCurrencyName = typeof(CurrentCurrency).
            GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance)!.
            GetValue(null)!.
            ToString();
        
        var targetCurrencyName = typeof(TargetCurrency).
            GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance)!.
            GetValue(null)!.
            ToString();
        
        if (currentCurrencyName == targetCurrencyName)
        {
            return CurrencyAmountFormatter(amount);
        }
    
        return CurrencyAmountFormatter(amount * exchangeCurrencyRate);
    }

    private void ValidatedAmount(decimal amount)
    {
        if (amount < 0)
        {
            throw new BadHttpRequestException("Invalid value!");
        }
    }

    private decimal CurrencyAmountFormatter(decimal amount)
    {
        this.ValidatedAmount(amount);
        return Math.Round(amount, 2);
    }
}