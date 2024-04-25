using Azure.Storage.Queues;

namespace Jala.Queue.IO.Api;

public class MessageProcessor : BackgroundService
{
    private readonly QueueClient _queueClient;
    public MessageProcessor(QueueClient queueClient)
    {
        _queueClient = queueClient;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = await _queueClient.ReceiveMessageAsync();
            if (message.Value != null)
            {
                Console.WriteLine(message.Value.MessageText);
                await _queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt, stoppingToken);   
            }
            
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}