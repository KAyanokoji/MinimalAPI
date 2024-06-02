using server.Domain.Models;

namespace server.Infrastructure.IRepository
{
 public interface IAuthRepository{
    Task<ApiResponse> Login(Login login);
 }   
}