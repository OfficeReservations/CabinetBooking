using CabinetBooking;
using CabinetBooking.Api;
// using CabinetBooking.Api;
using CabinetBooking.Application;
using CabinetBooking.Domain.Data;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

const int GrpcPort = 28710;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CabinetBookingDbContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("CabinetBookingServiceConnection")
    )
);

builder.Services.AddHealthChecks();

builder.Services.AddScoped<CabinetBookingService.CabinetBookingServiceBase, CabinetBookingGrpcService>();

// Добавление gRPC сервисов
builder.Services.AddGrpc();

builder.Services.AddApplication();

builder.WebHost.UseKestrel(options =>
{
    options.AddServerHeader = false;
    options.ListenAnyIP(GrpcPort, opt => opt.Protocols = HttpProtocols.Http2);
});


var app = builder.Build();

// bind gRPC endpoints
app.MapWhen(ctx => ctx.Request.Host.Port == GrpcPort, intApp =>
{
    intApp.UseRouting();
    intApp.UseEndpoints(endpoints => endpoints.MapGrpcService<CabinetBookingService.CabinetBookingServiceBase>());
});

app.UseHealthChecks("/health");

app.Run();