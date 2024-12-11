using ChefReservationsMs.Common_Services.DataAccess;
using ChefReservationsMs.Common_Services.Utils;
using ChefReservationsMs.Features.Chefs.Apis.Handlers;
using ChefReservationsMs.Features.Chefs.Apis.Requests;
using ChefReservationsMs.Features.Chefs.Apis.Views;
using ChefReservationsMs.Features.Quotations;
using ChefReservationsMs.Features.Quotations.ObtainQuotations;
using ChefReservationsMs.Features.RequestQuotations.Apis;
using ChefReservationsMs.Features.Chefs.Apis;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region api serialization options
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
#endregion

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddQueryHandler<ObtainQuotationsRequest, ReadOnlyCollection<QuotationView>, ObtainQuotationsHandler>();
builder.Services.AddQueryHandler<PendingChefRequestForQuotation, ReadOnlyCollection<ChefRequestForQuotation>, ChefRequestForQuotationsHandler>();
builder.Services.AddQueryHandler<PendingRequestForQuotation, ReadOnlyCollection<RequestForQuotation>, RequestForQuotationsHandler>();

builder.Services.AddDbContextFactory<ChefReservationsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SagasRepository"), m =>
    {
        m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
        m.MigrationsHistoryTable($"__{nameof(ChefReservationsDbContext)}");
    }));

builder.Services.ConfigureMasstransit();

var app = builder.Build();

app.RegisterQuotationsApis();
app.RegisterRequestQuotationsApi();
app.RegisterChefsApis();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await using var scope = app.Services.CreateAsyncScope();
    using var db = scope.ServiceProvider.GetService<ChefReservationsDbContext>()!;
    db.Database.EnsureDeleted();
    await db.Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
