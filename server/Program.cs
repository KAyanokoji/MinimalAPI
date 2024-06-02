using Carter;
using server.Domain;
using server.Services;
using FluentValidation;
using server.Domain.Validations;
using server.Infrastructure.Repository;
using server.Infrastructure.IRepository;
using system.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapingConfig));

builder.Services.AddValidatorsFromAssemblyContaining<UserCreateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidation>();


builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddSingleton<ExceptionHandler>();

builder.Services.AddCarter();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseEndpointDefinitions();
 app.MapCarter();

// app.RegisterUserRoutes();
// app.AuthRoutes();

app.UseHttpsRedirection();

app.Run();
