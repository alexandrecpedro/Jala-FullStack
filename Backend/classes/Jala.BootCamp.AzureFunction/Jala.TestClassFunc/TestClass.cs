using System;
using System.IO;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Jala.TestClassFunc;

public static class TestClass
{
    /// <summary>
    ///  A azure function to serve as the backend for a Alexa Skill.
    /// More about alexa skills on https://developer.amazon.com/en-US/alexa
    /// </summary>
    /// <param name="req"></param>
    /// <param name="log"></param>
    /// <returns></returns>
    [FunctionName("TestClass")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
    {
       
        string json = await req.ReadAsStringAsync();
        var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(json);

        var requestType = skillRequest.GetRequestType();

        SkillResponse response = null;

        if (requestType == typeof(LaunchRequest))
        {
            response = ResponseBuilder.Tell("Ben-vindo ao test app!");
            
            response.Response.ShouldEndSession = false;
        }

        else if (requestType == typeof(IntentRequest))
        {
            var intentRequest = skillRequest.Request as IntentRequest;

            if (intentRequest.Intent.Name == "say_the_time")
            {
                response = ResponseBuilder.Tell($"{DateTime.Now}");
                response.Response.ShouldEndSession = false;
            }

        }

        return new OkObjectResult(response);
        
    }
}