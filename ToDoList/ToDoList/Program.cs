using Microsoft.EntityFrameworkCore;
using ToDoList.Client.Pages;
using ToDoList.Components;
using ToDoList.Infrastructure.Data;
using ToDoList.Application.Interfaces;
using ToDoList.Infrastructure.Repositories;
using ToDoList.Extensions;
using ToDoList.Client.Pages.ToDoListLocalComponents;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddSingleton<IToDoListState, ToDoListState>();

            builder.Services.AddDbContext<ToDoListContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoListContext") ?? throw new InvalidOperationException("Connection string 'ToDoListContext' not found.")));

            builder.Services.ConfigureServiceLayerServices();
            builder.Services.ConfigureRepositoryLayerServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
