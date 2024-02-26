using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestAPIExample.Attributes;

namespace RestAPIExample.Controllers;

[ApiController]
[Route("[controller]/[action]")]
//[Produces("application/json", new []{"text/plain", "application/xml"})]
//[Produces("application/json")]
public class WeatherForecastController(IOptionsMonitor<WeatherConfig> options) : ControllerBase
{
    private WeatherForecast[] _summaries = new[]
    {
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 25, "Hot", 1),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 15, "Cold", 2),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 5, "Freezing", 3),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 35, "Scorching", 4),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 45, "Burning", 5),
    };
    
    private readonly WeatherConfig _config = options.CurrentValue;

    [HttpGet]
    //[ResponseCache(Duration = 60)] // Cache for 60 seconds
    [ProducesResponseType<WeatherForecast>(200)]
    public IActionResult GetWeatherForecast()
    {
        // Just for demo propose
        var summary = _config.Summary;
        
        return Ok(_summaries);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<WeatherForecastResource>(200)]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)] // Disable caching
    public IActionResult GetWeatherForecast(int id)
    {
        var forecast = _summaries.FirstOrDefault(s => s.id == id);

        if (forecast == null)
        {
            return NotFound();
        }

        var resource = new WeatherForecastResource
        {
            WeatherForecast = forecast,
            Links = new List<Link>
            {
                new Link { Href = Url.Action(nameof(GetWeatherForecast), new { id = forecast.id }), Rel = "self", Method = "GET" },
                new Link { Href = Url.Action(nameof(PutWeatherForecast), new { id = forecast.id }), Rel = "update", Method = "PUT" },
                new Link { Href = Url.Action(nameof(DeleteWeatherForecast), new { id = forecast.id }), Rel = "delete", Method = "DELETE" },
                new Link { Href = Url.Action(nameof(GetCode)), Rel = "code", Method = "GET" }
            }
        };

        return Ok(resource);
    }
    
    [HttpPatch("{id:int}/{summary}")]
    [NeedAutorization]
    public IActionResult PatchWeatherForecast(int id, string summary, [FromBody] PatchModel patch)
    {
        var forecast = _summaries.FirstOrDefault(s => s.Summary?.Equals(summary, StringComparison.OrdinalIgnoreCase) == true);

        if (forecast == null)
        {
            return NotFound();
        }

        //forecast.TemperatureC = 12;
        forecast = forecast with { TemperatureC = patch.TemperatureC };

        return NoContent();
    }
    
    /// <summary>
    /// Update a specific WeatherForecast by unique id
    /// </summary>
    /// <remarks>
    /// Example response:
    ///
    ///     {
    ///        "id": 1
    ///     }
    ///
    /// </remarks>
    /// <response code="203">WeatherForecast Updated</response>
    /// <response code="400">WeatherForecast not found</response>
    /// <response code="500">Oops! Can't updated your WeatherForecast right now</response>
    [HttpPut("{id:int}")]
    public IActionResult PutWeatherForecast([FromRoute]int id, [FromBody] PutModel putModel)
    {
        var forecast = _summaries.FirstOrDefault(f => f.id == id);

        if (forecast == null)
        {
            return NotFound();
        }

        var index = Array.IndexOf(_summaries, forecast);
        if (index != -1)
        {
            _summaries[index] = putModel.WeatherForecast;
        }

        return NoContent();
    }
    
    [HttpPost]
    // [SwaggerOperation(
    //     Summary = "Creates a new Weather Forecast",
    //     Description = "Creates a new Weather Forecast with the specified details",
    //     OperationId = "WeatherForecast.PostWeatherForecast",
    //     Tags = new[] { "WeatherForecastEndpoints" })]
    // [SwaggerResponse(201, "Weather Forecast created successfully", typeof(WeatherForecast), new []{ "application/json" })]
    // [SwaggerResponse(400, "Invalid input", null)]
    [ProducesResponseType(typeof(WeatherForecast), 201)]
    public IActionResult PostWeatherForecast([FromBody] PostModel postModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var newForecast = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), postModel.TemperatureC, postModel.Summary, _summaries.Length + 1);
        Array.Resize(ref _summaries, _summaries.Length + 1);
        _summaries[^1] = newForecast;

        return CreatedAtAction(nameof(GetWeatherForecast), new { id = newForecast.id }, newForecast);
    }
    
    
    [HttpHead]
    public IActionResult HeadWeatherForecast()
    {
        if (_summaries == null || _summaries.Length == 0)
        {
            return NotFound();
        }
    
        Response.Headers.Append("X-Total-Count", _summaries.Length.ToString());
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteWeatherForecast(int id)
    {
        var sumaryEnum = WeatherForecastSummary.Cold;
        switch (sumaryEnum)
        {
            case WeatherForecastSummary.Hot:
                return BadRequest();
            case WeatherForecastSummary.Cold:
                return NotFound();
        }
        return NoContent();
    }
    
    [HttpGet("code")]
    public ContentResult GetCode()
    {
        const string script = @"
                                  function calculateTemperatureF(temperatureC) {
                                      return 32 + (temperatureC / 0.5556);
                                  }
                              ";

        return Content(script, "application/javascript");
    }
}


public class PatchModel
{
    public int TemperatureC { get; set; }
}

public class PutModel(WeatherForecast weatherForecast)
{
    public WeatherForecast WeatherForecast { get; set; } = weatherForecast;
}

public class PostModel
{
    public required int TemperatureC { get; set; }
    public string? Summary { get; set; }
}

/// <summary>
/// test
/// </summary>
/// <param name="Date"></param>
/// <param name="TemperatureC"></param>
/// <param name="Summary"></param>
/// <param name="id"></param>
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary, int id)
{
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}

public enum WeatherForecastSummary
{
    Hot,
    Cold,
    Freezing,
    Scorching,
    Burning
}

public class Link
{
    public string? Href { get; set; }
    public string? Rel { get; set; }
    public string? Method { get; set; }
}

public struct WeatherForecastResource
{
    public WeatherForecast WeatherForecast { get; set; }
    public List<Link> Links { get; set; }
}



