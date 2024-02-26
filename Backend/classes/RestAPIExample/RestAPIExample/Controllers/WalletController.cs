using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace RestAPIExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WalletController : ControllerBase
{
    [HttpPost]
    public IActionResult Get(Currency currency)
    {
        var currencyType = currency.CurrencyType.ToString();
        return Ok(currencyType);
    }
}


public record Currency(CurrencyType CurrencyType, decimal Amount);
//Can also provide this config globally in Program.cs
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CurrencyType
{
    Dollar,
    Euro,
    Yen
}