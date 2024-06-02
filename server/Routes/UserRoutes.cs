using FluentValidation;
using server.Domain.DTOs;
using server.Domain.Models;
using server.Infrastructure.IRepository;

namespace server.Routes
{
    public static class UserRoutes
    {
        public static void RegisterUserRoutes(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/Users", (IUserRepository userRepository) => 
                Results.Ok(userRepository.Users())).WithName("Users").Produces<ApiResponse>(200);

            app.MapGet("/api/Users/{id:int}", (IUserRepository userRepository, int id) =>
                Results.Ok(userRepository.User(id))).WithName("UserById").Produces<ApiResponse>(200);

            app.MapPost("/api/Users",(IUserRepository userRepository, UserCreateDto user) =>
                Results.Ok(userRepository.Create(user))).WithName("Create").Produces<ApiResponse>(201);
        }

        public static void AuthRoutes(this IEndpointRouteBuilder app){
            app.MapPost("/api/auth/login",(IAuthRepository authRepository,Login login)=>
                Results.Ok(authRepository.Login(login))).WithName("Login").Produces<ApiResponse>(200);
            // app.MapPost("/api/auth/forget-password");
            // app.MapPost("/api/auth/registration");
            // app.MapPost("/api/auth/send-otp");
        }
    }
}