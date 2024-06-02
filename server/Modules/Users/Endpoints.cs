using Carter;
using Microsoft.AspNetCore.Mvc;
using server.Domain.DTOs;
using server.Services;
using system.Helper;

namespace server.Modules.Users
{
    public class Endpoints:CarterModule
    {
        
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/user/Users", GetUser);
            app.MapGet("/user/{id}", GetUserById);
            app.MapPost("/user/create", CreateUser);
            // app.MapPut("/user/update/{id}", UpdateUser);
            // app.MapDelete("/user/delete/{id}", DeleteUser);
        }
        private async Task<IResult> GetUser([FromServices] IUserServices userServices, ExceptionHandler _exception)
        {
             return await _exception.Execute(async () =>
            {
                var user = await userServices.GetUsers();
                return Results.Ok(user);
            });
        //    var user = await userServices.GetUsers();
        //     return Results.Ok(user);
        }
        private IResult GetUserById(int id, [FromServices]IUserServices userServices)
        {
            if (id <= 0) return Results.BadRequest();
            return Results.Ok(userServices.GetUserById(id));
        }

        private async Task<IResult> CreateUser(UserCreateDto request,[FromServices]IUserServices userServices)
        {
            var user = await userServices.CreateUser(request);
            return Results.Ok(user);
        }
    }
}