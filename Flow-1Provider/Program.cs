using AutoMapper;
using Flow_1Provider.AutoMapper;
using Flow_1Provider.Infrastructure.Services;
using Flow_1Provider.Interface;
using Flow_1Provider.Models;
using Flow_1Provider.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddApplicationInsightsTelemetry();

#region Configure CosmosDB
builder.Services.AddSingleton((provider) =>
{
    var endpointUri = configuration["ConnectionStrings:AccountURL"];
    var primaryKey = configuration["ConnectionStrings:AuthKey"];
    var databaseName = configuration["ConnectionStrings:DatabaseId"];

    var cosmosClientOptions = new CosmosClientOptions
    {
        ApplicationName = databaseName,
        ConnectionMode = ConnectionMode.Gateway,

    };

    //var loggerFactory = LoggerFactory.Create(builder =>
    //{
    //    builder.AddConsole();
    //});

    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);


    return cosmosClient;
});
#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Services

builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();

#endregion

builder.Services.Configure<AppSettings>(configuration.GetSection("QuestionTypes"));
builder.Services.Configure<AppSettings>(configuration.GetSection("StageTypes"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();