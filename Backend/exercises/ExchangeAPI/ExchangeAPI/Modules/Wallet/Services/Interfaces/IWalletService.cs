using ExchangeAPI.Modules.Wallet.Entities;

namespace ExchangeAPI.Modules.Wallet.Services.Interfaces;

public interface IWalletService
{
    public decimal GetBalance();
    public void AddFunds(decimal amount);
    public void ExchangeFunds<TargetCurrency>(decimal amount, string targetCurrencyName, 
        WalletService<TargetCurrency> targetWallet) where TargetCurrency : Currency;
}