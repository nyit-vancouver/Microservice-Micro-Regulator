using MicroArcSec.Client;
using MicroArcSec.Client.Data;
using MicroArcSec.Client.Services;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAntDesign();

builder.Services.AddGrpc();
builder.Services.AddSignalR();
builder.Services.AddSingleton<HubConnection>(_ => new HubConnectionBuilder()
    .WithUrl("http://localhost:44330/FileReceiverHub")
    .Build());

var app = builder.Build();

app.MapGrpcService<FileTransferService>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapGrpcService<FileTransferService>();

    endpoints.MapHub<FileReceiverHub>("/FileReceiverHub");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
