using ApiGateway.Endpoints;
using Application.Common.interfaces;
using Application.Gateways;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentServiceProxy, StudentServiceProxy>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSwagger();
app.MapApiEndpoints();
app.Run();