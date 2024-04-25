using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Jala.QueueFunc;

public static class QueueTriggerTest
{
    [FunctionName("QueueTriggerTest")]
    public static async Task RunAsync([QueueTrigger("testclass", Connection = "ConnectionString")] string myQueueItem, ILogger log)
    {
        
        log.LogInformation($"C# Queue trigger function works fine: {myQueueItem}");
        
    }
}