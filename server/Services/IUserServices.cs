using server.Domain.DTOs;
using server.Domain.Models;

namespace server.Services
{
    public interface IUserServices
    {
        Task<ApiResponse> GetUsers();
        Task<ApiResponse> CreateUser(UserCreateDto user);
        IResult GetUserById(int id);
        IResult UpdateUser(int id, UserUpdateDto user);
        IResult DeleteUser(int id);
    }
}
