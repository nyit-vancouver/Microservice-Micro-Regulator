using Grpc.Net.Client;
using MicroArcSec.Client;
using MicroArcSec.Client.Data;
using MicroArcSec.Client.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.SignalR.Client;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAntDesign();

builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
});

AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

builder.Services.AddSignalR();
builder.Services.AddSingleton<HubConnection>(_ => new HubConnectionBuilder()
    .WithUrl("http://microarcsecportal.azurewebsites.net:443/FileReceiverHub")
    .Build());


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

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
