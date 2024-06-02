using server.SecretSauce;

namespace server.EndpointDefinitions;

public class UserEndpointDefinitions : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        //  app.MapGet("/user/Users", GetUser);
        //     app.MapGet("/user/{id}", GetUserById);
        //     app.MapPost("/user/create", CreateUser);
                throw new NotImplementedException();

    }

    public void DefineService(IServiceCollection services)
    {
        throw new NotImplementedException();
    }
}
