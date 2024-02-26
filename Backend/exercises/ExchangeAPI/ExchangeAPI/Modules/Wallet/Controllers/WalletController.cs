using ExchangeAPI.Modules.Wallet.DTOs;
using ExchangeAPI.Modules.Wallet.Entities;
using ExchangeAPI.Modules.Wallet.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeAPI.Modules.Wallet.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class WalletController : ControllerBase
{
    private readonly WalletService<Dollar> _dollarWallet = new();
    private readonly WalletService<Euro> _euroWallet = new();
    
    [HttpGet]
    [ResponseCache(Duration = 60)] // Cache for 60 seconds
    [ProducesResponseType<BalancesDTO>(200)]
    public IActionResult GetManyBalances()
    {
        try
        {
            decimal dollarWalletBalance = this._dollarWallet.GetBalance();
            decimal euroWalletBalance = this._dollarWallet.GetBalance();

            var balances = new BalancesDTO(dollarWalletBalance, euroWalletBalance);

            return Ok(balances);
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
    
    [HttpGet("{currencyname}")]
    [ResponseCache(Duration = 60)] // Cache for 60 seconds
    [ProducesResponseType<decimal>(200)]
    public IActionResult GetBalance([FromRoute] string currencyname)
    {
        try
        {
            decimal walletBalance;
            string currencyName = currencyname.Substring(0, 1).ToUpper() 
                                    + currencyname.Substring(1).ToLower();
            
            switch (currencyName)
            {
                case (nameof(Dollar)):
                    walletBalance = this._dollarWallet.GetBalance();
                    break;
                case nameof(Euro):
                    walletBalance = this._dollarWallet.GetBalance();
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {currencyName}", 
                        nameof(currencyName));
            }
            
            return Ok(walletBalance);
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
    
    [HttpPost]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    [ProducesResponseType(201)]
    public IActionResult AddFunds([FromBody] AddFundsDTO addFundsDTO)
    {
        try
        {
            var (amount, currencyName) = addFundsDTO;
            if (amount < 0)
            {
                throw new InvalidDataException("Invalid data!");
            }

            string currencySymbol = "";
            string nameOfCurrency = currencyName.Substring(0, 1).ToUpper() 
                                    + currencyName.Substring(1).ToLower();
            
            switch (nameOfCurrency)
            {
                case nameof(Dollar):
                    this._dollarWallet.AddFunds(amount);
                    currencySymbol = typeof(Dollar).GetField("_symbol").GetValue(null).ToString();
                    break;
                case nameof(Euro):
                    this._euroWallet.AddFunds(amount);
                    currencySymbol = typeof(Euro).GetField("_symbol").GetValue(null).ToString();
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {currencyName}", 
                        nameof(currencyName));
            }

            var amountToAdd = Math.Round(amount, 2);
            return CreatedAtAction(nameof(AddFunds), $"Added {currencySymbol} {amountToAdd}");
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }

    [HttpPost]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    [ProducesResponseType(201)]
    public IActionResult ExchangeFunds([FromBody] ExchangeFundsDTO exchangeFundsDTO)
    {
        try
        {
            var (amount, currentCurrencyName, targetCurrencyName) = exchangeFundsDTO;
            
            if (amount < 0)
            {
                throw new InvalidDataException("Invalid data!");
            }
            
            currentCurrencyName = currentCurrencyName.Substring(0, 1).ToUpper() 
                                  + currentCurrencyName.Substring(1).ToLower();
            
            targetCurrencyName = targetCurrencyName.Substring(0, 1).ToUpper() 
                                 + targetCurrencyName.Substring(1).ToLower();

            var message = "";
            switch (currentCurrencyName)
            {
                case nameof(Dollar):
                    var dollarSymbol = typeof(Dollar).GetField("_symbol").ToString();
                    switch (targetCurrencyName)
                    {
                        case nameof(Dollar):
                            break;
                        case nameof(Euro):
                            this._dollarWallet.ExchangeFunds<Euro>(amount, targetCurrencyName, this._euroWallet);
                            message = $"{dollarSymbol} {Math.Round(amount, 2)} exchanged to {targetCurrencyName}";
                            break;
                        default:
                            throw new ArgumentException($"Unsupported currency: {targetCurrencyName}", 
                                nameof(targetCurrencyName));
                    }
                    break;
                case nameof(Euro):
                    var euroSymbol = typeof(Euro).GetField("_symbol").ToString();
                    switch (targetCurrencyName)
                    {
                        case nameof(Dollar):
                            this._euroWallet.ExchangeFunds<Dollar>(amount, targetCurrencyName, this._dollarWallet);
                            message = $"{euroSymbol} {Math.Round(amount, 2)} exchanged to {targetCurrencyName}";
                            break;
                        case nameof(Euro):
                            break;
                        default:
                            throw new ArgumentException($"Unsupported currency: {targetCurrencyName}", 
                                nameof(targetCurrencyName));
                    }
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {currentCurrencyName}", 
                        nameof(currentCurrencyName));
            }
            
            return CreatedAtAction(nameof(ExchangeFunds), message);
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
}