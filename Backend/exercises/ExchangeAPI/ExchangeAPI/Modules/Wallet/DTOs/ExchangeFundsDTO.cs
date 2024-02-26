namespace ExchangeAPI.Modules.Wallet.DTOs;

public record ExchangeFundsDTO(decimal amount, string currentCurrencyName, string targetCurrencyName);