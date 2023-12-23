using Microsoft.Azure.Cosmos;
using Temp.Services;
using toDoTasks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ITaskService>(options =>
{
    string url = builder.Configuration.GetSection("CosmosDb").GetValue<string>("Uri");
    string primaryKey = builder.Configuration.GetSection("CosmosDb").GetValue<string>("Key");
    string dbName = builder.Configuration.GetSection("CosmosDb").GetValue<string>("DatabaseName");
    string containerName = builder.Configuration.GetSection("CosmosDb").GetValue<string>("ContainerName");

    var cosmosClient = new CosmosClient(url, primaryKey);

    return new TaskService(cosmosClient, dbName, containerName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
