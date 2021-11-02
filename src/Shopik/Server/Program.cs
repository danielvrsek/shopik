using Entity;
using Facades;
using Microsoft.EntityFrameworkCore;
using VrsekDev.Blazor.BlazorCommunicationFoundation.Serializers.Json;
using VrsekDev.Blazor.BlazorCommunicationFoundation.Server.ApiExplorer;
using VrsekDev.Blazor.BlazorCommunicationFoundation.Server.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShopikDbContext>();

builder.Services.AddSwaggerGen();

builder.Services.AddBCFServer(builder =>
{
    builder.AddApiExplorer();
    builder.Contracts.AddFacades();
    builder.AddSerializer<JsonInvocationSerializer>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope())
{
    if (scope == null) throw new ArgumentNullException(nameof(scope));

    using var dbContext = scope.ServiceProvider.GetRequiredService<ShopikDbContext>();
    dbContext.Database.Migrate();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorCommunicationFoundation();
});

app.Run();
