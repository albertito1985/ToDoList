using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToDoList.Client.Pages.ToDoListComponents;

namespace ToDoList.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddSingleton<IToDoListState, ToDoListState>();

            await builder.Build().RunAsync();
        }
    }
}
