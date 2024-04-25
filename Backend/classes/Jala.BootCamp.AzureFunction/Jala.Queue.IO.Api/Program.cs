using Azure.Storage.Queues;
using Jala.Queue.IO.Api;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton(sp =>
// {
//     var queueName = builder.Configuration["AzureStorage:QueueName"];
//     var connectionString = builder.Configuration["AzureStorage:ConnectionString"];
//     return new QueueClient(connectionString, queueName);
// });

builder.Services.AddAzureClients(builderFactory =>
{
    builderFactory.AddClient<QueueClient, QueueClientOptions>((_, _, _) =>
    {
        var queueName = builder.Configuration["AzureStorage:QueueName"];
        var connectionString = builder.Configuration["AzureStorage:ConnectionString"];
        return new QueueClient(connectionString, queueName);
    });
});

builder.Services.AddHostedService<MessageProcessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();