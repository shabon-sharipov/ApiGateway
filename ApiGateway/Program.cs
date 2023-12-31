using System.Net;
using System.Net.Http.Headers;
using ApiGateway.Endpoints;
using Application.Common;
using Application.Common.interfaces;
using Application.Gateways;
using Application.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(
            new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticSearchConfiguration:Uri"]))
            {
                IndexFormat =
                    $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower()
                        .Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                AutoRegisterTemplate = true,
                NumberOfShards = 2,
                NumberOfReplicas = 1
            })
        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
        .ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentServiceProxy, StudentServiceProxy>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient(ApiConstant.StudentServiceHttpClient, options =>
{
    options.BaseAddress = new Uri(builder.Configuration["Endpoints:StudentService"]);
    options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
builder.Services.AddHttpClient(ApiConstant.SearchServiceHttpClient, options =>
{
    options.BaseAddress = new Uri(builder.Configuration["Endpoints:SearchService"]);
    options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapSwagger();
app.MapApiEndpoints();
app.Run();