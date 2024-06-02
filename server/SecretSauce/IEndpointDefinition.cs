namespace server.SecretSauce
{
    public interface IEndpointDefinition
    {
        void DefineService(IServiceCollection services);
        void DefineEndpoints(WebApplication app);
    }
}