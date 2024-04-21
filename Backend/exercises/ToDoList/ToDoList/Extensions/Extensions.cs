using ToDoList.Models;
using ToDoList.Repositories;
using ToDoList.Repositories.Interfaces;
using ToDoList.UseCases.Interfaces;
using ToDoList.UseCases;

namespace ToDoList.Extensions;

public static class Extensions
{
    public static IServiceCollection AddToDoListServices(this IServiceCollection services) =>
        services
            .AddScoped<ICreateUseCase<ToDoItem>, CreateUseCase>()
            .AddScoped<IDeleteUseCase<ToDoItem>, DeleteUseCase>()
            .AddScoped<IGetAllUseCase<ToDoItem>, GetAllUseCase>()
            .AddScoped<IGetByIdUseCase<ToDoItem>, GetByIdUseCase>()
            .AddScoped<IUpdateUseCase<ToDoItem>, UpdateUseCase>()
            .AddScoped<IToDoRepository, ToDoRepository>();
}