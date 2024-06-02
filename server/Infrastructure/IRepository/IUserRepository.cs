using server.Domain.DTOs;
using server.Domain.Models;

namespace server.Infrastructure.IRepository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> Users();
        Task<ApiResponse> User(int id);
        Task<ApiResponse> Create(UserCreateDto request);
        Task<User>Update(int id, UserUpdateDto request);
        Task Delete(int id);
    } 
}