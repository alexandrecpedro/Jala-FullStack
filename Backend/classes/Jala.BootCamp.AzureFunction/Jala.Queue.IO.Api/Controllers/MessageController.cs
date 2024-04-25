using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;

namespace Jala.Queue.IO.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MessageController : ControllerBase
{
    private readonly QueueClient _queueClient;

    public MessageController(QueueClient queueClient)
    {
        _queueClient = queueClient;
    }
    
    [HttpGet]
    public async Task<IActionResult> Create(string message)
    {
        for (int i = 0; i < 10; i++)
        {
            await _queueClient.SendMessageAsync(message);
        }
       
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        for (int i = 0; i < 10; i++)
        {
           var message = await _queueClient.ReceiveMessageAsync();
           Console.WriteLine(message.Value.MessageText);
           await _queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt);
        }
       
        return Ok();
    }
}